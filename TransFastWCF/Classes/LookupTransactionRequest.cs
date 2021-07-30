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
        private string _AssignToken = string.Empty;
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

        public string AssignToken
        {
            get { return _AssignToken; }
            set { _AssignToken = value; }
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

            string URL = string.Format(RemittancePartnerConfiguration.WS_URL);
            string sessionID = Utils.CreateSessionID();
            string postData = string.Format(RemittancePartnerConfiguration.POSTDataGetAvaliableFiles, AssignToken);

            #region Log Request
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logRequest = string.Format("LookupRequest: {0}", TransactionNumber);
                Utils.WriteToEventLog(logRequest, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion
            string FileList = Utils.ProcessRequest(URL, postData, "GetAvaliableFiles");

            GetAvaliableFilesResponse responseGetavailable = JsonConvert.DeserializeObject<GetAvaliableFilesResponse>(FileList);
            if (responseGetavailable.ReturnResult == 0)
            {
                string result = string.Empty;
                bool Error = true;
                GetFileResponse responseGetFIle = new GetFileResponse();
                foreach (AvaliableFIle avaliableFIle in responseGetavailable.AvaliableFIles)
                {
                    string GFpostData = string.Format(RemittancePartnerConfiguration.POSTDataGetFile, AssignToken, avaliableFIle.FileName);
                    string Files = Utils.ProcessRequest(URL, GFpostData, "GetFile");
                    responseGetFIle = JsonConvert.DeserializeObject<GetFileResponse>(Files);
                    if (responseGetFIle.ReturnResult == 0)
                    {
                        FileContent transactionDetails = new FileContent();
                        transactionDetails = responseGetFIle.FileContents.Where(x => x.InvoicePassWord.ToString() == _transactionNumber).FirstOrDefault();
                        if (responseGetFIle.ReturnCode == 0)
                        {

                            if (transactionDetails != null)
                            {
                                transactionDetails.successful = true;
                                responseGetFIle.Transaction = transactionDetails;
                                Error = false;
                            }
                        }
                        else
                        {

                            lookupTransactionResult.ResultCode = LookupTransactionResultCode.PartnerError;
                            lookupTransactionResult.MessageToClient = responseGetFIle.ReturnDescription;
                            break;
                        }
                    }
                    else
                    {

                        lookupTransactionResult.ResultCode = LookupTransactionResultCode.PartnerError;
                        lookupTransactionResult.MessageToClient = responseGetavailable.ReturnDescription;
                        break;
                    }
                }
                #region Log Response
                if (RemittancePartnerConfiguration.LoggingActivated)
                {
                    string logResponse = string.Format("LookupResponse: {0}", result);
                    Utils.WriteToEventLog(logResponse, System.Diagnostics.EventLogEntryType.Information);
                }
                #endregion
                if (!Error)
                {

                    result = JsonConvert.SerializeObject(responseGetFIle);
                    lookupTransactionResult = LookupTransactionResult.GetLookupResult(result, _transactionNumber, lookupTransactionResult, sessionID);

                }

            }
            else
            {
                lookupTransactionResult.ResultCode = LookupTransactionResultCode.PartnerError;
                lookupTransactionResult.MessageToClient = responseGetavailable.ReturnDescription;
            }
            return lookupTransactionResult;
        }
        #endregion
    }
}