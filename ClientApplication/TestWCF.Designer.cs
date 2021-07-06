namespace ClientApplication
{
    partial class TestWCF
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
            this.btnLookup = new System.Windows.Forms.Button();
            this.txtTransactionNumber = new System.Windows.Forms.TextBox();
            this.txtPayoutCurrency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResultCode = new System.Windows.Forms.TextBox();
            this.txtResultMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(112, 81);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 23);
            this.btnLookup.TabIndex = 0;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // txtTransactionNumber
            // 
            this.txtTransactionNumber.Location = new System.Drawing.Point(128, 16);
            this.txtTransactionNumber.Name = "txtTransactionNumber";
            this.txtTransactionNumber.Size = new System.Drawing.Size(129, 20);
            this.txtTransactionNumber.TabIndex = 1;
            this.txtTransactionNumber.Text = "Test000001";
            // 
            // txtPayoutCurrency
            // 
            this.txtPayoutCurrency.Location = new System.Drawing.Point(128, 42);
            this.txtPayoutCurrency.Name = "txtPayoutCurrency";
            this.txtPayoutCurrency.Size = new System.Drawing.Size(129, 20);
            this.txtPayoutCurrency.TabIndex = 2;
            this.txtPayoutCurrency.Text = "PHP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Transaction Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Payout Currency:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Result Message:";
            // 
            // txtResultCode
            // 
            this.txtResultCode.Location = new System.Drawing.Point(128, 121);
            this.txtResultCode.Name = "txtResultCode";
            this.txtResultCode.Size = new System.Drawing.Size(129, 20);
            this.txtResultCode.TabIndex = 7;
            // 
            // txtResultMessage
            // 
            this.txtResultMessage.Location = new System.Drawing.Point(128, 147);
            this.txtResultMessage.Name = "txtResultMessage";
            this.txtResultMessage.Size = new System.Drawing.Size(129, 20);
            this.txtResultMessage.TabIndex = 8;
            // 
            // TestWCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtResultMessage);
            this.Controls.Add(this.txtResultCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPayoutCurrency);
            this.Controls.Add(this.txtTransactionNumber);
            this.Controls.Add(this.btnLookup);
            this.Name = "TestWCF";
            this.Text = "TestWCF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.TextBox txtTransactionNumber;
        private System.Windows.Forms.TextBox txtPayoutCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResultCode;
        private System.Windows.Forms.TextBox txtResultMessage;
    }
}