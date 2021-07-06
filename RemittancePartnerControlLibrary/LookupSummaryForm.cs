using System;
using System.Windows.Forms;

namespace TransFastControlLibrary
{
    public partial class LookupSummaryForm : Form
    {
		#region Contructors

		private LookupSummaryForm(LookupTransactionResult lookupTransactionResult)
		{
			InitializeComponent();
			_lookupTransactionResult = lookupTransactionResult;
		}

		#endregion

		#region Fields

		private LookupTransactionResult _lookupTransactionResult;

		#endregion

		#region Methods

		public static DialogResult ShowSummary(LookupTransactionResult lookupTransactionResult)
		{
			LookupSummaryForm lookupSummaryForm = new LookupSummaryForm(lookupTransactionResult);
			return lookupSummaryForm.ShowDialog();
		}

		#endregion

		#region Events

		private void LookupSummaryForm_Load(object sender, EventArgs e)
		{
			lblBeneficiaryName.Text = string.Format("{0}", _lookupTransactionResult.BeneficiaryFullName);
			lblTransactionNumber.Text = string.Format("{0}", _lookupTransactionResult.TransactionNumber);

			#region Add Tooltip

			this.toolTip.SetToolTip(lblBeneficiaryName, string.Format("{0} {1}", _lookupTransactionResult.BeneficiaryLastName, _lookupTransactionResult.BeneficiaryFirstName));

			#endregion
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			//return base.ProcessDialogKey(keyData);

			switch (keyData)
			{
				case Keys.F1:
					this.DialogResult = DialogResult.Cancel;
					return true;
				case Keys.F2:
					this.DialogResult = DialogResult.OK;
					return true;
				case Keys.Escape:
					this.DialogResult = DialogResult.Abort;
					return true;
				default:
					return base.ProcessDialogKey(keyData);
			}
		}

		#endregion

		private void lblTitle_Click(object sender, EventArgs e)
		{

		}
    }
}
