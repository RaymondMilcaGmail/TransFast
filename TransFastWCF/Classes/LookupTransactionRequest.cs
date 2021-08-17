using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TransFastWCF.TransFastRespopnse;

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
        private string _payoutCurrency = string.Empty;

        #endregion

        #region Properties

        public string PayoutCurrency
        {
            get { return _payoutCurrency; }
            set { _payoutCurrency = value; }
        }
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

            string assignToken = string.Empty;

            try
            {
                assignToken = RequestToken();
                
                if(string.IsNullOrEmpty(assignToken))
                {
                    lookupTransactionResult.ResultCode = LookupTransactionResultCode.PartnerError;
                    lookupTransactionResult.MessageToClient = "An error has occured while retrieving Token from the partner. Please contact ICT Support Desk.";

                    return lookupTransactionResult;
                }
            }
            catch (Exception error)
            {
                Utils.WriteToEventLog(string.Format("RequestToken:{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);

                lookupTransactionResult.ResultCode = LookupTransactionResultCode.ServerError;
                lookupTransactionResult.MessageToClient = "An error has occured while retrieving Token from the partner. Please contact ICT Support Desk.";

                return lookupTransactionResult;
            }

            string URL = string.Format(RemittancePartnerConfiguration.WS_URL);
            string postData = string.Format(RemittancePartnerConfiguration.POSTDataLookup, assignToken, _transactionNumber);

            #region Log Request
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logRequest = string.Format("LookupRequest: {0}", postData.Substring(postData.IndexOf("SearchTerm"), postData.Length - postData.IndexOf("SearchTerm")));
                Utils.WriteToEventLog(logRequest, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion

            string result = Utils.ProcessRequest(URL, postData, "Step1SearchMT");

            #region Log Response
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logResponse = string.Format("LookupResponse: {0}", result);
                Utils.WriteToEventLog(logResponse, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion

            lookupTransactionResult = LookupTransactionResult.GetLookupResult(result, _transactionNumber, lookupTransactionResult, assignToken);

            return lookupTransactionResult;
        }

        private string RequestToken()
        {
            DataTransactionResult dataTransactionResult = new DataTransactionResult();
            string assignToken = string.Empty;

            dataTransactionResult = dataTransactionResult.GetToken(dataTransactionResult);
            TokenResponse responseDetails = JsonConvert.DeserializeObject<TokenResponse>(dataTransactionResult.StrResponse);
            if (responseDetails.ReturnResult == 0)
            {
                assignToken = responseDetails.ReturnToken;

            }

            return assignToken;
        }
        #endregion
    }
}