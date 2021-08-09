using Newtonsoft.Json;
using System;
using System.Net;
using TransFastWCF.TransFastRespopnse;

namespace TransFastWCFService.Classes
{
    public class DataTransactionResult
    {
        private DataTransactionResultCode _resultCode = DataTransactionResultCode.UnrecognizedResponse;

        public DataTransactionResultCode ResultCode
        {
            get { return _resultCode; }
            set { _resultCode = value; }
        }


        private string _token = string.Empty;

        private string _AssignToken;

        private string _result = string.Empty;


        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
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

        private int _ReferenceID;
        private DateTime _EventDate;
        private string _EventType;
        private string _EventInfo;
        private string _FileName;



        public int ReferenceID
        {
            get { return _ReferenceID; }
            set { _ReferenceID = value; }
        }

        public DateTime EventDate
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
            string postData = RemittancePartnerConfiguration.POSTDataGetToken;


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

        public DataTransactionResult ProcessTransactionFunction(DataTransactionResult res)
        {

            if (RemittancePartnerConfiguration.TLSActivated)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(RemittancePartnerConfiguration.SecurityProtocolType);
            }

            string URL = string.Format(RemittancePartnerConfiguration.WS_URL);
            string postData = string.Empty;
            switch (FunctionName)
            {
                //case "GetAvaliableFiles":
                //    postData = string.Format(RemittancePartnerConfiguration.POSTDataGetAvaliableFiles, AssignToken);
                //    res.Result = Utils.ProcessRequest(URL, postData, FunctionName);
                //    GetAvaliableFilesResponse data1 = JsonConvert.DeserializeObject<GetAvaliableFilesResponse>(res.Result);

                //    res.ResultCode = data1.ReturnCode == 0 ? DataTransactionResultCode.Successful : DataTransactionResultCode.PartnerError;
                //    res.MessageToClient = data1.ReturnDescription;
                //    break;
              
                case "CommitFile":
                    postData = string.Format(RemittancePartnerConfiguration.POSTDataCommitFile, AssignToken, FileName);
                    res.Result = Utils.ProcessRequest(URL, postData, "CommitFile");
                    CommitFileResponse data3 = JsonConvert.DeserializeObject<CommitFileResponse>(res.Result);
                    res.ResultCode = data3.ReturnCode == 0 ? DataTransactionResultCode.Successful : DataTransactionResultCode.PartnerError;
                    res.MessageToClient = data3.ReturnDescription;
                    break;
                case "UpdateTransactionMSG":
                    postData = string.Format(RemittancePartnerConfiguration.POSTDataUpdateTransactionMSG, AssignToken, ReferenceID, EventDate, EventInfo);
                    res.Result = Utils.ProcessRequest(URL, postData, "UpdateTransaction");
                    UpdateTransactionResponse data4 = JsonConvert.DeserializeObject<UpdateTransactionResponse>(res.Result);
                    res.ResultCode = data4.ReturnCode == 0 ? DataTransactionResultCode.Successful : DataTransactionResultCode.PartnerError;
                    res.MessageToClient = data4.ReturnDescription;
                    break;


            }


            #region Log Response
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logResponse = string.Format("ProcessTransaction " + FunctionName + ": {0}", Result);
                Utils.WriteToEventLog(logResponse, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion
            return res;
        }
    }
}