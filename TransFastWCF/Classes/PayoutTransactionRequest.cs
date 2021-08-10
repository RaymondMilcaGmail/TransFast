using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using TransFastWCF.TransFastRespopnse;

namespace TransFastWCFService.Classes
{
    public class PayoutTransactionRequest
    {
        #region Enums

        private enum TransactionStatuses
        {
            Outstanding = 19,
            PaidOut = 20,
            PayoutPending = 36
        }

        #endregion

        #region Constructor

        public PayoutTransactionRequest()
        {
        }

        #endregion

        #region Fields

        private CebuanaBranchInformation _cebuanaBranchInformation;
        private string _transactionNumber;
        private decimal _payoutAmount;
        private string _sendingCurrency;
        private string _payoutCurrency;
        private decimal _currencyConversionRate;
        private string _payoutCountry;
        private string _senderLastName;
        private string _senderFirstName;
        private string _receiverCustomerNumber;
        private string _receiverLastName;
        private string _receiverFirstName;
        private string _receiverIDType;
        private string _receiverIDDetails;
        private string _receiverIDCode;
        private string _receiverCity;
        private string _receiverCountry;
        private string _senderFullName;
        private string _receiverFullName;
        private string _senderCountry;
        private string _senderState;
        private string _senderEmail;
        private string _senderMobileNumber;
        private string _senderID;
        private decimal _payoutAmountWithServiceCharge;
        private string _payoutID;
        private string _beneficiaryPhoneNumber;
        private string _receiverIDIssuedDate;
        private string _receiverIDExpiryDate;
        private string _payTokenID;
        private string _token;
        private string _partnerCode;
        private string _partnerInternalNumber;


        private int _ReferenceID;
        private DateTime _EventDate;
        private string _EventType;
        private string _EventInfo;
        private string _FileName;
        private string _AssignToken;
        private string _FunctionName;


        public string FunctionName
        {
            get { return _FunctionName; }
            set { _FunctionName = value; }
        }

        public string AssignToken
        {
            get { return _AssignToken; }
            set { _AssignToken = value; }
        }

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
        #endregion

        #region Properties

        public CebuanaBranchInformation CebuanaBranchInformation
        {
            get { return _cebuanaBranchInformation; }
            set { _cebuanaBranchInformation = value; }
        }

        public string TransactionNumber
        {
            get { return _transactionNumber; }
            set { _transactionNumber = value; }
        }

        public decimal PayoutAmount
        {
            get { return _payoutAmount; }
            set { _payoutAmount = value; }
        }

        public string SendingCurrency
        {
            get { return _sendingCurrency; }
            set { _sendingCurrency = value; }
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

        public string ReceiverCustomerNumber
        {
            get { return _receiverCustomerNumber; }
            set { _receiverCustomerNumber = value; }
        }

        public string ReceiverLastName
        {
            get { return _receiverLastName; }
            set { _receiverLastName = value; }
        }

        public string ReceiverFirstName
        {
            get { return _receiverFirstName; }
            set { _receiverFirstName = value; }
        }

        public string ReceiverIDType
        {
            get { return _receiverIDType; }
            set { _receiverIDType = value; }
        }

        public string ReceiverIDNumber
        {
            get { return _receiverIDDetails; }
            set { _receiverIDDetails = value; }
        }

        public string ReceiverIDCode
        {
            get { return _receiverIDCode; }
            set { _receiverIDCode = value; }
        }

        public string ReceiverCity
        {
            get { return _receiverCity; }
            set { _receiverCity = value; }
        }

        public string ReceiverCountry
        {
            get { return _receiverCountry; }
            set { _receiverCountry = value; }
        }

        public string SenderFullName
        {
            get { return _senderFullName; }
            set { _senderFullName = value; }

        }

        public string ReceiverFullName
        {
            get { return _receiverFullName; }
            set { _receiverFullName = value; }
        }

        public string SenderCountry
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

        public decimal PayoutAmountWithServiceCharge
        {
            get { return _payoutAmountWithServiceCharge; }
            set { _payoutAmountWithServiceCharge = value; }
        }

        public string ReceiverIDIssuedDate
        {
            get { return _receiverIDIssuedDate; }
            set { _receiverIDIssuedDate = value; }
        }

        public string ReceiverIDExpiryDate
        {
            get { return _receiverIDExpiryDate; }
            set { _receiverIDExpiryDate = value; }
        }

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        public string PayTokenID
        {
            get { return _payTokenID; }
            set { _payTokenID = value; }
        }

        public string PayoutID
        {
            get { return _payoutID; }
            set { _payoutID = value; }
        }

        public string BeneficiaryPhoneNumber
        {
            get { return _beneficiaryPhoneNumber; }
            set { _beneficiaryPhoneNumber = value; }
        }

        public string SenderID
        {
            get { return _senderID; }
            set { _senderID = value; }
        }

        public string PartnerCode
        {
            get { return _partnerCode; }
            set { _partnerCode = value; }
        }

        public string PartnerInternalNumber
        {
            get { return _partnerInternalNumber; }
            set { _partnerInternalNumber = value; }
        }

        #endregion

        #region Methods

        public PayoutTransactionResult PayoutTransaction(PayoutTransactionRequest payoutTransactionRequest)
        {
            PayoutTransactionResult payoutTransactionResult = new PayoutTransactionResult();

            long transactionID = 0;
            string response = string.Empty;
            string referenceNumber = string.Format("{0}{1}", payoutTransactionRequest.CebuanaBranchInformation.BranchCode, DateTime.Now.ToString("MMddyyyyHHmmss"));

            try
            {
                transactionID = InsertTransactionToDatabase(TransactionStatuses.PayoutPending, payoutTransactionRequest.PayoutID, referenceNumber);
            }
            catch (Exception error)
            {
                Utils.WriteToEventLog(string.Format("InsertTransactionToDatabase:{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);
                throw new Exception(error.Message);
            }

            if (RemittancePartnerConfiguration.TLSActivated)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(RemittancePartnerConfiguration.SecurityProtocolType);
            }

            #region payout trans
            string URL = string.Format(RemittancePartnerConfiguration.URL_FORMAT, RemittancePartnerConfiguration.WS_URL, RemittancePartnerConfiguration.Payout_Endpoint);
            string postData = string.Format(RemittancePartnerConfiguration.POSTDataUpdateTransaction, AssignToken, RemittancePartnerConfiguration.POSCode,TransactionNumber,ReceiverFullName, ReferenceID,PayoutAmount,PayoutCurrency, EventDate);

            #region Log Request
            if (RemittancePartnerConfiguration.LoggingActivated)
            {
                string logRequest = string.Format("PayoutRequest: {0}", postData.Substring(postData.IndexOf("SearchTerm"), postData.Length - postData.IndexOf("SearchTerm")));
                Utils.WriteToEventLog(logRequest, System.Diagnostics.EventLogEntryType.Information);
            }
            #endregion

            string UpdateResult = Utils.ProcessRequest(URL, postData, "Step2PayoutMT");
            UpdateTransactionResponse Step2PayoutMTresponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateTransactionResponse>(UpdateResult);

            if (Step2PayoutMTresponse.ReturnCode == 0)
            {
                try
                {

                    postData = string.Format(RemittancePartnerConfiguration.POSTDataConfirmTransaction, AssignToken, RemittancePartnerConfiguration.POSCode, TransactionNumber, Step2PayoutMTresponse.PaymentToken);

                    #region Log Request
                    if (RemittancePartnerConfiguration.LoggingActivated)
                    {
                        string logRequest = string.Format("PayoutRequest: {0}", postData.Substring(postData.IndexOf("SearchTerm"), postData.Length - postData.IndexOf("SearchTerm")));
                        Utils.WriteToEventLog(logRequest, System.Diagnostics.EventLogEntryType.Information);
                    }
                    #endregion

                    string confirmResult = Utils.ProcessRequest(URL, postData, "Step3ConfirmMT");

                    #region Log Response
                    if (RemittancePartnerConfiguration.LoggingActivated)
                    {
                        string logResponse = string.Format("PayoutResponse: {0}", confirmResult);
                        Utils.WriteToEventLog(logResponse, System.Diagnostics.EventLogEntryType.Information);
                    }
                    #endregion

                    payoutTransactionResult = PayoutTransactionResult.GetPayoutResult(confirmResult, _transactionNumber);
                    #endregion

                    if (payoutTransactionResult.ResultCode == PayoutTransactionResultCode.Successful)
                    {
                        try
                        {
                            UpdateTransaction(transactionID, TransactionStatuses.PaidOut, payoutTransactionRequest.TransactionNumber, transactionID.ToString());
                        }
                        catch (Exception error)
                        {
                            Utils.WriteToEventLog(string.Format("UpdateTransaction:{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorLogMessage = string.Format("Exception RemittancePartnerPayout_GetPayoutResult: {0}", ex.Message);
                    Utils.WriteToEventLog(errorLogMessage, System.Diagnostics.EventLogEntryType.Error);

                    payoutTransactionResult.ResultCode = PayoutTransactionResultCode.ServerError;
                    payoutTransactionResult.MessageToClient = string.Format("{0}: {1}", payoutTransactionResult.ResultCode, "Please contact ICT Support Desk.");
                }
            }
            else
            {
                payoutTransactionResult.ResultCode = PayoutTransactionResultCode.PartnerError;
                payoutTransactionResult.MessageToClient = string.Format("{0}: {1}", Step2PayoutMTresponse.ReturnCode, Step2PayoutMTresponse.ReturnDescription);

            }
            return payoutTransactionResult;
        }

        private long InsertTransactionToDatabase(TransactionStatuses transactionStatus, string partnerInternalReferenceNumber, string partnerInternalReferenceNumber2)
        {

            long transactionID = long.MinValue;
            string operationIpAddress = string.Empty;
            OperationContext context = OperationContext.Current;
            MessageProperties messageProperties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            if (endpointProperty != null)
            {
                operationIpAddress = endpointProperty.Address;
            }

            #region New Insertion To Database

            using (SqlConnection sqlConnection = new SqlConnection())
            { 
                sqlConnection.ConnectionString = RemittancePartnerConfiguration.ConnectionStringRemittanceDatabase;
                SqlCommand sqlCommand = new SqlCommand(RemittancePartnerConfiguration.StoredProcedureInsertPayoutTransaction, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PartnerCode", RemittancePartnerConfiguration.ApplicationCode);
                sqlCommand.Parameters.AddWithValue("@TransactionID", transactionID);
                sqlCommand.Parameters["@TransactionID"].Direction = ParameterDirection.Output;
                sqlCommand.Parameters.AddWithValue("@ControlNumber", TransactionNumber);
                sqlCommand.Parameters.AddWithValue("@TransactionStatusID", (int)transactionStatus);
                sqlCommand.Parameters.AddWithValue("@TransactionStatusDescription", GetTransactionStatusDescription(transactionStatus));
                sqlCommand.Parameters.AddWithValue("@PayoutAmount", PayoutAmount);
                sqlCommand.Parameters.AddWithValue("@SendingCurrency", PayoutCurrency);
                sqlCommand.Parameters.AddWithValue("@PayoutCurrency", PayoutCurrency);
                sqlCommand.Parameters.Add("@CurrencyConversionRate", SqlDbType.Decimal);
                sqlCommand.Parameters["@CurrencyConversionRate"].Precision = 18;
                sqlCommand.Parameters["@CurrencyConversionRate"].Scale = 2;
                sqlCommand.Parameters["@CurrencyConversionRate"].Value = CurrencyConversionRate;
                sqlCommand.Parameters.AddWithValue("@PayoutCountry", PayoutCurrency);

                sqlCommand.Parameters.AddWithValue("@SerderFullName", SenderFullName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SenderLastName", SenderLastName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SenderFirstName", SenderFirstName ?? string.Empty);

                sqlCommand.Parameters.AddWithValue("@BeneficiaryCustomerNumber", Convert.ToInt64(ReceiverCustomerNumber));
                sqlCommand.Parameters.AddWithValue("@BeneficiaryFullName", ReceiverFullName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@BeneficiaryLastName", ReceiverLastName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@BeneficiaryFirstName", ReceiverFirstName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@BeneficiaryIDType", ReceiverIDType);
                sqlCommand.Parameters.AddWithValue("@BeneficiaryIDDetails", ReceiverIDNumber);

                sqlCommand.Parameters.AddWithValue("@ReceiverBranchUserID", CebuanaBranchInformation.BranchUserID);
                sqlCommand.Parameters.AddWithValue("@PayoutBranchCode", CebuanaBranchInformation.BranchCode);


                sqlCommand.Parameters.AddWithValue("@AuditTracker",
                    RemittanceAuditTrail.GetAuditTrailString(
                        _cebuanaBranchInformation.BranchCode,
                        _cebuanaBranchInformation.BranchUserID,
                        "1",
                        "1",
                        operationIpAddress,
                        _cebuanaBranchInformation.ClientMacAddress)
                    );

                sqlCommand.Parameters.AddWithValue("@PartnerInternalReferenceNumber", partnerInternalReferenceNumber);
                sqlCommand.Parameters.AddWithValue("@PartnerInternalReferenceNumber2", partnerInternalReferenceNumber2);

                sqlCommand.Parameters.AddWithValue("@SendingCountry", SenderCountry ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SendingState", SenderState ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SenderEmail", SenderEmail ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SenderMobileNumber", SenderMobileNumber ?? string.Empty);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                transactionID = Convert.ToInt64(sqlCommand.Parameters["@TransactionID"].Value);
                return transactionID;
            }

            #endregion
        }

        private string GetTransactionStatusDescription(TransactionStatuses transactionStatus)
        {
            switch (transactionStatus)
            {
                case TransactionStatuses.PaidOut:
                    return "TIE UP PAID";
                case TransactionStatuses.PayoutPending:
                    return "TIE UP PAYOUTPENDING";
                case TransactionStatuses.Outstanding:
                    return "TIE UP OUTSTANDING";
                default:
                    return "UNKNOWN STATUS";
            }
        }

        private void UpdateTransaction(long transactionID, TransactionStatuses transactionStatus, string partnerInternalReferenceNumber, string partnerInternalReferenceNumber2)
        {
            string operationIpAddress = string.Empty;
            OperationContext context = OperationContext.Current;
            MessageProperties messageProperties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            if (endpointProperty != null)
            {
                operationIpAddress = endpointProperty.Address;
            }

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = RemittancePartnerConfiguration.ConnectionStringRemittanceDatabase;
                SqlCommand sqlCommand = new SqlCommand(RemittancePartnerConfiguration.StoredProcedureUpdatePayoutTransaction, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PartnerCode", RemittancePartnerConfiguration.ApplicationCode);
                sqlCommand.Parameters.AddWithValue("@TransactionID", transactionID);
                sqlCommand.Parameters.AddWithValue("@ControlNumber", TransactionNumber);
                sqlCommand.Parameters.AddWithValue("@TransactionStatusID", (int)transactionStatus);
                sqlCommand.Parameters.AddWithValue("@TransactionStatusDescription", GetTransactionStatusDescription(transactionStatus));
                sqlCommand.Parameters.AddWithValue("@PayoutAmount", PayoutAmount);
                sqlCommand.Parameters.AddWithValue("@SendingCurrency", SendingCurrency);
                sqlCommand.Parameters.AddWithValue("@PayoutCurrency", PayoutCurrency);
                sqlCommand.Parameters.Add("@CurrencyConversionRate", SqlDbType.Decimal);
                sqlCommand.Parameters["@CurrencyConversionRate"].Precision = 18;
                sqlCommand.Parameters["@CurrencyConversionRate"].Scale = 2;
                sqlCommand.Parameters["@CurrencyConversionRate"].Value = _currencyConversionRate;
                sqlCommand.Parameters.AddWithValue("@PayoutCountry", PayoutCountry);

                sqlCommand.Parameters.AddWithValue("@SerderFullName", SenderFullName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SenderLastName", SenderLastName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SenderFirstName", SenderFirstName ?? string.Empty);

                sqlCommand.Parameters.AddWithValue("@BeneficiaryCustomerNumber", Convert.ToInt64(ReceiverCustomerNumber));
                sqlCommand.Parameters.AddWithValue("@BeneficiaryFullName", ReceiverFullName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@BeneficiaryLastName", ReceiverLastName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@BeneficiaryFirstName", ReceiverFirstName ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@BeneficiaryIDType", ReceiverIDType);
                sqlCommand.Parameters.AddWithValue("@BeneficiaryIDDetails", ReceiverIDNumber);

                sqlCommand.Parameters.AddWithValue("@ReceiverBranchUserID", CebuanaBranchInformation.BranchUserID);
                sqlCommand.Parameters.AddWithValue("@PayoutBranchCode", CebuanaBranchInformation.BranchCode);

                sqlCommand.Parameters.AddWithValue("@AuditTracker",
                    RemittanceAuditTrail.GetAuditTrailString(
                        _cebuanaBranchInformation.BranchCode,
                        _cebuanaBranchInformation.BranchUserID,
                        "1",
                        "1",
                        operationIpAddress,
                        _cebuanaBranchInformation.ClientMacAddress)
                    );

                sqlCommand.Parameters.AddWithValue("@PartnerInternalReferenceNumber", partnerInternalReferenceNumber);
                sqlCommand.Parameters.AddWithValue("@PartnerInternalReferenceNumber2", partnerInternalReferenceNumber2);

                sqlCommand.Parameters.AddWithValue("@SendingCountry", SenderCountry ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SendingState", SenderState ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SenderEmail", SenderEmail ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@SenderMobileNumber", SenderMobileNumber ?? string.Empty);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        #endregion
    }
}