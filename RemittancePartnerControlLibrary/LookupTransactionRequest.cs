using System;
using System.Collections.Generic;
using System.Text;

namespace TransFastControlLibrary
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
		private string _transactionNumber;
		private string _payTokenID;
		private string _token;
		private string _partnerCode;
		private string _payoutCurrency;

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
	}
}
