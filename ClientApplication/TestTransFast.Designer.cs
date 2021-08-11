
namespace ClientApplication
{
    partial class TestTransFast
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button5 = new System.Windows.Forms.Button();
            this.TxtToken = new System.Windows.Forms.TextBox();
            this.txtReferralNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.lblSender = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtErrorDesc = new System.Windows.Forms.TextBox();
            this.txtErrorcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(21, -1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(136, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "GetToken";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TxtToken
            // 
            this.TxtToken.Location = new System.Drawing.Point(21, 28);
            this.TxtToken.Name = "TxtToken";
            this.TxtToken.Size = new System.Drawing.Size(136, 20);
            this.TxtToken.TabIndex = 15;
            // 
            // txtReferralNo
            // 
            this.txtReferralNo.Location = new System.Drawing.Point(140, 17);
            this.txtReferralNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtReferralNo.Name = "txtReferralNo";
            this.txtReferralNo.Size = new System.Drawing.Size(146, 20);
            this.txtReferralNo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Reference No.";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(290, 16);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 24);
            this.button6.TabIndex = 15;
            this.button6.Text = "View Trnsaction";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.lblCurrency);
            this.groupBox2.Controls.Add(this.lblAmount);
            this.groupBox2.Controls.Add(this.lblReceiver);
            this.groupBox2.Controls.Add(this.lblSender);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtReferralNo);
            this.groupBox2.Location = new System.Drawing.Point(20, 56);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(400, 191);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Remittance";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 91);
            this.button2.TabIndex = 20;
            this.button2.Text = "Payout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(137, 124);
            this.lblCurrency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(49, 13);
            this.lblCurrency.TabIndex = 25;
            this.lblCurrency.Text = "Currency";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(137, 101);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 24;
            this.lblAmount.Text = "Amount";
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(137, 74);
            this.lblReceiver.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(50, 13);
            this.lblReceiver.TabIndex = 23;
            this.lblReceiver.Text = "Receiver";
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Location = new System.Drawing.Point(137, 48);
            this.lblSender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(41, 13);
            this.lblSender.TabIndex = 22;
            this.lblSender.Text = "Sender";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Currency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 99);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Receiver";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Result";
            // 
            // txtErrorDesc
            // 
            this.txtErrorDesc.Location = new System.Drawing.Point(365, 12);
            this.txtErrorDesc.Name = "txtErrorDesc";
            this.txtErrorDesc.Size = new System.Drawing.Size(212, 20);
            this.txtErrorDesc.TabIndex = 27;
            // 
            // txtErrorcode
            // 
            this.txtErrorcode.Location = new System.Drawing.Point(251, 12);
            this.txtErrorcode.Name = "txtErrorcode";
            this.txtErrorcode.Size = new System.Drawing.Size(100, 20);
            this.txtErrorcode.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(140, 143);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 27;
            // 
            // TestTransFast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 264);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtErrorDesc);
            this.Controls.Add(this.txtErrorcode);
            this.Controls.Add(this.TxtToken);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button5);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestTransFast";
            this.Text = "TestTransFast";
            this.Load += new System.EventHandler(this.TestTransFast_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox TxtToken;
        private System.Windows.Forms.TextBox txtReferralNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtErrorDesc;
        private System.Windows.Forms.TextBox txtErrorcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
    }
}