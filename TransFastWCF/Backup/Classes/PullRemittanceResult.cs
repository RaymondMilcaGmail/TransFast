
using WesterUnionWCF.Classes;

namespace WesternUnionWCF.Classes
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
        public LookupCustomerResult UnlockTransactionResult { get; set; }
    }
}