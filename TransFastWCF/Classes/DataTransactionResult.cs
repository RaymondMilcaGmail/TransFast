using System;
using System.Net;

namespace TransFastWCFService.Classes
{
    public class DataTransactionResult
    {
        private LookupTransactionResultCode _resultCode = LookupTransactionResultCode.UnrecognizedResponse;

        public LookupTransactionResultCode ResultCode
        {
            get { return _resultCode; }
            set { _resultCode = value; }
        }

        private string _AssignToken;
        public string AssignToken
        {
            get { return _AssignToken; }
            set { _AssignToken = value; }
        }


        private string _FunctionName;
        public string FunctionName
        {
            get { return _FunctionName; }
            set { _FunctionName = value; }
        }

        private string _messageToClient;
        public string MessageToClient
        {
            get { return _messageToClient; }
            set { _messageToClient = value; }
        }

        private string _ReferenceID;
        private string _EventDate;
        private string _EventType;
        private string _EventInfo;
        private string _FileName;



        public string ReferenceID
        {
            get { return _ReferenceID; }
            set { _ReferenceID = value; }
        }

        public string EventDate
        {
            get { return _EventDate; }
            set { _EventDate = value; }
        }
        public string EventType
        {
            get { return _EventType; }
            set { _EventType = value; }
        }
        public string EventInfo
        {
            get { return _EventInfo; }
            set { _EventInfo = value; }
        }
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public string GetToken()
        {
            if (RemittancePartnerConfiguration.TLSActivated)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(RemittancePartnerConfiguration.SecurityProtocolType);
            }

            string URL = string.Format(RemittancePartnerConfiguration.WS_URL);
            string postData = string.Format(RemittancePartnerConfiguration.POSTDataGetToken);


            string result = Utils.ProcessRequest(URL, postData, "CoGetAutorization");

            #region Log Response
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logResponse = string.Format("LookupResponse: {0}", result);
                Utils.WriteToEventLog(logResponse, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion
            return result;
        }

        public string ProcessTransaction()
        {
            if (RemittancePartnerConfiguration.TLSActivated)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(RemittancePartnerConfiguration.SecurityProtocolType);
            }

            string URL = string.Format(RemittancePartnerConfiguration.WS_URL);
           string result = string.Empty;
            string postData = string.Empty;
            switch (FunctionName)
            {
                case "GetAvaliableFiles":
                    postData = string.Format(RemittancePartnerConfiguration.POSTDataGetAvaliableFiles, AssignToken); 
                     result = Utils.ProcessRequest(URL, postData, FunctionName);
                    break;
                case "GetFile":
                    postData = string.Format(RemittancePartnerConfiguration.POSTDataGetFile, AssignToken, FileName);
                    result = Utils.ProcessRequest(URL, postData, FunctionName);
                    break;
                case "CommitFile":
                    postData = string.Format(RemittancePartnerConfiguration.POSTDataCommitFile, AssignToken, FileName);
                    result = Utils.ProcessRequest(URL, postData, FunctionName);
                    break;
                case "UpdateTransaction":
                    postData = string.Format(RemittancePartnerConfiguration.POSTDataUpdateTransaction, AssignToken, ReferenceID, EventDate, EventType, EventInfo);
                    result = Utils.ProcessRequest(URL, postData, FunctionName);
                    break;
            }


            #region Log Response
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logResponse = string.Format("ProcessTransaction " + FunctionName + ": {0}", result);
                Utils.WriteToEventLog(logResponse, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion
            return result;
        }
    }
}