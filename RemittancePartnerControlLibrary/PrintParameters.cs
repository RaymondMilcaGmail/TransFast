using System;

namespace TransFastControlLibrary
{
    class PrintParameters
    {
        #region Constructors

        internal PrintParameters(
            string referenceNumber,
            DateTime transactionDate,
            string customerNumber,
            string receiverName,
            string senderName,
            string sendingBranch,
            string payoutBranch,
            string branchUserID,
            decimal principalAmount,
            decimal serviceCharge,
            decimal discountAmount,
            string branchOperatingHours)
        {
            _referenceNumber = ReferenceNumber;
            _transactionDate = transactionDate;
            _customerNumber = customerNumber;
            _receiverName = receiverName;
            _senderName = senderName;
            _sendingBranch = sendingBranch;
            _payoutBranch = payoutBranch;
            _branchUserID = branchUserID;
            _principalAmount = principalAmount;
            _serviceCharge = serviceCharge;
            _discountAmount = discountAmount;
        }

        internal PrintParameters() : this(null, DateTime.MinValue, null, null, null, null, null, null, decimal.Zero, decimal.Zero, decimal.Zero, string.Empty)
        {}
        
        #endregion

        #region Fields

        private string _referenceNumber;
		private string _payoutID;
        private DateTime _transactionDate;
        private string _customerNumber;
        private string _receiverName;
        private string _senderName;
        private string _sendingBranch;
        private string _payoutBranch;
        private string _branchUserID;
        private string _principalAmountCurrency;
        private decimal _principalAmount;
        private decimal _serviceCharge;
        private decimal _discountAmount;
        private string _branchOperatingHours;
        private string _marketingMessage;

        #endregion

        #region Properties

        internal string ReferenceNumber
        {
            get { return _referenceNumber; }
            set { _referenceNumber = value; }
        }

		internal string PayoutID
		{
			get { return _payoutID; }
			set { _payoutID = value; }
		}

        internal DateTime TransactionDate
        {
            get { return _transactionDate; }
            set { _transactionDate = value; }
        }

        internal string CustomerNumber
        {
            get { return _customerNumber; }
            set { _customerNumber = value; }
        }

        internal string ReceiverName
        {
            get { return _receiverName; }
            set { _receiverName = value; }
        }

        internal string SenderName
        {
            get { return _senderName; }
            set { _senderName = value; }
        }

        internal string SendingBranch
        {
            get { return _sendingBranch; }
            set { _sendingBranch = value; }
        }

        internal string PayoutBranch
        {
            get { return _payoutBranch; }
            set { _payoutBranch = value; }
        }

        internal string BranchUserID
        {
            get { return _branchUserID; }
            set { _branchUserID = value; }
        }

        public string PrincipalAmountCurrency
        {
            get { return _principalAmountCurrency; }
            set { _principalAmountCurrency = value; }
        }

        internal decimal PrincipalAmount
        {
            get { return _principalAmount; }
            set { _principalAmount = value; }
        }

        internal decimal ServiceCharge
        {
            get { return _serviceCharge; }
            set { _serviceCharge = value; }
        }

        internal decimal DiscountAmount
        {
            get { return _discountAmount; }
            set { _discountAmount = value; }
        }

        internal decimal TotalAmount
        {
            get { return _principalAmount - _serviceCharge - _discountAmount; }
        }

        public string BranchOperatingHours
        {
            get { return _branchOperatingHours; }
            set { _branchOperatingHours = value; }
        }

        public string MarketingMessage
        {
            get { return _marketingMessage; }
            set { _marketingMessage = value; }
        }
        #endregion
    }
}
