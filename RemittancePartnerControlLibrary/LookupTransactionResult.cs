using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;

namespace TransFastControlLibrary
{
	public class LookupTransactionResult
	{
		public LookupTransactionResult()
		{ }

		#region Fields

		private TransFastControlLibrary.Utils.LookupTransactionResultCode _resultCode = TransFastControlLibrary.Utils.LookupTransactionResultCode.UnrecognizedResponse;
		private string _messageToClient;
		private string _transactionNumber;
		private string _payTokenID;
		private TransFastControlLibrary.Utils.TransactionStatus _transactionStatus = TransFastControlLibrary.Utils.TransactionStatus.UnrecognizedStatus;
		private DateTime _transactionDate;
		private decimal _payoutAmount;
		private string _payoutCountry = string.Empty;
		private string _payoutCurrency = string.Empty;
		private string _sendingCurrency = string.Empty;
		private decimal _currencyConversionRate;

		private string _senderLastName = string.Empty;
		private string _senderFirstName = string.Empty;

		private string _beneficiaryLastName = string.Empty;
		private string _beneficiaryFirstName = string.Empty;

		private string _senderFullName = string.Empty;
		private string _beneficiaryFullName = string.Empty;


		private string _senderCountry = string.Empty;
		private string _senderState = string.Empty;
		private string _senderEmail = string.Empty;
		private string _senderMobileNumber = string.Empty;


		private string _originCurrency = string.Empty;
		private string _beneficiaryPhoneNumber = string.Empty;
		private decimal _payoutAmountWithServiceCharge;
		private string _payoutID = string.Empty;
		private string _multiCurrencyPayoutCode = string.Empty;
		private string _statusFromPartner = string.Empty;

		private string _messageToClientFromSender = string.Empty;

        private string _assignToken = string.Empty;
        private int _invoiceUpdateID = 0;
        private int _invoiceStatus = 0;
        #endregion

        #region Properties

        public TransFastControlLibrary.Utils.LookupTransactionResultCode ResultCode
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

		public TransFastControlLibrary.Utils.TransactionStatus TransactionStatus
		{
			get { return _transactionStatus; }
			set { _transactionStatus = value; }
		}

		public DateTime TransactionDate
		{
			get { return _transactionDate; }
			set { _transactionDate = value; }
		}

		public decimal PayoutAmount
		{
			get { return _payoutAmount; }
			set { _payoutAmount = value; }
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

		public string SendingCurrency
		{
			get { return _sendingCurrency; }
			set { _sendingCurrency = value; }
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


		public string BeneficiaryLastName
		{
			get { return _beneficiaryLastName; }
			set { _beneficiaryLastName = value; }
		}

		public string BeneficiaryFirstName
		{
			get { return _beneficiaryFirstName; }
			set { _beneficiaryFirstName = value; }
		}

		public string SenderFullName
		{
			get { return _senderFullName; }
			set { _senderFullName = value; }
		}

		public string BeneficiaryFullName
		{
			get { return _beneficiaryFullName; }
			set { _beneficiaryFullName = value; }
		}


		public string SendingCountry
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

		public string BeneficiaryPhoneNumber
		{
			get { return _beneficiaryPhoneNumber; }
			set { _beneficiaryPhoneNumber = value; }
		}

		public string OriginCurrency
		{
			get { return _originCurrency; }
			set { _originCurrency = value; }

		}

		public string PayoutID
		{
			get { return _payoutID; }
			set { _payoutID = value; }
		}

		public decimal PayoutAmountWithServiceCharge
		{
			get { return _payoutAmountWithServiceCharge; }
			set { _payoutAmountWithServiceCharge = value; }
		}

		public string SenderCountry
		{
			get { return _senderCountry; }
			set { _senderCountry = value; }
		}

		public string MultiCurrencyPayoutCode
		{
			get { return _multiCurrencyPayoutCode; }
			set { _multiCurrencyPayoutCode = value; }
		}

		public string StatusFromPartner
		{
			get { return _statusFromPartner; }
			set { _statusFromPartner = value; }
		}
		public string MessageToClientFromSender
		{
			get { return _messageToClientFromSender; }
			set { _messageToClientFromSender = value; }
		}
		public string PayTokenID
		{
			get { return _payTokenID; }
			set { _payTokenID = value; }
		}

        public string AssignToken
        {
            get { return _assignToken; }
            set { _assignToken = value; }
        }
        public int InvoiceStatus
        {
            get { return _invoiceStatus; }
            set { _invoiceStatus = value; }
        }
        public int InvoiceUpdateID
        {
            get { return _invoiceUpdateID; }
            set { _invoiceUpdateID = value; }
        }
        #endregion
    }
}
