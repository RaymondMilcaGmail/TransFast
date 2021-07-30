using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using GeaLimitedWCF.Classes;
using Newtonsoft.Json;
using TransFastWCF.TransFastRespopnse;

namespace TransFastWCFService.Classes
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
        private int _invoiceUpdateID = 0;

        #endregion

        #region Properties


        public int InvoiceUpdateID
        {
            get { return _invoiceUpdateID; }
            set { _invoiceUpdateID = value; }
        }
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
        #endregion

        internal static LookupTransactionResult GetLookupResult(string response, string transactionNumber, LookupTransactionResult lookupResult, string sessionID)
        {
            try
            {
                GetFileResponse responseMainDetails = JsonConvert.DeserializeObject<GetFileResponse>(response);
                FileContent responseDetails = responseMainDetails.Transaction;
                if (Convert.ToBoolean(responseDetails.successful))
                {
                    lookupResult.PayoutAmount = Convert.ToDecimal(responseDetails.InvoiceAmmountToPay);
                    lookupResult.PayoutCurrency = responseDetails.InvoiceCurrency;

                    if (((lookupResult.PayoutCurrency == "PHP") && (lookupResult.PayoutAmount > RemittancePartnerConfiguration.PHPMaxPayoutLimit))
                            || ((lookupResult.PayoutCurrency == "USD") && (lookupResult.PayoutAmount > RemittancePartnerConfiguration.USDMaxPayoutLimit)))
                    {
                        #region amount exceeds limit
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
                        #endregion
                    }
                    else
                    {
                        #region successful
                        lookupResult.MessageToClient = string.Format("[{0}] Lookup transaction successful.", RemittancePartnerConfiguration.ApplicationCode);
                        lookupResult.ResultCode = LookupTransactionResultCode.Successful;

                        lookupResult.SenderLastName = responseDetails.SenderName;
                        lookupResult.SenderFirstName = responseDetails.SenderSurname;
                        lookupResult.SenderFullName = string.Format("{0}, {1}", lookupResult.SenderLastName, lookupResult.SenderFirstName);

                        lookupResult.SenderCountry = responseDetails.SenderCountry;
                        lookupResult.InvoiceUpdateID = responseDetails.InvoiceAgentReference;
                        lookupResult.TransactionStatus = TransactionStatus.ForPayout;
                        lookupResult.PayoutCountry = "PH";
                        lookupResult.MultiCurrencyPayoutCode = RemittancePartnerConfiguration.GetMultiCurrencyPayoutCode;

                        lookupResult.BeneficiaryLastName = responseDetails.ReceiverSurname;
                        lookupResult.BeneficiaryFirstName = responseDetails.ReceiverName;
                        lookupResult.BeneficiaryFullName = string.Format("{0}, {1}", lookupResult.BeneficiaryLastName, lookupResult.BeneficiaryFirstName);

                        lookupResult.BeneficiaryPhoneNumber = responseDetails.ReceiverTelephone1;
                        lookupResult.PayoutID = sessionID;
                        #endregion
                    }
                }
                else
                {
                    #region error
                    string errorMessage = string.Format("[{0}-{1}] {2}", responseMainDetails.ReturnCode, responseMainDetails.ReturnResult, responseMainDetails.ReturnDescription);
                    string errorLogMessage = string.Format("RemittancePartnerLookup_GetLookupResult: {0}", errorMessage);

                    Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);

                    lookupResult._messageToClient = errorMessage;
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
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string errorLogMessage = string.Format("Exception RemittancePartnerLookup_GetLookupResult: {0}", ex.Message);
                Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);

                lookupResult.ResultCode = LookupTransactionResultCode.ServerError;
                lookupResult.MessageToClient = string.Format("{0}: {1}", lookupResult.ResultCode, "Please contact ICT Support Desk.");
            }

            return lookupResult;
        }
    }
}