using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Xml;

namespace WesterUnionWCF.Classes
{
    public class PayoutTransactionResult
    {
        #region Constructor

        public PayoutTransactionResult()
        { }

        #endregion

        #region Fields

        private PayoutTransactionResultCode _resultCode = PayoutTransactionResultCode.UnrecognizedResponse;
        private string _messageToClient;
        private string _transactionNumber;
        private DateTime _payoutDate;

        #endregion

        #region Properties

        public PayoutTransactionResultCode ResultCode
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

        public DateTime PayoutDate
        {
            get { return _payoutDate; }
            set { _payoutDate = value; }
        }

        #endregion

        #region Methods
        internal static PayoutTransactionResult GetPayoutResult(HttpResult httpResult, string transactionNumber)
        {
            PayoutTransactionResult payoutResult = new PayoutTransactionResult();

            payoutResult.TransactionNumber = transactionNumber;
            payoutResult.PayoutDate = DateTime.Now;

            string responseCode = string.Empty;
            string responseMessage = string.Empty;

            if (httpResult.StatusCode == 200)
            {
                try
                {
                    RawResponse rawResponse = QiwiUtils.RetrieveResponseData(httpResult.Body, ActionType.PayIncoming);

                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(rawResponse.ResponseData);

                    XmlNode response = xmldoc.ChildNodes[1];

                    foreach (XmlNode attribute in response.Attributes)
                    {
                        switch (attribute.Name)
                        {
                            case "RE":
                                responseCode = attribute.Value.ToString();
                                break;
                            case "ERR_TEXT":
                                responseMessage = attribute.Value.ToString();
                                break;
                        }
                    }

                    switch (responseCode)
                    {
                        case "0":
                            payoutResult.ResultCode = PayoutTransactionResultCode.Successful;
                            responseMessage = "Payout transaction successful.";
                            break;
                        default:
                            payoutResult.ResultCode = PayoutTransactionResultCode.Unsuccessful;
                            string errorLogMessage = string.Format("RemittancePartnerPayout_GetPayoutResult\nCode: {0}\nDescription: {1}", responseCode, responseMessage);
                            Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    string errorLogMessage = string.Format("Exception RemittancePartnerPayout_GetResult: {0}", ex.Message);
                    Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            else
            {
                responseCode = httpResult.StatusCode.ToString();
                responseMessage = httpResult.Body;
            }

            payoutResult.MessageToClient = string.Format("[{0}:{1}] {2}", RemittancePartnerConfiguration.ApplicationCode, responseCode, responseMessage);
            return payoutResult;
        }

        #endregion
    }
}