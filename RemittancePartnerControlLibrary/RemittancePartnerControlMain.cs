using System;
using System.Windows.Forms;
using CommonLibrary;

namespace TransFastControlLibrary
{
    public partial class RemittancePartnerControlMain : UserControl
    {
        #region Constructors

        public RemittancePartnerControlMain()
        {

#if DEBUG
            _branchInformation.BranchUserID = "090332";
            _branchInformation.BranchName = System.Net.Dns.GetHostName();
            _branchInformation.BranchCode = "99997";
            _branchInformation.BranchAreaCode = "101";
            _branchInformation.BranchRegionCode = "1A";
#else
            _branchInformation.BranchUserID = CommonHelper.EmpID;
            _branchInformation.BranchName = CommonHelper.GetBranchName;
            _branchInformation.BranchCode = CommonHelper.GetBranchCode;
            _branchInformation.BranchAreaCode = CommonHelper.GetAreaCode;
            _branchInformation.BranchRegionCode = CommonHelper.GetRegionCode;
#endif

            _branchInformation.ClientMacAddress = Utils.GetMacAddress();
            _branchInformation.ClientApplicationVersion = this.GetType().Assembly.GetName().Version.ToString();

            InitializeComponent();
        }

        #endregion

        #region Fields

        private CebuanaBranchInformation _branchInformation = new CebuanaBranchInformation();

        #endregion

        #region Properties

        internal CebuanaBranchInformation BranchInformation
        {
            get
            {
                return _branchInformation;
            }
        }

        internal bool IsCommonHelperDataValid
        {
            get
            {
                return !(
                    _branchInformation.BranchUserID == null ||
                    _branchInformation.BranchName == null ||
                    _branchInformation.BranchCode == null ||
                    _branchInformation.BranchAreaCode == null ||
                    _branchInformation.BranchRegionCode == null ||
                    _branchInformation.ClientApplicationVersion == null ||
                    _branchInformation.ClientMacAddress == null
                    );
            }
        }

        #endregion

        #region Static Methods

        public static DialogResult ShowPayoutForm(string referenceNumber)
        {
            RemittancePartnerControlMain remittancePartnerControlMain = new RemittancePartnerControlMain();

            if (remittancePartnerControlMain.IsCommonHelperDataValid)
            {
                PayoutForm payoutForm = new PayoutForm(remittancePartnerControlMain);
                payoutForm.ReferenceNumber = referenceNumber;
                payoutForm.IsCalledFromStaticMethod = true;
                return payoutForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    String.Format("Please log-off from i-Click and re-logon. You will not be able to make transactions until you do so. {0}{0}If the problem persists, contact ICT Support Desk.", Environment.NewLine),
                    "CommonHelper Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return DialogResult.None;
            }
        }

        #endregion

        #region Events

        private void RemittancePartnerControlMain_Load(object sender, EventArgs e)
        {
            if (!IsCommonHelperDataValid)
            {
                this.Enabled = false;
                MessageBox.Show(
                    String.Format("Please log-off from i-Click and re-logon. You will not be able to make transactions until you do so. {0}{0}If the problem persists, contact ICT Support Desk.", Environment.NewLine),
                    "CommonHelper Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPayout_Click(object sender, EventArgs e)
        {
            PayoutForm payoutForm = new PayoutForm(this);
            payoutForm.ShowDialog();
        }

        #endregion
    }
}
