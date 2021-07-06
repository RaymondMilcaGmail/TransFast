using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TransFastControlLibrary
{
    public partial class BeneficiaryConfirmationForm : Form
    {
		#region Constructors

		private BeneficiaryConfirmationForm(string transactionBeneficiaryName, CebuanaCustomerInformation selectedCustomerInformation)
		{
			InitializeComponent();
			_transactionbeneficiaryName = transactionBeneficiaryName;
			_registeredCustomerInformation = selectedCustomerInformation;
		}

		#endregion

		#region Fields

		private string _transactionbeneficiaryName;

		private CebuanaCustomerInformation _registeredCustomerInformation;

		#endregion

		#region Methods

		internal static DialogResult ShowForm(string transactionBeneficiaryName, CebuanaCustomerInformation registeredCustomerInformation)
		{
			BeneficiaryConfirmationForm beneficiaryForm = new BeneficiaryConfirmationForm(transactionBeneficiaryName, registeredCustomerInformation);
			return beneficiaryForm.ShowDialog();
		}

		#endregion

		#region Events

		private void BeneficiaryConfirmationForm_Load(object sender, EventArgs e)
		{
			lblTransactionBeneficiaryName.Text = _transactionbeneficiaryName;
			lblRegisteredBeneficiaryName.Text = string.Format("{0}, {1}", _registeredCustomerInformation.LastName, _registeredCustomerInformation.FirstName);
			lblCustomerNumber.Text = _registeredCustomerInformation.CustomerNumber;

			#region Add Tooltip

			this.toolTip.SetToolTip(lblTransactionBeneficiaryName, _transactionbeneficiaryName);
			this.toolTip.SetToolTip(lblRegisteredBeneficiaryName, string.Format("{0}, {1}", _registeredCustomerInformation.LastName, _registeredCustomerInformation.FirstName));

			#endregion
		}

		#endregion
    }
}
