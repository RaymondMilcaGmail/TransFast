using System;
using System.Collections.Generic;
using System.Text;

namespace TransFastControlLibrary
{
	public class PullRemittanceRequest
	{
		private string _pullMethod;

		public string PullMethod
		{
			get { return _pullMethod; }
			set { _pullMethod = value; }
		}

		public LookupTransactionRequest LookupTransactionRequest { get; set; }
		public PayoutTransactionRequest PayoutTransactionRequest { get; set; }
		public UnlockTransactionRequest UnlockTransactionRequest { get; set; }
	}
}
