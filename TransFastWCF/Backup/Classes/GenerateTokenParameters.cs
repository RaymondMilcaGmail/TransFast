namespace WesternUnionWCF
{
    public class GenerateTokenParameters
    {
        #region Constructor
        public GenerateTokenParameters()
        { }
        #endregion

        #region Fields/Properties
        public string DateTime { get; set; }
        public string PartnerCode { get; set; }
        public string ReferenceNumber { get; set; }
        public string SecretKey { get; set; }
        #endregion
    }
}
