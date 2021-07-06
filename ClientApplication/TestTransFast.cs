using ClientApplication.TransFastWCFServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransFastWCFService.Classes;
using TransFastWCF.TransFastRespopnse;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            req.Functionname = "GetAvaliableFiles";
            string TransactionResult = svc.ProcessTransaction(req);
            GetAvaliableFilesResponse responseDetails = JsonConvert.DeserializeObject<GetAvaliableFilesResponse>(TransactionResult);
            foreach (AvaliableFIle avaliableFIle in responseDetails.AvaliableFIles)
            {

                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(avaliableFIle.FileName);
                lvi.SubItems.Add(avaliableFIle.FileSize);
                lvi.SubItems.Add(avaliableFIle.FileDate);
                listView1.Items.Add(lvi);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            req.Functionname = "UpdateTransaction";
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
            req.Functionname = "GetFile";
            req.FileName = listView1.SelectedItems[0].SubItems[1].ToString();
            string TransactionResult = svc.ProcessTransaction(req);
            GetFileResponse responseDetails = JsonConvert.DeserializeObject<GetFileResponse>(TransactionResult);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataTransactionResult req = new DataTransactionResult();
            TransFastWCFClient svc = new TransFastWCFClient();
            req.Functionname = "CommitFile";
            req.FileName = listView1.SelectedItems[0].SubItems[1].ToString();
            string TransactionResult = svc.ProcessTransaction(req);
            CommitFileResponse responseDetails = JsonConvert.DeserializeObject<CommitFileResponse>(TransactionResult);

        }
    }
}
