using System;
using System.IO;
using System.Xml.Serialization;
using GeaLimitedWCF.Classes;
using Newtonsoft.Json;

namespace TransFastWCFService.Classes
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
        internal static PayoutTransactionResult GetPayoutResult(string response, string transactionNumber)
        {
            PayoutTransactionResult payoutResult = new PayoutTransactionResult();

            try
            {
                PartnerResponseData responseDetails = JsonConvert.DeserializeObject<PartnerResponseData>(response);

                if (Convert.ToBoolean(responseDetails.successful))
                {
                    payoutResult._resultCode = PayoutTransactionResultCode.Successful;
                    payoutResult._messageToClient = "Payout transaction successful.";
                    payoutResult.TransactionNumber = transactionNumber;
                    payoutResult.PayoutDate = DateTime.Now;
                    payoutResult.MessageToClient = string.Format("[{0}:{1}] {2}", RemittancePartnerConfiguration.ApplicationCode, payoutResult._resultCode, payoutResult._messageToClient);
                }
                else
                {
                    string errorMessage = string.Format("[{0}-{1}] {2}", responseDetails.responseCode, responseDetails.status, responseDetails.responseMessage);
                    string errorLogMessage = string.Format("RemittancePartnerPayout_GetPayoutResult: {0}", errorMessage);

                    Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);

                    payoutResult._resultCode = PayoutTransactionResultCode.Unsuccessful;
                    payoutResult._messageToClient = errorMessage;

                    payoutResult.TransactionNumber = transactionNumber;
                    payoutResult.PayoutDate = DateTime.Now;
                    payoutResult.MessageToClient = string.Format("[{0}:{1}] {2}", RemittancePartnerConfiguration.ApplicationCode, payoutResult._resultCode, payoutResult._messageToClient);
                }
            }
            catch (Exception ex)
            {
                string errorLogMessage = string.Format("Exception RemittancePartnerPayout_GetPayoutResult: {0}", ex.Message);
                Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);

                payoutResult.ResultCode = PayoutTransactionResultCode.ServerError;
                payoutResult.MessageToClient = string.Format("{0}: {1}", payoutResult.ResultCode, "Please contact ICT Support Desk.");
            }

            return payoutResult;
        }
        #endregion
    }
}