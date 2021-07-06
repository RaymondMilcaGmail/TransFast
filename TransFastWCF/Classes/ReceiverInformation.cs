namespace TransFastWCFService.Classes
{
    public class ReceiverInformation
	{
		private string _firstName;
		private string _lastName;
		private string _phoneNumber;

		private string _identification;
		private string _identificationType;
		private string _nationality;
		private string _city;
		private string _birthDate;
		private string _mobileNumber;

		public string firstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

		public string lastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		public string phoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}

		public string identification
		{
			get { return _identification; }
			set { _identification = value; }
		}

		public string identificationType
		{
			get { return _identificationType; }
			set { _identificationType = value; }
		}

		public string nationality
		{
			get { return _nationality; }
			set { _nationality = value; }
		}

		public string city
		{
			get { return _city; }
			set { _city = value; }
		}

		public string birthDate
		{
			get { return _birthDate; }
			set { _birthDate = value; }
		}

		public string mobileNumber
		{
			get { return _mobileNumber; }
			set { _mobileNumber = value; }
		}
	}
}