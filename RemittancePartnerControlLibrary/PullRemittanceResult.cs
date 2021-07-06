using System;
using System.Collections.Generic;
using System.Text;

namespace TransFastControlLibrary
{
	public class PullRemittanceResult
	{
		private string _pullMethod;

		public string PullMethod
		{
			get { return _pullMethod; }
			set { _pullMethod = value; }
		}

		public LookupTransactionResult LookupTransactionResult { get; set; }
		public PayoutTransactionResult PayoutTransactionResult { get; set; }
		public UnlockTransactionResult UnlockTransactionResult { get; set; }
	}
}
