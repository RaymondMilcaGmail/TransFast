using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Xml;

namespace WesterUnionWCF.Classes
{
    public class LookupTransactionResult
    {
        #region Constructors

        public LookupTransactionResult()
        {
        }

        #endregion

        #region Fields

        private LookupTransactionResultCode _resultCode = LookupTransactionResultCode.UnrecognizedResponse;
        private string _messageToClient;
        private string _transactionNumber;
        private string _payTokenID;
        private TransactionStatus _transactionStatus = TransactionStatus.UnrecognizedStatus;
        private DateTime _transactionDate;
        private decimal _payoutAmount;
        private string _payoutCountry = string.Empty;
        private string _payoutCurrency = string.Empty;
        private string _sendingCurrency = string.Empty;
        private decimal _currencyConversionRate;
        private string _senderLastName = string.Empty;
        private string _senderFirstName = string.Empty;
        private string _beneficiaryLastName = string.Empty;
        private string _beneficiaryFirstName = string.Empty;
        private string _senderFullName = string.Empty;
        private string _beneficiaryFullName = string.Empty;
        private string _senderCountry = string.Empty;
        private string _senderState = string.Empty;
        private string _senderEmail = string.Empty;
        private string _senderMobileNumber = string.Empty;
        private string _originCurrency = string.Empty;
        private string _beneficiaryPhoneNumber = string.Empty;
        private decimal _payoutAmountWithServiceCharge;
        private string _payoutID = string.Empty;
        private string _multiCurrencyPayoutCode = string.Empty;
        private string _statusFromPartner = string.Empty;
        private string _messageToClientFromSender = string.Empty;

        // for qiwi
        private string _partnerInternalNumber = string.Empty;
        private string _transferPPCode = string.Empty;
        #endregion

        #region Properties

        public LookupTransactionResultCode ResultCode
        {
            get { return _resultCode; }
            set { _resultCode = value; }
        }

        public string MessageToClient
        {
            get { return _messageToClient; }
            set { _messageToClient = value; }
        }

        public string TransactionNumber
        {
            get { return _transactionNumber; }
            set { _transactionNumber = value; }
        }

        public TransactionStatus TransactionStatus
        {
            get { return _transactionStatus; }
            set { _transactionStatus = value; }
        }

        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set { _transactionDate = value; }
        }

        public decimal PayoutAmount
        {
            get { return _payoutAmount; }
            set { _payoutAmount = value; }
        }

        public string PayoutCurrency
        {
            get { return _payoutCurrency; }
            set { _payoutCurrency = value; }
        }

        public decimal CurrencyConversionRate
        {
            get { return _currencyConversionRate; }
            set { _currencyConversionRate = value; }
        }

        public string SendingCurrency
        {
            get { return _sendingCurrency; }
            set { _sendingCurrency = value; }
        }

        public string PayoutCountry
        {
            get { return _payoutCountry; }
            set { _payoutCountry = value; }
        }

        public string SenderLastName
        {
            get { return _senderLastName; }
            set { _senderLastName = value; }
        }

        public string SenderFirstName
        {
            get { return _senderFirstName; }
            set { _senderFirstName = value; }
        }


        public string BeneficiaryLastName
        {
            get { return _beneficiaryLastName; }
            set { _beneficiaryLastName = value; }
        }

        public string BeneficiaryFirstName
        {
            get { return _beneficiaryFirstName; }
            set { _beneficiaryFirstName = value; }
        }

        public string SenderFullName
        {
            get { return _senderFullName; }
            set { _senderFullName = value; }
        }

        public string BeneficiaryFullName
        {
            get { return _beneficiaryFullName; }
            set { _beneficiaryFullName = value; }
        }


        public string SendingCountry
        {
            get { return _senderCountry; }
            set { _senderCountry = value; }
        }

        public string SenderState
        {
            get { return _senderState; }
            set { _senderState = value; }
        }
        public string SenderEmail
        {
            get { return _senderEmail; }
            set { _senderEmail = value; }
        }

        public string SenderMobileNumber
        {
            get { return _senderMobileNumber; }
            set { _senderMobileNumber = value; }
        }

        public string BeneficiaryPhoneNumber
        {
            get { return _beneficiaryPhoneNumber; }
            set { _beneficiaryPhoneNumber = value; }
        }

        public string OriginCurrency
        {
            get { return _originCurrency; }
            set { _originCurrency = value; }

        }

        public string PayoutID
        {
            get { return _payoutID; }
            set { _payoutID = value; }
        }

        public decimal PayoutAmountWithServiceCharge
        {
            get { return _payoutAmountWithServiceCharge; }
            set { _payoutAmountWithServiceCharge = value; }
        }

        public string SenderCountry
        {
            get { return _senderCountry; }
            set { _senderCountry = value; }
        }

        public string MultiCurrencyPayoutCode
        {
            get { return _multiCurrencyPayoutCode; }
            set { _multiCurrencyPayoutCode = value; }
        }

        public string StatusFromPartner
        {
            get { return _statusFromPartner; }
            set { _statusFromPartner = value; }
        }
        public string MessageToClientFromSender
        {
            get { return _messageToClientFromSender; }
            set { _messageToClientFromSender = value; }
        }
        public string PayTokenID
        {
            get { return _payTokenID; }
            set { _payTokenID = value; }
        }

        // for qiwi
        public string PartnerInternalNumber
        {
            get { return _partnerInternalNumber; }
            set { _partnerInternalNumber = value; }
        }

        internal string TransferPPCode
        {
            get { return _transferPPCode; }
            set { _transferPPCode = value; }
        }
        #endregion

        internal static LookupTransactionResult GetLookupResult(string responseFull, string transactionNumber, LookupTransactionResult lookupResult)
        {
            try
            {

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(rawResponse.ResponseData);

                XmlNode responseNode = xmldoc.ChildNodes[1];

                XmlNodeList remittanceDetailsList = responseNode.ChildNodes;

                foreach (XmlNode remittanceDetail in remittanceDetailsList)
                {
                    switch (remittanceDetail.Name)
                    {
                        case "sName":
                            lookupResult.SenderFirstName = remittanceDetail.InnerText;
                            break;
                        case "sLastName":
                            lookupResult.SenderLastName = remittanceDetail.InnerText;
                            break;
                        case "trnSendPointCountry":
                            lookupResult.SenderCountry = remittanceDetail.InnerText;
                            break;
                        case "sPhone":
                            lookupResult.SenderMobileNumber = remittanceDetail.InnerText;
                            break;

                        case "bName":
                            lookupResult.BeneficiaryFirstName = remittanceDetail.InnerText;
                            break;
                        case "bLastName":
                            lookupResult.BeneficiaryLastName = remittanceDetail.InnerText;
                            break;

                        // PHP payout
                        case "trnPayoutCurrency":
                            if (lookupResult.TransferPPCode.Equals(RemittancePartnerConfiguration.PointCodePHP))
                            {
                                lookupResult.PayoutCurrency = remittanceDetail.InnerText;
                            }
                            break;
                        case "trnPayoutAmount":
                            if (lookupResult.TransferPPCode.Equals(RemittancePartnerConfiguration.PointCodePHP))
                            {
                                lookupResult.PayoutAmount = Convert.ToDecimal(remittanceDetail.InnerText);
                            }
                            break;
                    }
                }

                lookupResult.MessageToClient = string.Format("[{0}] Lookup transaction successful.", RemittancePartnerConfiguration.ApplicationCode);
                lookupResult.ResultCode = LookupTransactionResultCode.Successful;

                if (((lookupResult.PayoutCurrency == "PHP") && (lookupResult.PayoutAmount > RemittancePartnerConfiguration.PHPMaxPayoutLimit))
                        || ((lookupResult.PayoutCurrency == "USD") && (lookupResult.PayoutAmount > RemittancePartnerConfiguration.USDMaxPayoutLimit)))
                {
                    lookupResult._messageToClient = "Transaction amount exceeds transaction limit.";
                    lookupResult._resultCode = LookupTransactionResultCode.Unsuccessful;
                    lookupResult._messageToClient = string.Format("{0}: {1}", lookupResult._resultCode, lookupResult._messageToClient);

                    lookupResult.TransactionDate = DateTime.Now;
                    lookupResult.PayoutCountry = "PH";
                    lookupResult.MultiCurrencyPayoutCode = "";

                    lookupResult.SenderFirstName = "";
                    lookupResult.SenderLastName = "";
                    lookupResult.SenderFullName = "";
                    lookupResult.SenderCountry = "";

                    lookupResult.BeneficiaryFirstName = "";
                    lookupResult.BeneficiaryLastName = "";
                    lookupResult.BeneficiaryFullName = "";
                    lookupResult.BeneficiaryPhoneNumber = "";

                    lookupResult.PayoutAmount = 0;
                    lookupResult.PayoutAmountWithServiceCharge = 0;
                    lookupResult.PayoutCurrency = "";
                    lookupResult.PayTokenID = "";
                }

            }
            catch (Exception ex)
            {
                string errorLogMessage = string.Format("Exception RemittancePartnerLookup_ParseGet: {0}", ex.Message);
                Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);

                lookupResult.ResultCode = LookupTransactionResultCode.ServerError;
            }

            return lookupResult;
        }
    }
}