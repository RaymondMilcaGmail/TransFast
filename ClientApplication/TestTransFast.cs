

using System;
using System.Windows.Forms;
using TransFastWCF.TransFastRespopnse;
using TransFastWCFService.Classes;
using TransFastWCFService;
using ClientApplication.ITransFastServices;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ClientApplication
{
    public partial class TestTransFast : Form
    {
        public TestTransFast()
        {
            InitializeComponent();
        }

        public string TransFastToken { get; set; }

        public LookupTransactionResult Savedres { get; set; }
        private void TestTransFast_Load(object sender, EventArgs e)
        {
            //DataTransactionResult req = new DataTransactionResult();
            //TransFastWCFClient svc = new TransFastWCFClient();

            //req = svc.RequestToken(req);
            //TokenResponse responseDetails = JsonConvert.DeserializeObject<TokenResponse>(req.StrResponse);
            //if (responseDetails == null)
            //{
            //    req.ResultCode = DataTransactionResultCode.PartnerError;
            //    req.MessageToClient = "Failed to retrieve token from client.";
            //}
            //else
            //{
            //    TransFastToken = responseDetails.ReturnToken;

            //}
        }


        private void button5_Click(object sender, EventArgs e)
        {

            DataTransactionResult res = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();

            res = svc.RequestToken(res);

            if (res.ResultCode!=DataTransactionResultCode.Successful)
            {
                res.ResultCode = DataTransactionResultCode.PartnerError;
                res.MessageToClient = "Failed to retrieve token from client.";

            }
            else
            {
                TokenResponse responseDetails = JsonConvert.DeserializeObject<TokenResponse>(res.StrResponse);
                if (responseDetails.ReturnCode == 0)
                {

                    TransFastToken = responseDetails.ReturnToken;
                    TxtToken.Text = TransFastToken;
                }

            }
            txtErrorcode.Text = res.ResultCode.ToString();
            txtErrorDesc.Text = res.MessageToClient;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (Savedres.InvoiceUpdateID != 0)
            {
                CebuanaBranchInformation branch = new CebuanaBranchInformation();
                branch.BranchCode = "1";
                branch.BranchUserID = "1";
                PullRemittanceRequest req = new PullRemittanceRequest();
                TransFastWCFClient svc = new TransFastWCFClient();
                PayoutTransactionRequest preq = new PayoutTransactionRequest();
                preq.AssignToken = TransFastToken;
                //preq.FunctionName = "UpdateTransaction";
                preq.ReferenceID = Savedres.InvoiceUpdateID;
                preq.EventDate = new DateTime();
                preq.EventType = "2";
                preq.EventInfo = TxtToken.Text;
                preq.CebuanaBranchInformation = branch;
                preq.PayoutID = Savedres.PayoutID;
                preq.TransactionNumber = Savedres.TransactionNumber;
                preq.PayoutAmount = Savedres.PayoutAmount;
                preq.PayoutCurrency = Savedres.PayoutCurrency;
                preq.ReceiverCustomerNumber = "123456";

                preq.InvoiceStatus = Savedres.InvoiceStatus;
                //preq.InvoiceStatus = Savedres.InvoiceStatus;
                preq.SenderFullName = Savedres.SenderFullName;
                preq.SenderFirstName = Savedres.SenderFirstName;
                preq.SenderLastName = Savedres.SenderLastName;

                preq.ReceiverFullName = Savedres.BeneficiaryFullName;
                preq.ReceiverLastName = Savedres.BeneficiaryLastName;
                preq.ReceiverFirstName = Savedres.BeneficiaryFirstName;
                preq.ReceiverIDType = "ID008";
                preq.ReceiverIDNumber = "123456";
                preq.SenderCountry = Savedres.SenderCountry;
                preq.SenderState = Savedres.SenderState;
                preq.SenderEmail = Savedres.SenderEmail;
                preq.SenderMobileNumber = Savedres.SenderMobileNumber;

                preq.CurrencyConversionRate = 48.52M;
                req.PayoutTransactionRequest = preq;
                PullRemittanceResult TransactionResult = svc.RemittancePartnerPayout(req);

                txtErrorcode.Text = TransactionResult.PayoutTransactionResult.ResultCode.ToString();
                txtErrorDesc.Text = TransactionResult.PayoutTransactionResult.MessageToClient;
                EnumHelper.GetEnumDescription((InvoiceStatusCode)Savedres.InvoiceStatus);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            LookupTransactionRequest req = new LookupTransactionRequest();
            req.TransactionNumber = txtReferralNo.Text;
            req.PayoutCurrency = "PHP";
            req.AssignToken = TxtToken.Text;

            PullRemittanceRequest pullReq = new PullRemittanceRequest();
            pullReq.LookupTransactionRequest = req;

            TransFastWCFClient svc = new TransFastWCFClient();
            PullRemittanceResult pullRes = new PullRemittanceResult();
            pullRes = svc.RemittancePartnerLookup(pullReq);

            Savedres = pullRes.LookupTransactionResult;

            lblSender.Text = Savedres.SenderFullName;
            lblReceiver.Text = Savedres.BeneficiaryFullName;
            lblAmount.Text = Savedres.PayoutAmount.ToString();
            lblCurrency.Text = Savedres.PayoutCurrency;
            lblStatus.Text = string.Format("{0} - {1}", Savedres.InvoiceStatus, EnumHelper.GetEnumDescription((InvoiceStatusCode)Savedres.InvoiceStatus));
            txtErrorcode.Text = Savedres.ResultCode.ToString();
            txtErrorDesc.Text = Savedres.MessageToClient;
        }


    }
}
