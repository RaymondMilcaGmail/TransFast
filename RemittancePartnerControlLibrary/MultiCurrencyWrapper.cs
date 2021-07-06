using System;
using CommonFunctions;

namespace TransFastControlLibrary
{
    internal class MultiCurrencyWrapper
    {
        #region Constructors

        internal MultiCurrencyWrapper(string currencyCode, decimal amount)
        {
            _currencyCode = currencyCode;
            _amount = amount;

            try
            {
#if DEBUG
                object[] multiCurrencyReturn = { true, "SUFFICIENT_FUND", 100000 };
                //object[] multiCurrencyReturn = { false, "Transaction cannot continue due to insufficient fund. ", -10 };
#else
                object[] multiCurrencyReturn = iClickDetails.CheckFund(currencyCode, amount);
#endif
                _isBalanceSufficient = Convert.ToBoolean(multiCurrencyReturn[0]);

                if (_isBalanceSufficient == true)
                {
                    _returnMessage = "This is a $$$ DOLLAR $$$ transaction. Are you sure you want to proceed?";
                }
                else
                {
                    if (Convert.ToString(multiCurrencyReturn[1]).Trim().ToUpper() == "TRANSACTION CANNOT CONTINUE DUE TO INSUFFICIENT FUND.")
                    {
                        _remainingAmount = Convert.ToDecimal(multiCurrencyReturn[2]);
                        if (_remainingAmount < 0)
                        {
                            _remainingAmount = amount + _remainingAmount;
                        }

                        _returnMessage = string.Format("This is a $$$ DOLLAR $$$ transaction amounting to ${0:N2}.  Your remaining US Dollar cash balance is ${1:N2}. Are you sure you want to proceed?",
                            amount,
                            _remainingAmount);
                    }
                    else
                    {
                        _returnMessage = string.Format("This is a $$$ DOLLAR $$$ transaction amounting to ${0}.  Please ensure you have sufficient cash balance to pay out this transaction. Are you sure you want to proceed?", amount);
                    }
                    
                }
            }
            catch
            {
                _isBalanceSufficient = false;
                _returnMessage = string.Format("This is a $$$ DOLLAR $$$ transaction amounting to ${0:N2}.  Please ensure you have sufficient cash balance to pay out this transaction. Are you sure you want to proceed?", amount);
            }
        }

        #endregion

        #region Fields

        private string _currencyCode;
        private decimal _amount;
        private bool _isBalanceSufficient;
        private string _returnMessage;
        private decimal _remainingAmount;

        #endregion

        #region Properties

        internal bool IsBalanceSufficient
        {
            get { return _isBalanceSufficient; }
        }

        internal string ReturnMessage
        {
            get { return _returnMessage; }
        }

        internal decimal RemainingAmount
        {
            get { return _remainingAmount; }
        }

        #endregion
    }
}
