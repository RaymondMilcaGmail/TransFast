namespace TransFastWCFService.Classes
{
    public class CebuanaBranchInformation
	{
		#region Constructor

		public CebuanaBranchInformation()
		{
		}

		#endregion

		#region Fields

		private string _branchUserID;
		private string _branchName;
		private string _branchCode;
		private string _branchAreaCode;
		private string _branchRegionCode;
		private string _clientApplicationVersion;
		private string _clientMacAddress;

		#endregion

		#region Properties

		public string BranchUserID
		{
			get { return _branchUserID; }
			set { _branchUserID = value; }
		}

		public string BranchName
		{
			get { return _branchName; }
			set { _branchName = value; }
		}

		public string BranchCode
		{
			get { return _branchCode; }
			set { _branchCode = value; }
		}

		public string BranchAreaCode
		{
			get { return _branchAreaCode; }
			set { _branchAreaCode = value; }
		}

		public string BranchRegionCode
		{
			get { return _branchRegionCode; }
			set { _branchRegionCode = value; }
		}

		public string ClientApplicationVersion
		{
			get { return _clientApplicationVersion; }
			set { _clientApplicationVersion = value; }
		}

		public string ClientMacAddress
		{
			get { return _clientMacAddress; }
			set { _clientMacAddress = value; }
		}

		#endregion
	}
}