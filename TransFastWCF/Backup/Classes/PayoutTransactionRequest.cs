using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Data.SqlClient;
using System.Data;

namespace WesterUnionWCF.Classes
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

        // for qiwi
        private string _partnerInternalNumber;

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

        // for qiwi
        public string PartnerInternalNumber
        {
            get { return _partnerInternalNumber; }
            set { _partnerInternalNumber = value; }
        }

        #endregion

        #region Methods

        public PayoutTransactionResult PayoutTransaction(PayoutTransactionRequest request)
        {
            PayoutTransactionResult payoutTransactionResult = new PayoutTransactionResult();

            string requestRaw = string.Empty;
            HttpResult httpResult = new HttpResult();
            string pointCode = string.Empty;

            switch (request.PayoutCurrency)
            {
                case "PHP":
                    pointCode = RemittancePartnerConfiguration.PointCodePHP;
                    break;
                case "USD":
                    pointCode = RemittancePartnerConfiguration.PointCodeUSD;
                    break;
            }

            string idType = RemittancePartnerConfiguration.GetAppSettingsValue(_receiverIDCode);
            int rakBankIDType = 99;
            long transactionID = 0;

            if (string.IsNullOrEmpty(idType))
            {
                PayoutTransactionResult payoutValidationResult = new PayoutTransactionResult();
                payoutValidationResult.ResultCode = PayoutTransactionResultCode.Unsuccessful;
                payoutValidationResult.MessageToClient = "ID type submitted is not a recognized ID for this transaction. Please use a different ID type.";
                return payoutValidationResult;
            }

            int.TryParse(idType, out rakBankIDType);

            try
            {
                transactionID = InsertTransactionToDatabase(TransactionStatuses.PayoutPending, request.TransactionNumber, request.PayoutID);
            }
            catch (Exception error)
            {
                Utils.WriteToEventLog(string.Format("InsertTransactionToDatabase:{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);
                throw new Exception(error.Message);
            }

            // Pay Incoming
            requestRaw = QiwiUtils.GenerateRequest(this.TransactionNumber, this.PartnerInternalNumber, ActionType.PayIncoming, pointCode);
            httpResult = QiwiUtils.HttpPost(requestRaw, RemittancePartnerConfiguration.WebServiceURL, ActionType.PayIncoming);

            if (RemittancePartnerConfiguration.InsertLog == "true")
            {
                Utils.WriteToEventLog(string.Format("TagAsCompleted Response:{0}", httpResult.Body), System.Diagnostics.EventLogEntryType.Information);
            }

            payoutTransactionResult = PayoutTransactionResult.GetPayoutResult(httpResult, TransactionNumber);

            if (payoutTransactionResult.ResultCode == PayoutTransactionResultCode.Successful)
            {
                try
                {
                    UpdateTransaction(transactionID, TransactionStatuses.PaidOut, request.TransactionNumber, transactionID.ToString());
                }
                catch (Exception error)
                {
                    Utils.WriteToEventLog(string.Format("UpdateTransaction:{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);
                }
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