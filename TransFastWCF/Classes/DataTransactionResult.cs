using System;
using System.Net;

namespace TransFastWCFService.Classes
{
    public class DataTransactionResult
    {

        public string GetToken()
        {
            if (RemittancePartnerConfiguration.TLSActivated)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(RemittancePartnerConfiguration.SecurityProtocolType);
            }

            string URL = string.Format(RemittancePartnerConfiguration.WS_URL);
            string sessionID = Utils.CreateSessionID();
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
    }
}