using System;
using SpeedRemitControlLibrary.SpeedRemitWebReference;

namespace SpeedRemitControlLibrary
{
    class LookupEventArgs : EventArgs
    {
        internal LookupEventArgs(LookupTransactionResult lookupTransactionResult)
        {
        }

        //internal LookupEventArgs()
        //    : base()
        //{}

        private LookupTransactionResult _lookupTransactionResult;

        public LookupTransactionResult LookupTransactionResult
        {
            get { return _lookupTransactionResult; }
            set { _lookupTransactionResult = value; }
        }

    }
}
