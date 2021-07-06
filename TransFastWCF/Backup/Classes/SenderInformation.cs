namespace WesternUnionWCF.Classes
{
    public class SenderInformation
	{
		private string _firstName;
		private string _lastName;
		private string _country;

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

		public string country
		{
			get { return _country; }
			set { _country = value; }
		}
	}
}