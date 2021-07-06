using System;
using System.Collections.Generic;
using System.Text;

namespace TransFastControlLibrary
{
	class GenerateTokenParameters
	{
		private string _secretKey;
		private string _resultCode;
		private string _dateTime;
		private string _partnerCode;

		public string SecretKey
		{
			get { return _secretKey; }
			set { _secretKey = value; }
		}
		public string ReferenceNumber
		{
			get { return _resultCode; }
			set { _resultCode = value; }
		}
		public string DateTime
		{
			get { return _dateTime; }
			set { _dateTime = value; }
		}

		public string PartnerCode
		{
			get { return _partnerCode; }
			set { _partnerCode = value; }
		}
	}
}
