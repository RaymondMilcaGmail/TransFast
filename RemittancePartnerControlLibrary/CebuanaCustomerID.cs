using System;
using System.Collections.Generic;
using System.Text;

namespace TransFastControlLibrary
{
	public class CebuanaCustomerID
	{
		#region Constructor

		public CebuanaCustomerID()
		{
		}

		#endregion

		#region Fields

		private string _iDCode;
		private string _iDDescription;

		#endregion

		#region Properties

		public string IDCode
		{
			get { return _iDCode; }
			set { _iDCode = value; }
		}

		public string IDDescription
		{
			get { return _iDDescription; }
			set { _iDDescription = value; }
		}

		#endregion
	}
}
