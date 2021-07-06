using System;

namespace TransFastWCFService.Classes
{
	[global::System.Serializable]
	public class RemittanceException: Exception
	{
		public RemittanceException() { }
		public RemittanceException(string message) : base(message) { }
		public RemittanceException(string message, Exception inner) : base(message, inner) { }
		protected RemittanceException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}