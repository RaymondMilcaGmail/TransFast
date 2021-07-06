namespace TransFastControlLibrary
{
    partial class PayoutForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayoutForm));
            this.panelPayoutDetails = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadReferenceNumber = new System.Windows.Forms.Button();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optEmailAddress = new System.Windows.Forms.CheckBox();
            this.optMobileNumber = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPhoneCode = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPhoneCode = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboSendingState = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSendingCountry = new System.Windows.Forms.ComboBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.groupBoxPayoutTransactionDetails = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTransactionStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPayoutCountry = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPayoutCurrency = new System.Windows.Forms.Label();
            this.lblPayoutAmount = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblPayoutTransactionNumber = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBoxBeneficiaryDetails = new System.Windows.Forms.GroupBox();
            this.lblBeneficiaryName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitlePayoutDetails = new System.Windows.Forms.Label();
            this.backgroundWorkerRemittanceLookup = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRemittancePayout = new System.ComponentModel.BackgroundWorker();
            this.panelSelectedBeneficiaryDetailsMain = new System.Windows.Forms.Panel();
            this.groupBoxCustomerIdentification = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelCustomerIdentification = new System.Windows.Forms.Panel();
            this.mskCustomerIDExpiryDate = new System.Windows.Forms.MaskedTextBox();
            this.mskCustomerIDIssuedDate = new System.Windows.Forms.MaskedTextBox();
            this.cboCustomerIDSubmitted = new System.Windows.Forms.ComboBox();
            this.txtCustomerIDSubmittedNumber = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.groupBoxCustomerInformation = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCustomerNumber = new System.Windows.Forms.TextBox();
            this.panelSelectedBeneficiaryDetails = new System.Windows.Forms.Panel();
            this.lblCustomerLastName = new System.Windows.Forms.Label();
            this.lblCustomerMiddleName = new System.Windows.Forms.Label();
            this.lblCustomerFirstName = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.lblTitleCustomerDetails = new System.Windows.Forms.Label();
            this.panelPayoutProcessing = new System.Windows.Forms.Panel();
            this.groupBoxPayoutProcessing = new System.Windows.Forms.GroupBox();
            this.lblProcessingStatus = new System.Windows.Forms.Label();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnProcessPayout = new System.Windows.Forms.Button();
            this.lblTitlePayoutProcessing = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelPayoutDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxPayoutTransactionDetails.SuspendLayout();
            this.groupBoxBeneficiaryDetails.SuspendLayout();
            this.panelSelectedBeneficiaryDetailsMain.SuspendLayout();
            this.groupBoxCustomerIdentification.SuspendLayout();
            this.panelCustomerIdentification.SuspendLayout();
            this.groupBoxCustomerInformation.SuspendLayout();
            this.panelSelectedBeneficiaryDetails.SuspendLayout();
            this.panelPayoutProcessing.SuspendLayout();
            this.groupBoxPayoutProcessing.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPayoutDetails
            // 
            this.panelPayoutDetails.BackColor = System.Drawing.Color.White;
            this.panelPayoutDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPayoutDetails.Controls.Add(this.panel2);
            this.panelPayoutDetails.Controls.Add(this.groupBox1);
            this.panelPayoutDetails.Controls.Add(this.groupBoxPayoutTransactionDetails);
            this.panelPayoutDetails.Controls.Add(this.groupBoxBeneficiaryDetails);
            this.panelPayoutDetails.Controls.Add(this.lblTitlePayoutDetails);
            this.panelPayoutDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPayoutDetails.Location = new System.Drawing.Point(6, 60);
            this.panelPayoutDetails.Name = "panelPayoutDetails";
            this.panelPayoutDetails.Size = new System.Drawing.Size(399, 516);
            this.panelPayoutDetails.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnLoadReferenceNumber);
            this.panel2.Controls.Add(this.txtReferenceNumber);
            this.panel2.Location = new System.Drawing.Point(8, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 36);
            this.panel2.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(1);
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Reference Num:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLoadReferenceNumber
            // 
            this.btnLoadReferenceNumber.BackColor = System.Drawing.Color.Azure;
            this.btnLoadReferenceNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadReferenceNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadReferenceNumber.Location = new System.Drawing.Point(294, 4);
            this.btnLoadReferenceNumber.Name = "btnLoadReferenceNumber";
            this.btnLoadReferenceNumber.Size = new System.Drawing.Size(79, 25);
            this.btnLoadReferenceNumber.TabIndex = 1;
            this.btnLoadReferenceNumber.Text = "Load";
            this.btnLoadReferenceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadReferenceNumber.UseVisualStyleBackColor = false;
            this.btnLoadReferenceNumber.Click += new System.EventHandler(this.btnLoadReferenceNumber_Click);
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReferenceNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceNumber.Location = new System.Drawing.Point(134, 5);
            this.txtReferenceNumber.MaxLength = 25;
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(154, 21);
            this.txtReferenceNumber.TabIndex = 0;
            this.txtReferenceNumber.Text = "123456790123456";
            this.txtReferenceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.optEmailAddress);
            this.groupBox1.Controls.Add(this.optMobileNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboPhoneCode);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblPhoneCode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtMobileNumber);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboSendingState);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboSendingCountry);
            this.groupBox1.Controls.Add(this.txtEmailAddress);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblSenderName);
            this.groupBox1.Location = new System.Drawing.Point(7, 273);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(386, 172);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sender Details";
            // 
            // optEmailAddress
            // 
            this.optEmailAddress.AutoSize = true;
            this.optEmailAddress.Location = new System.Drawing.Point(136, 96);
            this.optEmailAddress.Name = "optEmailAddress";
            this.optEmailAddress.Size = new System.Drawing.Size(15, 14);
            this.optEmailAddress.TabIndex = 28;
            this.optEmailAddress.UseVisualStyleBackColor = true;
            this.optEmailAddress.CheckedChanged += new System.EventHandler(this.optEmailAddress_CheckedChanged);
            // 
            // optMobileNumber
            // 
            this.optMobileNumber.AutoSize = true;
            this.optMobileNumber.Location = new System.Drawing.Point(136, 118);
            this.optMobileNumber.Name = "optMobileNumber";
            this.optMobileNumber.Size = new System.Drawing.Size(15, 14);
            this.optMobileNumber.TabIndex = 27;
            this.optMobileNumber.UseVisualStyleBackColor = true;
            this.optMobileNumber.CheckedChanged += new System.EventHandler(this.optMobileNumber_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(1);
            this.label1.Size = new System.Drawing.Size(133, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mobile Number:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboPhoneCode
            // 
            this.cboPhoneCode.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboPhoneCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhoneCode.FormattingEnabled = true;
            this.cboPhoneCode.Location = new System.Drawing.Point(157, 115);
            this.cboPhoneCode.MaxDropDownItems = 15;
            this.cboPhoneCode.Name = "cboPhoneCode";
            this.cboPhoneCode.Size = new System.Drawing.Size(218, 21);
            this.cboPhoneCode.TabIndex = 25;
            this.cboPhoneCode.SelectedIndexChanged += new System.EventHandler(this.cboPhoneCode_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(2, 117);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(1);
            this.label13.Size = new System.Drawing.Size(133, 19);
            this.label13.TabIndex = 8;
            this.label13.Text = "Country Phone Code:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPhoneCode
            // 
            this.lblPhoneCode.BackColor = System.Drawing.Color.GhostWhite;
            this.lblPhoneCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPhoneCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneCode.Location = new System.Drawing.Point(136, 137);
            this.lblPhoneCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblPhoneCode.Name = "lblPhoneCode";
            this.lblPhoneCode.Padding = new System.Windows.Forms.Padding(1);
            this.lblPhoneCode.Size = new System.Drawing.Size(37, 21);
            this.lblPhoneCode.TabIndex = 24;
            this.lblPhoneCode.Text = "123";
            this.lblPhoneCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 93);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(1);
            this.label11.Size = new System.Drawing.Size(115, 19);
            this.label11.TabIndex = 7;
            this.label11.Text = "Email Address:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.BackColor = System.Drawing.Color.GhostWhite;
            this.txtMobileNumber.Location = new System.Drawing.Point(176, 137);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(199, 21);
            this.txtMobileNumber.TabIndex = 23;
            this.txtMobileNumber.Text = "Mobile Number";
            this.txtMobileNumber.TextChanged += new System.EventHandler(this.txtMobileNumber_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 71);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(1);
            this.label10.Size = new System.Drawing.Size(115, 19);
            this.label10.TabIndex = 6;
            this.label10.Text = "Sending State:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSendingState
            // 
            this.cboSendingState.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboSendingState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendingState.FormattingEnabled = true;
            this.cboSendingState.Location = new System.Drawing.Point(136, 71);
            this.cboSendingState.MaxDropDownItems = 15;
            this.cboSendingState.Name = "cboSendingState";
            this.cboSendingState.Size = new System.Drawing.Size(239, 21);
            this.cboSendingState.TabIndex = 21;
            this.cboSendingState.SelectedIndexChanged += new System.EventHandler(this.cboSendingState_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(1);
            this.label9.Size = new System.Drawing.Size(115, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Sending Country:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSendingCountry
            // 
            this.cboSendingCountry.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboSendingCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendingCountry.FormattingEnabled = true;
            this.cboSendingCountry.Location = new System.Drawing.Point(136, 49);
            this.cboSendingCountry.MaxDropDownItems = 15;
            this.cboSendingCountry.Name = "cboSendingCountry";
            this.cboSendingCountry.Size = new System.Drawing.Size(239, 21);
            this.cboSendingCountry.TabIndex = 19;
            this.cboSendingCountry.SelectedIndexChanged += new System.EventHandler(this.cboSendingCountry_SelectedIndexChanged);
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.BackColor = System.Drawing.Color.GhostWhite;
            this.txtEmailAddress.Location = new System.Drawing.Point(157, 93);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(218, 21);
            this.txtEmailAddress.TabIndex = 20;
            this.txtEmailAddress.Text = "email@address";
            this.txtEmailAddress.TextChanged += new System.EventHandler(this.txtEmailAddress_TextChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(83, 24);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(1);
            this.label12.Size = new System.Drawing.Size(52, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Name:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSenderName
            // 
            this.lblSenderName.BackColor = System.Drawing.Color.GhostWhite;
            this.lblSenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSenderName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderName.Location = new System.Drawing.Point(136, 16);
            this.lblSenderName.Margin = new System.Windows.Forms.Padding(0);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Padding = new System.Windows.Forms.Padding(1);
            this.lblSenderName.Size = new System.Drawing.Size(239, 32);
            this.lblSenderName.TabIndex = 18;
            this.lblSenderName.Text = "Sender Name";
            this.lblSenderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxPayoutTransactionDetails
            // 
            this.groupBoxPayoutTransactionDetails.BackColor = System.Drawing.Color.White;
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.lblMessage);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.label8);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.lblTransactionStatus);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.label7);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.lblPayoutCountry);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.label6);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.lblTransactionDate);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.label4);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.lblPayoutCurrency);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.lblPayoutAmount);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.label27);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.lblPayoutTransactionNumber);
            this.groupBoxPayoutTransactionDetails.Controls.Add(this.label23);
            this.groupBoxPayoutTransactionDetails.Location = new System.Drawing.Point(7, 74);
            this.groupBoxPayoutTransactionDetails.Name = "groupBoxPayoutTransactionDetails";
            this.groupBoxPayoutTransactionDetails.Size = new System.Drawing.Size(386, 195);
            this.groupBoxPayoutTransactionDetails.TabIndex = 103;
            this.groupBoxPayoutTransactionDetails.TabStop = false;
            this.groupBoxPayoutTransactionDetails.Text = "Payout Transaction Details";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.BackColor = System.Drawing.Color.GhostWhite;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(136, 138);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(1);
            this.lblMessage.Size = new System.Drawing.Size(239, 49);
            this.lblMessage.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 144);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(1);
            this.label8.Size = new System.Drawing.Size(106, 15);
            this.label8.TabIndex = 108;
            this.label8.Text = "Message:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTransactionStatus
            // 
            this.lblTransactionStatus.BackColor = System.Drawing.Color.GhostWhite;
            this.lblTransactionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionStatus.Location = new System.Drawing.Point(136, 58);
            this.lblTransactionStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblTransactionStatus.Name = "lblTransactionStatus";
            this.lblTransactionStatus.Padding = new System.Windows.Forms.Padding(1);
            this.lblTransactionStatus.Size = new System.Drawing.Size(239, 19);
            this.lblTransactionStatus.TabIndex = 24;
            this.lblTransactionStatus.Text = "Transaction Status";
            this.lblTransactionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(1);
            this.label7.Size = new System.Drawing.Size(121, 15);
            this.label7.TabIndex = 107;
            this.label7.Text = "Transaction Status:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayoutCountry
            // 
            this.lblPayoutCountry.BackColor = System.Drawing.Color.GhostWhite;
            this.lblPayoutCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPayoutCountry.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayoutCountry.Location = new System.Drawing.Point(136, 118);
            this.lblPayoutCountry.Margin = new System.Windows.Forms.Padding(0);
            this.lblPayoutCountry.Name = "lblPayoutCountry";
            this.lblPayoutCountry.Padding = new System.Windows.Forms.Padding(1);
            this.lblPayoutCountry.Size = new System.Drawing.Size(239, 19);
            this.lblPayoutCountry.TabIndex = 23;
            this.lblPayoutCountry.Text = "Payout Country";
            this.lblPayoutCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(1);
            this.label6.Size = new System.Drawing.Size(118, 15);
            this.label6.TabIndex = 106;
            this.label6.Text = "Transaction Date:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.BackColor = System.Drawing.Color.GhostWhite;
            this.lblTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionDate.Location = new System.Drawing.Point(136, 38);
            this.lblTransactionDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Padding = new System.Windows.Forms.Padding(1);
            this.lblTransactionDate.Size = new System.Drawing.Size(239, 19);
            this.lblTransactionDate.TabIndex = 25;
            this.lblTransactionDate.Text = "Transaction Date";
            this.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(1);
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 105;
            this.label4.Text = "Payout Country:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayoutCurrency
            // 
            this.lblPayoutCurrency.BackColor = System.Drawing.Color.LightSalmon;
            this.lblPayoutCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPayoutCurrency.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayoutCurrency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPayoutCurrency.Location = new System.Drawing.Point(136, 79);
            this.lblPayoutCurrency.Margin = new System.Windows.Forms.Padding(0);
            this.lblPayoutCurrency.Name = "lblPayoutCurrency";
            this.lblPayoutCurrency.Padding = new System.Windows.Forms.Padding(1);
            this.lblPayoutCurrency.Size = new System.Drawing.Size(58, 37);
            this.lblPayoutCurrency.TabIndex = 22;
            this.lblPayoutCurrency.Text = "USD";
            this.lblPayoutCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPayoutAmount
            // 
            this.lblPayoutAmount.BackColor = System.Drawing.Color.GhostWhite;
            this.lblPayoutAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPayoutAmount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayoutAmount.Location = new System.Drawing.Point(195, 79);
            this.lblPayoutAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblPayoutAmount.Name = "lblPayoutAmount";
            this.lblPayoutAmount.Padding = new System.Windows.Forms.Padding(1);
            this.lblPayoutAmount.Size = new System.Drawing.Size(180, 37);
            this.lblPayoutAmount.TabIndex = 20;
            this.lblPayoutAmount.Text = "50,000.00";
            this.lblPayoutAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(29, 20);
            this.label27.Margin = new System.Windows.Forms.Padding(1);
            this.label27.Name = "label27";
            this.label27.Padding = new System.Windows.Forms.Padding(1);
            this.label27.Size = new System.Drawing.Size(106, 15);
            this.label27.TabIndex = 46;
            this.label27.Text = "Transaction #:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayoutTransactionNumber
            // 
            this.lblPayoutTransactionNumber.BackColor = System.Drawing.Color.GhostWhite;
            this.lblPayoutTransactionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPayoutTransactionNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayoutTransactionNumber.Location = new System.Drawing.Point(136, 18);
            this.lblPayoutTransactionNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblPayoutTransactionNumber.Name = "lblPayoutTransactionNumber";
            this.lblPayoutTransactionNumber.Padding = new System.Windows.Forms.Padding(1);
            this.lblPayoutTransactionNumber.Size = new System.Drawing.Size(239, 19);
            this.lblPayoutTransactionNumber.TabIndex = 19;
            this.lblPayoutTransactionNumber.Text = "Transaction Number";
            this.lblPayoutTransactionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(29, 91);
            this.label23.Margin = new System.Windows.Forms.Padding(1);
            this.label23.Name = "label23";
            this.label23.Padding = new System.Windows.Forms.Padding(1);
            this.label23.Size = new System.Drawing.Size(106, 15);
            this.label23.TabIndex = 38;
            this.label23.Text = "Payout Amount:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxBeneficiaryDetails
            // 
            this.groupBoxBeneficiaryDetails.BackColor = System.Drawing.Color.White;
            this.groupBoxBeneficiaryDetails.Controls.Add(this.lblBeneficiaryName);
            this.groupBoxBeneficiaryDetails.Controls.Add(this.label3);
            this.groupBoxBeneficiaryDetails.Location = new System.Drawing.Point(7, 447);
            this.groupBoxBeneficiaryDetails.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxBeneficiaryDetails.Name = "groupBoxBeneficiaryDetails";
            this.groupBoxBeneficiaryDetails.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxBeneficiaryDetails.Size = new System.Drawing.Size(386, 59);
            this.groupBoxBeneficiaryDetails.TabIndex = 1;
            this.groupBoxBeneficiaryDetails.TabStop = false;
            this.groupBoxBeneficiaryDetails.Text = "Beneficiary Details";
            // 
            // lblBeneficiaryName
            // 
            this.lblBeneficiaryName.BackColor = System.Drawing.Color.GhostWhite;
            this.lblBeneficiaryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBeneficiaryName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaryName.Location = new System.Drawing.Point(136, 18);
            this.lblBeneficiaryName.Margin = new System.Windows.Forms.Padding(0);
            this.lblBeneficiaryName.Name = "lblBeneficiaryName";
            this.lblBeneficiaryName.Padding = new System.Windows.Forms.Padding(1);
            this.lblBeneficiaryName.Size = new System.Drawing.Size(239, 32);
            this.lblBeneficiaryName.TabIndex = 18;
            this.lblBeneficiaryName.Text = "Beneficiary Name";
            this.lblBeneficiaryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(1);
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitlePayoutDetails
            // 
            this.lblTitlePayoutDetails.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTitlePayoutDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitlePayoutDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlePayoutDetails.ForeColor = System.Drawing.Color.White;
            this.lblTitlePayoutDetails.Location = new System.Drawing.Point(0, 0);
            this.lblTitlePayoutDetails.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitlePayoutDetails.Name = "lblTitlePayoutDetails";
            this.lblTitlePayoutDetails.Size = new System.Drawing.Size(397, 24);
            this.lblTitlePayoutDetails.TabIndex = 0;
            this.lblTitlePayoutDetails.Text = "Payout Details";
            this.lblTitlePayoutDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorkerRemittanceLookup
            // 
            this.backgroundWorkerRemittanceLookup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRemittanceLookup_DoWork);
            this.backgroundWorkerRemittanceLookup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRemittanceLookup_RunWorkerCompleted);
            // 
            // backgroundWorkerRemittancePayout
            // 
            this.backgroundWorkerRemittancePayout.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRemittancePayout_DoWork);
            this.backgroundWorkerRemittancePayout.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRemittancePayout_RunWorkerCompleted);
            // 
            // panelSelectedBeneficiaryDetailsMain
            // 
            this.panelSelectedBeneficiaryDetailsMain.BackColor = System.Drawing.Color.White;
            this.panelSelectedBeneficiaryDetailsMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelectedBeneficiaryDetailsMain.Controls.Add(this.groupBoxCustomerIdentification);
            this.panelSelectedBeneficiaryDetailsMain.Controls.Add(this.groupBoxCustomerInformation);
            this.panelSelectedBeneficiaryDetailsMain.Controls.Add(this.lblTitleCustomerDetails);
            this.panelSelectedBeneficiaryDetailsMain.Location = new System.Drawing.Point(411, 60);
            this.panelSelectedBeneficiaryDetailsMain.Name = "panelSelectedBeneficiaryDetailsMain";
            this.panelSelectedBeneficiaryDetailsMain.Size = new System.Drawing.Size(399, 310);
            this.panelSelectedBeneficiaryDetailsMain.TabIndex = 105;
            // 
            // groupBoxCustomerIdentification
            // 
            this.groupBoxCustomerIdentification.BackColor = System.Drawing.Color.White;
            this.groupBoxCustomerIdentification.Controls.Add(this.label14);
            this.groupBoxCustomerIdentification.Controls.Add(this.label5);
            this.groupBoxCustomerIdentification.Controls.Add(this.panelCustomerIdentification);
            this.groupBoxCustomerIdentification.Controls.Add(this.label29);
            this.groupBoxCustomerIdentification.Controls.Add(this.label54);
            this.groupBoxCustomerIdentification.Location = new System.Drawing.Point(7, 150);
            this.groupBoxCustomerIdentification.Name = "groupBoxCustomerIdentification";
            this.groupBoxCustomerIdentification.Size = new System.Drawing.Size(386, 155);
            this.groupBoxCustomerIdentification.TabIndex = 109;
            this.groupBoxCustomerIdentification.TabStop = false;
            this.groupBoxCustomerIdentification.Text = "Customer Identification";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 104);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(1);
            this.label14.Size = new System.Drawing.Size(106, 29);
            this.label14.TabIndex = 112;
            this.label14.Text = "Expiry Date: [MM-DD-YYYY]";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(1);
            this.label5.Size = new System.Drawing.Size(106, 35);
            this.label5.TabIndex = 111;
            this.label5.Text = "Issued Date:  [MM-DD-YYYY]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelCustomerIdentification
            // 
            this.panelCustomerIdentification.Controls.Add(this.mskCustomerIDExpiryDate);
            this.panelCustomerIdentification.Controls.Add(this.mskCustomerIDIssuedDate);
            this.panelCustomerIdentification.Controls.Add(this.cboCustomerIDSubmitted);
            this.panelCustomerIdentification.Controls.Add(this.txtCustomerIDSubmittedNumber);
            this.panelCustomerIdentification.Location = new System.Drawing.Point(129, 15);
            this.panelCustomerIdentification.Name = "panelCustomerIdentification";
            this.panelCustomerIdentification.Size = new System.Drawing.Size(249, 123);
            this.panelCustomerIdentification.TabIndex = 110;
            // 
            // mskCustomerIDExpiryDate
            // 
            this.mskCustomerIDExpiryDate.BackColor = System.Drawing.Color.GhostWhite;
            this.mskCustomerIDExpiryDate.Location = new System.Drawing.Point(7, 92);
            this.mskCustomerIDExpiryDate.Mask = "00/00/0000";
            this.mskCustomerIDExpiryDate.Name = "mskCustomerIDExpiryDate";
            this.mskCustomerIDExpiryDate.Size = new System.Drawing.Size(237, 21);
            this.mskCustomerIDExpiryDate.TabIndex = 7;
            this.mskCustomerIDExpiryDate.ValidatingType = typeof(System.DateTime);
            this.mskCustomerIDExpiryDate.TextChanged += new System.EventHandler(this.mskCustomerIDExpiryDate_TextChanged);
            // 
            // mskCustomerIDIssuedDate
            // 
            this.mskCustomerIDIssuedDate.BackColor = System.Drawing.Color.GhostWhite;
            this.mskCustomerIDIssuedDate.Location = new System.Drawing.Point(7, 63);
            this.mskCustomerIDIssuedDate.Mask = "00/00/0000";
            this.mskCustomerIDIssuedDate.Name = "mskCustomerIDIssuedDate";
            this.mskCustomerIDIssuedDate.Size = new System.Drawing.Size(237, 21);
            this.mskCustomerIDIssuedDate.TabIndex = 6;
            this.mskCustomerIDIssuedDate.ValidatingType = typeof(System.DateTime);
            this.mskCustomerIDIssuedDate.TextChanged += new System.EventHandler(this.mskCustomerIDIssuedDate_TextChanged);
            // 
            // cboCustomerIDSubmitted
            // 
            this.cboCustomerIDSubmitted.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboCustomerIDSubmitted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerIDSubmitted.FormattingEnabled = true;
            this.cboCustomerIDSubmitted.Location = new System.Drawing.Point(7, 7);
            this.cboCustomerIDSubmitted.MaxDropDownItems = 15;
            this.cboCustomerIDSubmitted.Name = "cboCustomerIDSubmitted";
            this.cboCustomerIDSubmitted.Size = new System.Drawing.Size(239, 21);
            this.cboCustomerIDSubmitted.TabIndex = 4;
            this.cboCustomerIDSubmitted.SelectedIndexChanged += new System.EventHandler(this.cboCustomerIDSubmitted_SelectedIndexChanged);
            // 
            // txtCustomerIDSubmittedNumber
            // 
            this.txtCustomerIDSubmittedNumber.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCustomerIDSubmittedNumber.Location = new System.Drawing.Point(7, 34);
            this.txtCustomerIDSubmittedNumber.Name = "txtCustomerIDSubmittedNumber";
            this.txtCustomerIDSubmittedNumber.Size = new System.Drawing.Size(239, 21);
            this.txtCustomerIDSubmittedNumber.TabIndex = 5;
            this.txtCustomerIDSubmittedNumber.Text = "ID Number";
            this.txtCustomerIDSubmittedNumber.TextChanged += new System.EventHandler(this.txtCustomerIDSubmittedNumber_TextChanged);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(19, 24);
            this.label29.Margin = new System.Windows.Forms.Padding(1);
            this.label29.Name = "label29";
            this.label29.Padding = new System.Windows.Forms.Padding(1);
            this.label29.Size = new System.Drawing.Size(106, 15);
            this.label29.TabIndex = 109;
            this.label29.Text = "ID Submitted:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(19, 51);
            this.label54.Margin = new System.Windows.Forms.Padding(1);
            this.label54.Name = "label54";
            this.label54.Padding = new System.Windows.Forms.Padding(1);
            this.label54.Size = new System.Drawing.Size(106, 15);
            this.label54.TabIndex = 14;
            this.label54.Text = "ID Number:";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxCustomerInformation
            // 
            this.groupBoxCustomerInformation.BackColor = System.Drawing.Color.White;
            this.groupBoxCustomerInformation.Controls.Add(this.label22);
            this.groupBoxCustomerInformation.Controls.Add(this.txtCustomerNumber);
            this.groupBoxCustomerInformation.Controls.Add(this.panelSelectedBeneficiaryDetails);
            this.groupBoxCustomerInformation.Controls.Add(this.label71);
            this.groupBoxCustomerInformation.Controls.Add(this.label72);
            this.groupBoxCustomerInformation.Controls.Add(this.label73);
            this.groupBoxCustomerInformation.Location = new System.Drawing.Point(7, 32);
            this.groupBoxCustomerInformation.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxCustomerInformation.Name = "groupBoxCustomerInformation";
            this.groupBoxCustomerInformation.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxCustomerInformation.Size = new System.Drawing.Size(386, 114);
            this.groupBoxCustomerInformation.TabIndex = 1;
            this.groupBoxCustomerInformation.TabStop = false;
            this.groupBoxCustomerInformation.Text = "Customer Information";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(19, 16);
            this.label22.Margin = new System.Windows.Forms.Padding(1);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(1);
            this.label22.Size = new System.Drawing.Size(106, 15);
            this.label22.TabIndex = 105;
            this.label22.Text = "Customer Number:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCustomerNumber.Enabled = false;
            this.txtCustomerNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerNumber.Location = new System.Drawing.Point(136, 14);
            this.txtCustomerNumber.MaxLength = 12;
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(239, 21);
            this.txtCustomerNumber.TabIndex = 2;
            this.txtCustomerNumber.Text = "123456789012";
            this.txtCustomerNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelSelectedBeneficiaryDetails
            // 
            this.panelSelectedBeneficiaryDetails.BackColor = System.Drawing.Color.Transparent;
            this.panelSelectedBeneficiaryDetails.Controls.Add(this.lblCustomerLastName);
            this.panelSelectedBeneficiaryDetails.Controls.Add(this.lblCustomerMiddleName);
            this.panelSelectedBeneficiaryDetails.Controls.Add(this.lblCustomerFirstName);
            this.panelSelectedBeneficiaryDetails.Location = new System.Drawing.Point(129, 38);
            this.panelSelectedBeneficiaryDetails.Name = "panelSelectedBeneficiaryDetails";
            this.panelSelectedBeneficiaryDetails.Size = new System.Drawing.Size(249, 65);
            this.panelSelectedBeneficiaryDetails.TabIndex = 4;
            // 
            // lblCustomerLastName
            // 
            this.lblCustomerLastName.BackColor = System.Drawing.Color.GhostWhite;
            this.lblCustomerLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerLastName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerLastName.Location = new System.Drawing.Point(7, 2);
            this.lblCustomerLastName.Margin = new System.Windows.Forms.Padding(1);
            this.lblCustomerLastName.Name = "lblCustomerLastName";
            this.lblCustomerLastName.Padding = new System.Windows.Forms.Padding(1);
            this.lblCustomerLastName.Size = new System.Drawing.Size(239, 19);
            this.lblCustomerLastName.TabIndex = 18;
            this.lblCustomerLastName.Text = "Beneficiary Last Name";
            this.lblCustomerLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerMiddleName
            // 
            this.lblCustomerMiddleName.BackColor = System.Drawing.Color.GhostWhite;
            this.lblCustomerMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerMiddleName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerMiddleName.Location = new System.Drawing.Point(7, 42);
            this.lblCustomerMiddleName.Margin = new System.Windows.Forms.Padding(1);
            this.lblCustomerMiddleName.Name = "lblCustomerMiddleName";
            this.lblCustomerMiddleName.Padding = new System.Windows.Forms.Padding(1);
            this.lblCustomerMiddleName.Size = new System.Drawing.Size(239, 19);
            this.lblCustomerMiddleName.TabIndex = 20;
            this.lblCustomerMiddleName.Text = "Beneficiary Middle Name";
            this.lblCustomerMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerFirstName
            // 
            this.lblCustomerFirstName.BackColor = System.Drawing.Color.GhostWhite;
            this.lblCustomerFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerFirstName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerFirstName.Location = new System.Drawing.Point(7, 22);
            this.lblCustomerFirstName.Margin = new System.Windows.Forms.Padding(1);
            this.lblCustomerFirstName.Name = "lblCustomerFirstName";
            this.lblCustomerFirstName.Padding = new System.Windows.Forms.Padding(1);
            this.lblCustomerFirstName.Size = new System.Drawing.Size(239, 19);
            this.lblCustomerFirstName.TabIndex = 19;
            this.lblCustomerFirstName.Text = "Beneficiary First Name";
            this.lblCustomerFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(19, 81);
            this.label71.Margin = new System.Windows.Forms.Padding(1);
            this.label71.Name = "label71";
            this.label71.Padding = new System.Windows.Forms.Padding(1);
            this.label71.Size = new System.Drawing.Size(106, 16);
            this.label71.TabIndex = 5;
            this.label71.Text = "Middle Name:";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(19, 62);
            this.label72.Margin = new System.Windows.Forms.Padding(1);
            this.label72.Name = "label72";
            this.label72.Padding = new System.Windows.Forms.Padding(1);
            this.label72.Size = new System.Drawing.Size(106, 15);
            this.label72.TabIndex = 4;
            this.label72.Text = "First Name:";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(19, 42);
            this.label73.Margin = new System.Windows.Forms.Padding(1);
            this.label73.Name = "label73";
            this.label73.Padding = new System.Windows.Forms.Padding(1);
            this.label73.Size = new System.Drawing.Size(106, 14);
            this.label73.TabIndex = 0;
            this.label73.Text = "Last Name:";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleCustomerDetails
            // 
            this.lblTitleCustomerDetails.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTitleCustomerDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitleCustomerDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleCustomerDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleCustomerDetails.ForeColor = System.Drawing.Color.White;
            this.lblTitleCustomerDetails.Location = new System.Drawing.Point(0, 0);
            this.lblTitleCustomerDetails.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitleCustomerDetails.Name = "lblTitleCustomerDetails";
            this.lblTitleCustomerDetails.Size = new System.Drawing.Size(397, 24);
            this.lblTitleCustomerDetails.TabIndex = 0;
            this.lblTitleCustomerDetails.Text = "Customer Details";
            this.lblTitleCustomerDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPayoutProcessing
            // 
            this.panelPayoutProcessing.BackColor = System.Drawing.Color.White;
            this.panelPayoutProcessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPayoutProcessing.Controls.Add(this.groupBoxPayoutProcessing);
            this.panelPayoutProcessing.Controls.Add(this.lblTitlePayoutProcessing);
            this.panelPayoutProcessing.Location = new System.Drawing.Point(411, 376);
            this.panelPayoutProcessing.Name = "panelPayoutProcessing";
            this.panelPayoutProcessing.Size = new System.Drawing.Size(399, 162);
            this.panelPayoutProcessing.TabIndex = 106;
            // 
            // groupBoxPayoutProcessing
            // 
            this.groupBoxPayoutProcessing.BackColor = System.Drawing.Color.White;
            this.groupBoxPayoutProcessing.Controls.Add(this.lblProcessingStatus);
            this.groupBoxPayoutProcessing.Controls.Add(this.btnPrintReceipt);
            this.groupBoxPayoutProcessing.Controls.Add(this.btnClearAll);
            this.groupBoxPayoutProcessing.Controls.Add(this.btnProcessPayout);
            this.groupBoxPayoutProcessing.Location = new System.Drawing.Point(7, 25);
            this.groupBoxPayoutProcessing.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxPayoutProcessing.Name = "groupBoxPayoutProcessing";
            this.groupBoxPayoutProcessing.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxPayoutProcessing.Size = new System.Drawing.Size(387, 130);
            this.groupBoxPayoutProcessing.TabIndex = 1;
            this.groupBoxPayoutProcessing.TabStop = false;
            this.groupBoxPayoutProcessing.Text = "Processing";
            // 
            // lblProcessingStatus
            // 
            this.lblProcessingStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblProcessingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcessingStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessingStatus.Location = new System.Drawing.Point(18, 18);
            this.lblProcessingStatus.Margin = new System.Windows.Forms.Padding(1);
            this.lblProcessingStatus.Name = "lblProcessingStatus";
            this.lblProcessingStatus.Padding = new System.Windows.Forms.Padding(1);
            this.lblProcessingStatus.Size = new System.Drawing.Size(352, 33);
            this.lblProcessingStatus.TabIndex = 106;
            this.lblProcessingStatus.Text = "Processing Status";
            this.lblProcessingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.BackColor = System.Drawing.Color.White;
            this.btnPrintReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintReceipt.Location = new System.Drawing.Point(197, 52);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(173, 32);
            this.btnPrintReceipt.TabIndex = 7;
            this.btnPrintReceipt.Text = "Print Receipt";
            this.btnPrintReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.White;
            this.btnClearAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearAll.Location = new System.Drawing.Point(197, 87);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(174, 31);
            this.btnClearAll.TabIndex = 99;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnProcessPayout
            // 
            this.btnProcessPayout.BackColor = System.Drawing.Color.White;
            this.btnProcessPayout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessPayout.Location = new System.Drawing.Point(18, 52);
            this.btnProcessPayout.Name = "btnProcessPayout";
            this.btnProcessPayout.Size = new System.Drawing.Size(174, 32);
            this.btnProcessPayout.TabIndex = 6;
            this.btnProcessPayout.Text = "Process Payout";
            this.btnProcessPayout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessPayout.UseVisualStyleBackColor = false;
            this.btnProcessPayout.Click += new System.EventHandler(this.btnProcessPayout_Click);
            // 
            // lblTitlePayoutProcessing
            // 
            this.lblTitlePayoutProcessing.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTitlePayoutProcessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitlePayoutProcessing.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitlePayoutProcessing.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlePayoutProcessing.ForeColor = System.Drawing.Color.White;
            this.lblTitlePayoutProcessing.Location = new System.Drawing.Point(0, 0);
            this.lblTitlePayoutProcessing.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitlePayoutProcessing.Name = "lblTitlePayoutProcessing";
            this.lblTitlePayoutProcessing.Size = new System.Drawing.Size(397, 24);
            this.lblTitlePayoutProcessing.TabIndex = 0;
            this.lblTitlePayoutProcessing.Text = "Payout Processing";
            this.lblTitlePayoutProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(411, 545);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(299, 31);
            this.progressBar1.TabIndex = 107;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.Snow;
            this.btnCloseForm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(716, 545);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(95, 31);
            this.btnCloseForm.TabIndex = 100;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Image")));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(816, 57);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Payout";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.AutoPopDelay = 30000;
            this.toolTip.InitialDelay = 50;
            this.toolTip.ReshowDelay = 50;
            this.toolTip.ShowAlways = true;
            // 
            // PayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(816, 587);
            this.ControlBox = false;
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panelPayoutProcessing);
            this.Controls.Add(this.panelSelectedBeneficiaryDetailsMain);
            this.Controls.Add(this.panelPayoutDetails);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PayoutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Partner Payout";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PayoutForm_FormClosed);
            this.Load += new System.EventHandler(this.PayoutForm_Load);
            this.panelPayoutDetails.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxPayoutTransactionDetails.ResumeLayout(false);
            this.groupBoxBeneficiaryDetails.ResumeLayout(false);
            this.panelSelectedBeneficiaryDetailsMain.ResumeLayout(false);
            this.groupBoxCustomerIdentification.ResumeLayout(false);
            this.panelCustomerIdentification.ResumeLayout(false);
            this.panelCustomerIdentification.PerformLayout();
            this.groupBoxCustomerInformation.ResumeLayout(false);
            this.groupBoxCustomerInformation.PerformLayout();
            this.panelSelectedBeneficiaryDetails.ResumeLayout(false);
            this.panelPayoutProcessing.ResumeLayout(false);
            this.groupBoxPayoutProcessing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelPayoutDetails;
        private System.Windows.Forms.GroupBox groupBoxPayoutTransactionDetails;
        private System.Windows.Forms.Button btnLoadReferenceNumber;
        private System.Windows.Forms.Label lblPayoutCurrency;
        private System.Windows.Forms.Label lblPayoutAmount;
        private System.Windows.Forms.Label lblPayoutTransactionNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBoxBeneficiaryDetails;
        private System.Windows.Forms.Label lblBeneficiaryName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitlePayoutDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.Label label12;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRemittancePayout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPayoutCountry;
        private System.Windows.Forms.Panel panelSelectedBeneficiaryDetailsMain;
        private System.Windows.Forms.GroupBox groupBoxCustomerIdentification;
        private System.Windows.Forms.Panel panelCustomerIdentification;
        private System.Windows.Forms.TextBox txtCustomerIDSubmittedNumber;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBoxCustomerInformation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtCustomerNumber;
        private System.Windows.Forms.Panel panelSelectedBeneficiaryDetails;
        private System.Windows.Forms.Label lblCustomerLastName;
        private System.Windows.Forms.Label lblCustomerMiddleName;
        private System.Windows.Forms.Label lblCustomerFirstName;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label lblTitleCustomerDetails;
        private System.Windows.Forms.Panel panelPayoutProcessing;
        private System.Windows.Forms.GroupBox groupBoxPayoutProcessing;
        private System.Windows.Forms.Label lblProcessingStatus;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnProcessPayout;
        private System.Windows.Forms.Label lblTitlePayoutProcessing;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Label lblTransactionStatus;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ComboBox cboCustomerIDSubmitted;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox cboSendingCountry;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboSendingState;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPhoneCode;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox optMobileNumber;
        private System.Windows.Forms.CheckBox optEmailAddress;
        public System.ComponentModel.BackgroundWorker backgroundWorkerRemittanceLookup;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mskCustomerIDExpiryDate;
        private System.Windows.Forms.MaskedTextBox mskCustomerIDIssuedDate;
        private System.Windows.Forms.Label lblPhoneCode;
		private System.Windows.Forms.ToolTip toolTip;
    }
}