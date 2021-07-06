using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WesterUnionWCF.Classes
{
    public class LookupTransactionRequest
    {
        #region Constructor

        public LookupTransactionRequest()
        {
        }

        #endregion

        #region Fields

        private CebuanaBranchInformation _cebuanaBranchInformation;
        private string _transactionNumber = string.Empty;
        private string _token = string.Empty;
        private string _partnerCode = string.Empty;

        #endregion

        #region Properties

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        public string TransactionNumber
        {
            get { return _transactionNumber; }
            set { _transactionNumber = value; }
        }

        public string PartnerCode
        {
            get { return _partnerCode; }
            set { _partnerCode = value; }
        }

        public CebuanaBranchInformation CebuanaBranchInformation
        {
            get { return _cebuanaBranchInformation; }
            set { _cebuanaBranchInformation = value; }
        }

        #endregion

        #region Methods

        public LookupTransactionResult LookupTransaction()
        {
            LookupTransactionResult lookupTransactionResult = new LookupTransactionResult();
            string pointCode = string.Empty;

            lookupTransactionResult.TransactionDate = DateTime.Now;
            lookupTransactionResult.PayoutCountry = "PH";
            lookupTransactionResult.MultiCurrencyPayoutCode = "";
            lookupTransactionResult.TransactionNumber = TransactionNumber;

            lookupTransactionResult.SenderFirstName = "";
            lookupTransactionResult.SenderLastName = "";
            lookupTransactionResult.SenderFullName = "";
            lookupTransactionResult.SenderCountry = "";

            lookupTransactionResult.BeneficiaryFirstName = "";
            lookupTransactionResult.BeneficiaryLastName = "";
            lookupTransactionResult.BeneficiaryFullName = "";
            lookupTransactionResult.BeneficiaryPhoneNumber = "";

            lookupTransactionResult.PayoutAmount = 0;
            lookupTransactionResult.PayoutAmountWithServiceCharge = 0;
            lookupTransactionResult.PayoutCurrency = "";
            lookupTransactionResult.PayTokenID = "";

            string requestRaw = string.Empty;
            HttpResult httpResult = new HttpResult();

            // Incoming Ready to Pay in Branch
            # region Search in PHP
            pointCode = RemittancePartnerConfiguration.PointCodePHP;
            requestRaw = QiwiUtils.GenerateRequest(TransactionNumber, "", ActionType.IncomingReadyToPay, pointCode);
            httpResult = QiwiUtils.HttpPost(requestRaw, RemittancePartnerConfiguration.WebServiceURL, ActionType.IncomingReadyToPay);
            qiwiRowData = QiwiUtils.ParseIncomingReadyToPayResponse(httpResult.Body, TransactionNumber);
            #endregion
            # region Search in USD
            if (qiwiRowData.ResponseCode.Equals("0") && string.IsNullOrEmpty(qiwiRowData.DocId))
            {
                pointCode = RemittancePartnerConfiguration.PointCodeUSD;
                requestRaw = QiwiUtils.GenerateRequest(TransactionNumber, "", ActionType.IncomingReadyToPay, pointCode);
                httpResult = QiwiUtils.HttpPost(requestRaw, RemittancePartnerConfiguration.WebServiceURL, ActionType.IncomingReadyToPay);
                qiwiRowData = QiwiUtils.ParseIncomingReadyToPayResponse(httpResult.Body, TransactionNumber);
            }
            #endregion

            if (qiwiRowData.ResponseCode.Equals("0"))
                if (string.IsNullOrEmpty(qiwiRowData.DocId)) // Transaction not found
                {
                    string ErrorMessage = "Transaction not found.";
                    lookupTransactionResult.MessageToClient = string.Format("{0}", ErrorMessage);
                    lookupTransactionResult.TransactionStatus = TransactionStatus.UnrecognizedStatus;
                    lookupTransactionResult.ResultCode = LookupTransactionResultCode.Unsuccessful;
                }
                else
                {
                    lookupTransactionResult.PartnerInternalNumber = qiwiRowData.DocId;
                    switch (qiwiRowData.State)
                    {
                        case "4":
                            lookupTransactionResult.TransactionStatus = TransactionStatus.ForPayout;
                            lookupTransactionResult.MultiCurrencyPayoutCode = RemittancePartnerConfiguration.GetMultiCurrencyPayoutCode;

                            lookupTransactionResult.TransferPPCode = qiwiRowData.PpCode;
                            lookupTransactionResult.SenderFullName = qiwiRowData.SenderName;
                            lookupTransactionResult.BeneficiaryFullName = qiwiRowData.RecName;
                            lookupTransactionResult.PayoutCurrency = qiwiRowData.Code;
                            lookupTransactionResult.PayoutAmount = qiwiRowData.Amount;

                            requestRaw = QiwiUtils.GenerateRequest(TransactionNumber, qiwiRowData.DocId, ActionType.Get, pointCode);
                            httpResult = QiwiUtils.HttpPost(requestRaw, RemittancePartnerConfiguration.WebServiceURL, ActionType.Get);

                            lookupTransactionResult = LookupTransactionResult.GetLookupResult(httpResult.Body, this.TransactionNumber, lookupTransactionResult);
                            break;
                        case "6":
                            qiwiRowData.StateStr = "Transaction has already been paid.";
                            lookupTransactionResult.MessageToClient = string.Format("[{0}]{1}", qiwiRowData.State, qiwiRowData.StateStr);
                            lookupTransactionResult.TransactionStatus = TransactionStatus.PaidOut;
                            lookupTransactionResult.ResultCode = LookupTransactionResultCode.Unsuccessful;
                            break;
                        default:
                            lookupTransactionResult.MessageToClient = string.Format("[{0}]{1}", qiwiRowData.State, qiwiRowData.StateStr);
                            lookupTransactionResult.TransactionStatus = TransactionStatus.UnrecognizedStatus;
                            string errorLogMessage = string.Format("RemittancePartnerLookup_LookupTransaction\nCode: {0}\nDescription: {1}", qiwiRowData.State, qiwiRowData.StateStr);
                            Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);
                            break;
                    }
                }
            else
            {
                lookupTransactionResult.MessageToClient = string.Format("[{0}]{1}", qiwiRowData.ResponseCode, qiwiRowData.ResponseMessage);
                lookupTransactionResult.TransactionStatus = TransactionStatus.UnrecognizedStatus;
                string errorLogMessage = string.Format("RemittancePartnerLookup_LookupTransaction_ParseIncomingReadyToPayResult \nCode: {0}\nDescription: {1}", qiwiRowData.ResponseCode, qiwiRowData.ResponseMessage);
                Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);
            }

            return lookupTransactionResult;
        }
        #endregion
    }
}