using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TransFastWCFService.Classes;

namespace ClientApplication
{
    public partial class TestWCF : Form
    {
        public TestWCF()
        {
            InitializeComponent();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            ProcessLookup();
        }

        private void ProcessLookup()
        {
            LookupTransactionRequest req = new LookupTransactionRequest();
            req.TransactionNumber = txtTransactionNumber.Text;
            //req.PayoutCurrency = txtPayoutCurrency.Text;

            //PullRemittanceRequest pullReq = new PullRemittanceRequest();
            //pullReq.LookupTransactionRequest = req;

            //WesternUnionWCFClient svc = new WesternUnionWCFClient();
            //PullRemittanceResult pullRes = new PullRemittanceResult();
            //pullRes = svc.RemittancePartnerLookup(pullReq);

            //LookupTransactionResult res = new LookupTransactionResult();
            //res = pullRes.LookupTransactionResult;

            //txtResultCode.Text = res.ResultCode.ToString();
            //txtResultMessage.Text = res.MessageToClient;
        }

        private void TestWCF_Load(object sender, EventArgs e)
        {
            TestTransFast testTransFast = new TestTransFast();
            testTransFast.Show();
        }
    }
}
