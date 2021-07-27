

using System;
using System.Windows.Forms;
using TransFastWCF.TransFastRespopnse;
using TransFastWCFService.Classes;
using TransFastWCFService;
using ClientApplication.ITransFastServices;
using Newtonsoft.Json;

namespace ClientApplication
{
    public partial class TestTransFast : Form
    {
        public TestTransFast()
        {
            InitializeComponent();
        }

        public string TransFastToken { get; set; }
        private void TestTransFast_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();

            string TokenResult = svc.RequestToken(req);
            TokenResponse responseDetails = JsonConvert.DeserializeObject<TokenResponse>(TokenResult);

            TransFastToken = responseDetails.ReturnToken;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Text = "EventInfo (Reference ID)";
            }
            else
            {
                label1.Text = "EventInfo (Incident)";

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            req.FunctionName = "GetAvaliableFiles";
            req.AssignToken = TransFastToken;
            string TransactionResult = svc.ProcessTransaction(req);
            GetAvaliableFilesResponse responseDetails = JsonConvert.DeserializeObject<GetAvaliableFilesResponse>(TransactionResult);
            foreach (AvaliableFIle avaliableFIle in responseDetails.AvaliableFIles)
            {
                string[] row = { avaliableFIle.FileName, avaliableFIle.FileSize.ToString(), avaliableFIle.FileDate.ToString() };
                ListViewItem listViewItem = new ListViewItem(row);

                listView1.Items.Add(listViewItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            //TransFastWCFService svc = new TransFastWCFService();
            req.AssignToken = TransFastToken;
            req.FunctionName = "UpdateTransaction";
            req.ReferenceID = listView1.SelectedItems[0].SubItems[1].ToString();
            req.EventDate = new DateTime();
            req.EventType = checkBox1.Checked ? "1" : "0";
            req.EventInfo = textBox1.Text;
            string TransactionResult = svc.ProcessTransaction(req);
            UpdateTransactionResponse responseDetails = JsonConvert.DeserializeObject<UpdateTransactionResponse>(TransactionResult);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            req.AssignToken = TransFastToken;
            req.FunctionName = "GetFile";
            req.FileName = listView1.SelectedItems[0].SubItems[1].ToString();
            string TransactionResult = svc.ProcessTransaction(req);
            GetFileResponse responseDetails = JsonConvert.DeserializeObject<GetFileResponse>(TransactionResult);
            label2.Text = responseDetails.FileContents[0].SenderName;
            label3.Text = responseDetails.FileContents[0].ReceiverName;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            req.AssignToken = TransFastToken;
            req.FunctionName = "CommitFile";
            req.FileName = listView1.SelectedItems[0].SubItems[1].ToString();
            string TransactionResult = svc.ProcessTransaction(req);
            CommitFileResponse responseDetails = JsonConvert.DeserializeObject<CommitFileResponse>(TransactionResult);

        }
    }
}
