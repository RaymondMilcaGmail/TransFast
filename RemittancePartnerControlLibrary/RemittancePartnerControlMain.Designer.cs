namespace TransFastControlLibrary
{
    partial class RemittancePartnerControlMain
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemittancePartnerControlMain));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnPayout = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(418, 84);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// btnPayout
			// 
			this.btnPayout.BackColor = System.Drawing.Color.Azure;
			this.btnPayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPayout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPayout.Location = new System.Drawing.Point(109, 112);
			this.btnPayout.Name = "btnPayout";
			this.btnPayout.Size = new System.Drawing.Size(100, 39);
			this.btnPayout.TabIndex = 0;
			this.btnPayout.Text = "Payout";
			this.btnPayout.UseVisualStyleBackColor = false;
			this.btnPayout.Click += new System.EventHandler(this.btnPayout_Click);
			// 
			// btnSend
			// 
			this.btnSend.BackColor = System.Drawing.Color.Azure;
			this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSend.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSend.Location = new System.Drawing.Point(215, 112);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(100, 39);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = false;
			// 
			// RemittancePartnerControlMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnPayout);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "RemittancePartnerControlMain";
			this.Size = new System.Drawing.Size(428, 178);
			this.Load += new System.EventHandler(this.RemittancePartnerControlMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPayout;
        private System.Windows.Forms.Button btnSend;
    }
}
