using System;
using System.Collections.Generic;
using System.Text;

namespace TransFastControlLibrary
{
	public class PayoutTransactionResult
	{
		#region Constructor
		public PayoutTransactionResult()
		{
		}

		#endregion

		#region Fields

		private TransFastControlLibrary.Utils.PayoutTransactionResultCode _resultCode = TransFastControlLibrary.Utils.PayoutTransactionResultCode.UnrecognizedResponse;
		private string _messageToClient;
		private string _transactionNumber;
		private DateTime _payoutDate;

		#endregion

		#region Properties

		public TransFastControlLibrary.Utils.PayoutTransactionResultCode ResultCode
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
	}
}
