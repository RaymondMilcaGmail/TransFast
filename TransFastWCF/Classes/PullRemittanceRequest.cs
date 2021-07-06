using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services.Protocols;
using System.Net;

namespace TransFastWCFService.Classes
{
    public class PullRemittanceRequest
    {
        private string _pullMethod;

        public string PullMethod
        {
            get { return _pullMethod; }
            set { _pullMethod = value; }
        }

        public LookupTransactionRequest LookupTransactionRequest { get; set; }
        public PayoutTransactionRequest PayoutTransactionRequest { get; set; }
        public UnlockTransactionRequest UnlockTransactionRequest { get; set; }
    }
}