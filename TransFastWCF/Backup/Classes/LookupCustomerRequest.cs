using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WesterUnionWCF.Classes
{
    public class LookupCustomerRequest
    {
        #region Constructor

        public LookupCustomerRequest()
        {
        }

        #endregion

        #region Fields
        private string _accessCode;
        private string _userName;
        private string _refNo;
        private string _payTokenID;
        private string _signature;
        private string _agentSessionID;
        private string _token;
        private string _clientApplicationVersion;
        private string _partnerCode;

        #endregion

        #region Properties

        public string Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

        public string PayTokenID
        {
            get { return _payTokenID; }
            set { _payTokenID = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string AccessCode
        {
            get { return _accessCode; }
            set { _accessCode = value; }
        }
        public string RefNo
        {
            get { return _refNo; }
            set { _refNo = value; }
        }

        public string AgentSessionID
        {
            get { return _agentSessionID; }
            set { _agentSessionID = value; }
        }

        public string ClientApplicationVersion
        {
            get { return _clientApplicationVersion; }
            set { _clientApplicationVersion = value; }
        }

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        public string PartnerCode
        {
            get { return _partnerCode; }
            set { _partnerCode = value; }
        }

        #endregion
    }
}