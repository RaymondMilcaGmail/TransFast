using System;
using System.Net;

namespace TransFastWCFService.Classes
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
        private string _payTokenID = string.Empty;

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

        public string PayTokenID
        {
            get { return _payTokenID; }
            set { _payTokenID = value; }
        }

        #endregion

        #region Methods

        public LookupTransactionResult LookupTransaction()
        {
            LookupTransactionResult lookupTransactionResult = new LookupTransactionResult();

            lookupTransactionResult.TransactionDate = DateTime.Now;
            lookupTransactionResult.TransactionNumber = _transactionNumber;

            if (RemittancePartnerConfiguration.TLSActivated)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(RemittancePartnerConfiguration.SecurityProtocolType);
            }

            string URL = string.Format(RemittancePartnerConfiguration.URL_FORMAT, RemittancePartnerConfiguration.WS_URL, RemittancePartnerConfiguration.Lookup_Endpoint);
            string sessionID = Utils.CreateSessionID();
            string postData = string.Format(RemittancePartnerConfiguration.POSTData, _transactionNumber, sessionID);

            #region Log Request
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logRequest = string.Format("LookupRequest: {0}", postData.Substring(postData.IndexOf("transactionNo"), postData.Length - postData.IndexOf("transactionNo")));
                Utils.WriteToEventLog(logRequest, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion

            string result = Utils.ProcessTransactionRequest(URL, postData);

            #region Log Response
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logResponse = string.Format("LookupResponse: {0}", result);
                Utils.WriteToEventLog(logResponse, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion

            lookupTransactionResult = LookupTransactionResult.GetLookupResult(result, _transactionNumber, lookupTransactionResult, sessionID);

            return lookupTransactionResult;
        }
        #endregion
    }
}