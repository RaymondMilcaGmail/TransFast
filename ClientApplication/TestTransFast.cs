

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
    public List<FileContent> FileContents { get; set; }
        private void TestTransFast_Load(object sender, EventArgs e)
        {
            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();

            string TokenResult = svc.RequestToken(req);
            TokenResponse responseDetails = JsonConvert.DeserializeObject<TokenResponse>(TokenResult);

            TransFastToken = responseDetails.ReturnToken;
        }


        private void button3_Click(object sender, EventArgs e)
        {

            DataTransactionResult res = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            res.AssignToken = TransFastToken;
            res.FunctionName = "CommitFile";
            res = svc.ProcessTransaction(res);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DataTransactionResult res = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            
            string TokenResult = svc.RequestToken(res);
            TokenResponse responseDetails = JsonConvert.DeserializeObject<TokenResponse>(TokenResult);

            TransFastToken = responseDetails.ReturnToken;
            TxtToken.Text = TransFastToken;
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

                txtRemitCode.Text = TransactionResult.PayoutTransactionResult.ResultCode.ToString();
                txtRemitCode.Text = TransactionResult.PayoutTransactionResult.MessageToClient;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //FileContent selected = FileContents.Where(x => x.InvoiceAgentReference == int.Parse(txtReferralNo.Text)).Select(x => new FileContent { SenderName = x.SenderName, ReceiverName = x.ReceiverName, InvoiceAmmountToPay = x.InvoiceAmmountToPay, InvoiceCurrency = x.InvoiceCurrency }).FirstOrDefault();
            //lblSender.Text = selected.SenderName;
            //lblReceiver.Text = selected.ReceiverName;
            //lblAmount.Text = selected.InvoiceAmmountToPay.ToString();
            //lblCurrency.Text = selected.InvoiceCurrency;


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

            txtErrorcode.Text = Savedres.ResultCode.ToString();
            txtErrorDesc.Text = Savedres.MessageToClient;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Savedres.InvoiceUpdateID != 0)
            {

                DataTransactionResult res = new DataTransactionResult();
                TransFastWCFClient svc = new TransFastWCFClient();
                //TransFastWCFService svc = new TransFastWCFService();
                res.AssignToken = TransFastToken;
                res.FunctionName = "UpdateTransactionMSG";
                res.ReferenceID = Savedres.InvoiceUpdateID;
                res.EventDate = new DateTime();
                res = svc.ProcessTransaction(res);
                UpdateTransactionResponse responseDetails = new UpdateTransactionResponse();
                responseDetails= JsonConvert.DeserializeObject<UpdateTransactionResponse>(res.Result);
                txtSendMessageCOde.Text = res.ResultCode.ToString();
                txtSendMessageDesc.Text = res.MessageToClient;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTransactionResult res = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            res.AssignToken = TransFastToken;
            res.FunctionName = "CommitFile";
            res.FileName = txtFileName.Text;
            res = svc.ProcessTransaction(res);
            CommitFileResponse responseDetails = JsonConvert.DeserializeObject<CommitFileResponse>(res.Result);

            textBox4.Text = res.Result;
            textBox3.Text = res.ResultCode.ToString();
            textBox2.Text = res.MessageToClient;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DataTransactionResult res = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            res.FunctionName = "GetAvaliableFiles";
            res.AssignToken = TransFastToken;
            res = svc.ProcessTransaction(res);
            GetAvaliableFilesResponse responseDetails = JsonConvert.DeserializeObject<GetAvaliableFilesResponse>(res.Result);
            if (responseDetails.AvaliableFIles.Count > 0)
            {

                txtFileName.Text = responseDetails.AvaliableFIles[0].FileName;
            }

            textBox4.Text = res.Result;
            textBox3.Text = res.ResultCode.ToString();
            textBox2.Text = res.MessageToClient;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            DataTransactionResult res = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            res.AssignToken = TransFastToken;
            res.FunctionName = "GetFile";
            res.FileName = txtFileName.Text;
            res = svc.ProcessTransaction(res);
            GetAvaliableFilesResponse responseDetails = JsonConvert.DeserializeObject<GetAvaliableFilesResponse>(res.Result);

            textBox4.Text = res.Result;
            textBox3.Text = res.ResultCode.ToString();
            textBox2.Text = res.MessageToClient;
        }
    }
}
