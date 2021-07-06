using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransFastWCFService.Classes
{
	public class UnlockTransactionResult
	{
		#region Constructor

		public UnlockTransactionResult()
		{
		}

		#endregion

		#region Fields

		private string _unlockResultCode;
		private string _agentSessionID;
		private string _message;

		#endregion

		#region Properties

		public string UnlockResultCode
		{
			get { return _unlockResultCode; }
			set { _unlockResultCode = value; }
		}

		public string AgentSessionID
		{
			get { return _agentSessionID; }
			set { _agentSessionID = value; }
		}

		public string Message
		{
			get { return _message; }
			set { _message = value; }
		}

		#endregion
	}
}