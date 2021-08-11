using System;
using System.Collections.Generic;
using System.Text;

namespace TransFastControlLibrary
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

		#region Constructors

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
		private string _invoiceStatus;

		#endregion

		#region Properties

		public CebuanaBranchInformation CebuanaBranchInformation
		{
			get { return _cebuanaBranchInformation; }
			set { _cebuanaBranchInformation = value; }
		}
		
		public string InvoiceStatus
		{
			get { return _transactionNumber; }
			set { _transactionNumber = value; }
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

		#endregion
	}
}
