using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CRMSModuleII;
using TransFastControlLibrary;

namespace TransFastControlLibrary
{
	public partial class PayoutForm : Form
	{
		#region Contructors

		internal PayoutForm(RemittancePartnerControlMain remittancePartnerControlMain)
		{
			InitializeComponent();
			GroupControls();
			InitializePayoutForm();
			_parentRemittancePartnerControlMain = remittancePartnerControlMain;
		}

		#endregion

		#region Fields

		private bool _isCalledFromStaticMethod = false;

		private RemittancePartnerControlMain _parentRemittancePartnerControlMain;
		private Control[] _inputReferenceNumberControls;
		private Control[] _inputCustomerControls;
		private Control[] _inputCustomerValidationControls;
		private Control[] _inputSenderDetailsControls;
		private Control[] _inputProcessingControls;
		private Control[] _inputPostProcessingControls;

		private Control[] _outputReferenceNumberControls;
		private Control[] _outputCustomerControls;
		private Control[] _outputCustomerValidationControls;
		private Control[] _outputProcessingControls;
		private Control[] _outputPostProcessingControls;

		private CebuanaCustomerInformation _cebuanaCustomerInformation;
		private CebuanaCustomerID[] _cebuanaCustomerIDs;
		private List<CLSCCountry> _clscCountries;

		private LookupTransaction _remittancePartnerLookupTransaction;
		private PayoutTransaction _remittancePartnerPayoutTransaction;

		#endregion

		#region Properties

		internal string ReferenceNumber
		{
			get { return txtReferenceNumber.Text; }
			set { txtReferenceNumber.Text = value; }
		}

		internal bool IsCalledFromStaticMethod
		{
			get { return _isCalledFromStaticMethod; }
			set { _isCalledFromStaticMethod = value; }
		}

		#endregion

		#region UnlockFields
		private string _lookupStatusCode;
		private string _payoutStatusCode;

		public string PayoutStatusCode
		{
			get { return _payoutStatusCode; }
			set { _payoutStatusCode = value; }
		}
		public string LookupStatusCode
		{
			get { return _lookupStatusCode; }
			set { _lookupStatusCode = value; }
		}
		#endregion

		#region Token Variables
		private string _token = string.Empty;

		public string Token
		{
			get { return _token; }
			set { _token = value; }
		}
		#endregion

		#region Methods

		private void BuildCustomerIDTypesList()
		{
			try
			{
				_cebuanaCustomerIDs = RemittancePartnerConfiguration.GetCebuanaCustomerIDs();
				cboCustomerIDSubmitted.DataSource = _cebuanaCustomerIDs;
				cboCustomerIDSubmitted.ValueMember = "IDCode";
				cboCustomerIDSubmitted.DisplayMember = "IDDescription";
				cboCustomerIDSubmitted.SelectedIndex = -1;
			}
			catch
			{
				throw;
			}
		}

		private void BuildCountryList()
		{
			try
			{
				_clscCountries = CLSCCountry.GetList();
			}
			catch (Exception error)
			{
				throw new RemittanceException("An error has occured while getting the country list from the database. Please contact ICT Support Desk.", error);
			}
		}

		private void BindSendingCountryList()
		{
			try
			{
				List<CLSCCountry> countries = _clscCountries;
				if (countries.Count > 0)
				{
					CLSCCountry country = new CLSCCountry();
					country.CodeISO2 = "00";
					country.CodeISO3 = "000";
					country.Name = "Others";
					country.PhoneCode = "00";
					countries.Add(country);
				}

				cboSendingCountry.DataSource = countries.ToArray();
				cboSendingCountry.ValueMember = "CodeISO2";
				cboSendingCountry.DisplayMember = "Name";
				cboSendingCountry.SelectedIndex = -1;
			}
			catch (Exception error)
			{
				throw new RemittanceException("An error has occured while getting the country list from the database. Please contact ICT Support Desk.", error);
			}

		}

		private void BindCountryPhoneCodeList()
		{
			try
			{
				cboPhoneCode.DataSource = _clscCountries.ToArray();
				cboPhoneCode.ValueMember = "PhoneCode";
				cboPhoneCode.DisplayMember = "Name";
				cboPhoneCode.SelectedIndex = -1;
			}
			catch (Exception error)
			{
				throw new RemittanceException("An error has occured while getting the phone code list from the database. Please contact ICT Support Desk.", error);
			}
		}

		private void BindStateList()
		{
			try
			{
				List<CLSCState> states = null;

				if (cboSendingCountry.SelectedIndex >= 0)
				{
					states = CLSCState.GetList(cboSendingCountry.SelectedValue.ToString());
				}
				else
				{
					states = new List<CLSCState>();
				}

				cboSendingState.DataSource = states.ToArray();
				cboSendingState.ValueMember = "Code";
				cboSendingState.DisplayMember = "Name";
				cboSendingState.SelectedIndex = -1;

				if (states.Count == 0)
				{
					cboSendingState.Enabled = false;
				}
				else
				{
					cboSendingState.Enabled = true;
				}
			}
			catch (Exception error)
			{
				throw new RemittanceException("An error has occured while getting the state list from the database. Please contact ICT Support Desk.", error);
			}
		}

		private void InitializePayoutForm()
		{
			Utils.ClearControls(
				_inputReferenceNumberControls,
				_inputCustomerControls,
				_inputCustomerValidationControls,
				_inputSenderDetailsControls,
				_inputProcessingControls,
				_inputPostProcessingControls,

				_outputReferenceNumberControls,
				_outputCustomerControls,
				_outputCustomerValidationControls,
				_outputProcessingControls,
				_outputPostProcessingControls);

			Utils.ToggleControlEnabledState(
				true,
				_inputReferenceNumberControls);

			Utils.ToggleControlEnabledState(
				false,
				_inputCustomerControls,
				_inputCustomerValidationControls,
				_inputSenderDetailsControls,
				_inputProcessingControls,
				_inputPostProcessingControls);

			lblPayoutCurrency.BackColor = Color.IndianRed;
			lblProcessingStatus.BackColor = Color.DarkOrange;
			lblProcessingStatus.Text = "Input reference number.";
			lblTitle.Text = string.Format("Payout [{0}]", RemittancePartnerConfiguration.PartnerName);

			_remittancePartnerLookupTransaction = null;
			_remittancePartnerPayoutTransaction = null;
		}

		private void SetSenderInfoControlsState()
		{
			Utils.ClearControls(
				_inputSenderDetailsControls
				);

			if (_clscCountries.Count < 1)
			{
				Utils.ToggleControlEnabledState(
					false,
					cboSendingCountry,
					cboSendingState,
					optMobileNumber,
					cboPhoneCode,
					txtMobileNumber);

				return;
			}

			Utils.ToggleControlEnabledState(
				true,
				optMobileNumber,
				lblPhoneCode,
				optEmailAddress
				);

			if (!string.IsNullOrEmpty(_remittancePartnerLookupTransaction.LookupTransactionResult.SenderCountry))
			{
				int isFound = this.cboSendingCountry.FindStringExact(_remittancePartnerLookupTransaction.LookupTransactionResult.SenderCountry);
				if (isFound < 0)
				{
					CLSCCountry[] countrySource = this.cboSendingCountry.DataSource as CLSCCountry[];
					CLSCCountry country = Array.Find<CLSCCountry>(countrySource, delegate(CLSCCountry findCountry)
					{
						return findCountry.CodeISO3.Equals(_remittancePartnerLookupTransaction.LookupTransactionResult.SenderCountry);
					});
					if (country != null)
					{
						this.cboSendingCountry.SelectedValue = country.CodeISO2;
					}
					else
					{
						this.cboSendingCountry.SelectedValue = _remittancePartnerLookupTransaction.LookupTransactionResult.SenderCountry;
					}
				}
				else
				{
					this.cboSendingCountry.SelectedIndex = isFound;
				}

				if (this.cboSendingCountry.SelectedIndex > 0)
				{
					this.cboSendingCountry.Enabled = false;
				}
			}
		}

		private void GroupControls()
		{
			#region Input Controls

			Control[] inputReferenceNumberControls = { txtReferenceNumber, btnLoadReferenceNumber };
			_inputReferenceNumberControls = inputReferenceNumberControls;

			Control[] inputCustomerControls = { };
			_inputCustomerControls = inputCustomerControls;

			Control[] inputCustomerValidationControls = {
                cboCustomerIDSubmitted,
                txtCustomerIDSubmittedNumber,
                cboSendingCountry,
                mskCustomerIDIssuedDate,
                mskCustomerIDExpiryDate,
            };

			_inputCustomerValidationControls = inputCustomerValidationControls;

			Control[] inputSenderDetailsControls = {
                optEmailAddress,
                optMobileNumber,
                cboSendingCountry,
                cboSendingState,
                txtEmailAddress,
                cboPhoneCode,
                lblPhoneCode,
                txtMobileNumber
            };

			_inputSenderDetailsControls = inputSenderDetailsControls;

			Control[] inputProcessingControls = { btnProcessPayout };
			_inputProcessingControls = inputProcessingControls;

			Control[] inputPostProcessingControls = { btnPrintReceipt };
			_inputPostProcessingControls = inputPostProcessingControls;

			#endregion

			#region Output Controls

			Control[] outputReferenceNumberControls = {
                                                          lblPayoutTransactionNumber,
                                                          lblTransactionDate,
                                                          lblTransactionStatus,
                                                          lblPayoutAmount,
                                                          lblPayoutCurrency,
                                                          lblPayoutCountry,
                                                          //lblSenderMessage,

                                                          lblSenderName,
                                                          //lblSenderFirstName,
                                                          //lblSenderMiddleName,
                                                          //lblSenderCity,
                                                          //lblSenderNationality,
                                                          
                                                          lblBeneficiaryName,
                                                          //lblBeneficiaryFirstName,
                                                          //lblBeneficiaryMiddleName,
                                                          //lblBeneficiaryCity,
                                                          //lblBeneficiaryNationality
                                                      };
			_outputReferenceNumberControls = outputReferenceNumberControls;

			Control[] outputCustomerControls = {
                                                   txtCustomerNumber,
                                                   lblCustomerLastName,
                                                   lblCustomerFirstName,
                                                   lblCustomerMiddleName
                                               };
			_outputCustomerControls = outputCustomerControls;

			Control[] outputCustomerValidationControls = {
                                                             cboCustomerIDSubmitted,
                                                             txtCustomerIDSubmittedNumber
                                                         };
			_outputCustomerValidationControls = outputCustomerValidationControls;

			Control[] outputProcessingControls = {
                                                     lblProcessingStatus
                                                 };

			_outputProcessingControls = outputProcessingControls;

			Control[] outputPostProcessingControls = { };
			_outputPostProcessingControls = outputPostProcessingControls;

			#endregion
		}

		private void LookupReferenceNumber()
		{
			LookupTransactionRequest lookupTransactionRequest = new LookupTransactionRequest();
			lookupTransactionRequest.CebuanaBranchInformation = _parentRemittancePartnerControlMain.BranchInformation;
			lookupTransactionRequest.TransactionNumber = txtReferenceNumber.Text;
			lookupTransactionRequest.Token = Token;
			lookupTransactionRequest.PartnerCode = RemittancePartnerConfiguration.PartnerCode;
			LookupTransaction remittancePartnerLookupTransaction = new LookupTransaction(lookupTransactionRequest);
			remittancePartnerLookupTransaction.WebServiceURL = RemittancePartnerConfiguration.WebServiceURL;

			Utils.ToggleControlEnabledState(false, _inputReferenceNumberControls);
			timer1.Start();
			lblProcessingStatus.Text = "Searching for transaction...";

			backgroundWorkerRemittanceLookup.RunWorkerAsync(remittancePartnerLookupTransaction);
		}

		private void ProcessLookupTransactionResult()
		{
			switch (_remittancePartnerLookupTransaction.LookupTransactionResult.ResultCode)
			{
				case TransFastControlLibrary.Utils.LookupTransactionResultCode.Successful:
					MessageBox.Show(_remittancePartnerLookupTransaction.LookupTransactionResult.MessageToClient, "Lookup Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
					DialogResult dialogResult = LookupSummaryForm.ShowSummary(_remittancePartnerLookupTransaction.LookupTransactionResult);
					switch (dialogResult)
					{
						case DialogResult.OK:
							{
								DisplayLookupTransactionDetails();
								CheckTransactionCurrency();

                                if (this.DialogResult != DialogResult.Abort)
                                {
                                    #region Add Tooltip

                                    this.toolTip.SetToolTip(lblBeneficiaryName, _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryFullName);
                                    this.toolTip.SetToolTip(lblSenderName, _remittancePartnerLookupTransaction.LookupTransactionResult.SenderFullName);

                                    #endregion
                                }
							}
							break;
						default:
							ClearForm();
							break;
					}
					break;
				case TransFastControlLibrary.Utils.LookupTransactionResultCode.ServerError:
					MessageBox.Show(_remittancePartnerLookupTransaction.LookupTransactionResult.MessageToClient, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					ClearForm();
					break;
				case TransFastControlLibrary.Utils.LookupTransactionResultCode.Unsuccessful:
					MessageBox.Show(_remittancePartnerLookupTransaction.LookupTransactionResult.MessageToClient, "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					ClearForm();
					break;
				default:
					MessageBox.Show(_remittancePartnerLookupTransaction.LookupTransactionResult.MessageToClient, "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
					ClearForm();
					break;
			}
		}

		private void DisplayLookupTransactionDetails()
		{
			if (_remittancePartnerLookupTransaction != null && _remittancePartnerLookupTransaction.LookupTransactionResult != null)
			{
				lblPayoutTransactionNumber.Text = _remittancePartnerLookupTransaction.LookupTransactionResult.TransactionNumber;
				lblTransactionDate.Text = _remittancePartnerLookupTransaction.LookupTransactionResult.TransactionDate.ToString("MMM dd, yyyy HH:mm:ss");
				string transactionStatus;
				switch (_remittancePartnerLookupTransaction.LookupTransactionResult.TransactionStatus)
				{
					case TransFastControlLibrary.Utils.TransactionStatus.ForPayout:
						transactionStatus = "For Payout";
						break;
					case TransFastControlLibrary.Utils.TransactionStatus.PaidOut:
						transactionStatus = "Paid Out";
						break;
					case TransFastControlLibrary.Utils.TransactionStatus.Cancelled:
						transactionStatus = "Cancelled";
						break;
					case TransFastControlLibrary.Utils.TransactionStatus.Blocked:
						transactionStatus = "Blocked";
						break;
					case TransFastControlLibrary.Utils.TransactionStatus.ProcessedForPayout:
						transactionStatus = "Ready For Payout";
						break;
					default:
						transactionStatus = "Unrecognized Status";
						break;
				}
				lblTransactionStatus.Text = transactionStatus;
				lblPayoutAmount.Text = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutAmount.ToString("N2");
				lblPayoutCurrency.Text = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutCurrency;
				lblPayoutCountry.Text = Utils.GetCountryName(_remittancePartnerLookupTransaction.LookupTransactionResult.PayoutCountry);
				lblSenderName.Text = _remittancePartnerLookupTransaction.LookupTransactionResult.SenderFullName;
				lblBeneficiaryName.Text = _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryFullName;
				//lblMessage.Text = _remittancePartnerLookupTransaction.LookupTransactionResult.MessageToClientFromSender;
			}
			else
			{
				MessageBox.Show("No lookup transaction result found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void CheckTransactionCurrency()
		{
			string transactionCurrencyCode = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutCurrency.Trim().ToUpper();

			if (transactionCurrencyCode != "PHP")
			{
				lblPayoutCurrency.BackColor = Color.LightGreen;
				string message = string.Empty;

				if (transactionCurrencyCode == "USD")
				{
					MultiCurrencyWrapper multiCurrencyWrapper = new MultiCurrencyWrapper(
							transactionCurrencyCode,
							_remittancePartnerLookupTransaction.LookupTransactionResult.PayoutAmount);

					message = multiCurrencyWrapper.ReturnMessage;
				}
				else
				{
					message = "Warning: This is a non-PHP payout transaction. Are you sure you want to proceed?";
				}

				DialogResult dialogResult = MessageBox.Show(message, "Non-PHP Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

				if (dialogResult != DialogResult.Yes)
				{
					ClearForm();
					return;
				}
			}

			Utils.ToggleControlEnabledState(true, _inputCustomerControls);
			lblProcessingStatus.BackColor = Color.PaleGoldenrod;
			lblProcessingStatus.Text = "Please choose customer beneficiary.";
			SearchForCustomer();
		}

		private void SearchForCustomer()
		{
			try
			{

#if DEBUG
				bool isCustomerSelected = true;
#else
                bool isCustomerSelected = CustomerSearch.OpenSearch(_parentRemittancePartnerControlMain.BranchInformation.BranchUserID, _parentRemittancePartnerControlMain.BranchInformation.BranchCode, _parentRemittancePartnerControlMain.BranchInformation.BranchAreaCode, _parentRemittancePartnerControlMain.BranchInformation.BranchRegionCode, "REM");
#endif

				if (isCustomerSelected == true)
				{
					CebuanaCustomerInformation cebuanaCustomerInformation = new CebuanaCustomerInformation();
					List<CebuanaCustomerID> registeredIDs = new List<CebuanaCustomerID>();
					//string customerIDTypesString;
					//string customerIDNumbersString;

                    cebuanaCustomerInformation.CustomerNumber = CustomerInformation.CustomerNumber;
                    cebuanaCustomerInformation.LastName = CustomerInformation.LastName;
                    cebuanaCustomerInformation.FirstName = CustomerInformation.FirstName;
                    cebuanaCustomerInformation.MiddleName = CustomerInformation.MiddleName;
                    cebuanaCustomerInformation.City = CustomerInformation.AddressTownCity;
                    DateTime birthdate = new DateTime(1900, 01, 01);
                    DateTime.TryParse(CustomerInformation.BirthDate, out birthdate);
                    cebuanaCustomerInformation.BirthDate = birthdate;
                    //customerIDTypesString = Convert.ToString(CustomerInformation.PresentedIDType).Trim();
                    //customerIDNumbersString = Convert.ToString(CustomerInformation.PresentedIDNumber).Trim();
                    cebuanaCustomerInformation.Country = "PH";
                    if (!CustomerInformation.CellPhone.Equals(string.Empty))
                    {
                        _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryPhoneNumber = CustomerInformation.CellPhone;
                    }
                    else if (CustomerInformation.CellPhone.Equals(string.Empty) && !CustomerInformation.Telephone.Equals(string.Empty))
                    {
                        _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryPhoneNumber = CustomerInformation.Telephone;
                    }
                    else
                    {
                        _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryPhoneNumber = string.Empty;
                    }

					DialogResult beneficiaryConfirmationDialogResult = BeneficiaryConfirmationForm.ShowForm(
						_remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryFullName
						, cebuanaCustomerInformation);
					if (beneficiaryConfirmationDialogResult == DialogResult.Abort)
					{
						this.DialogResult = DialogResult.Abort;
					}
					else
					{
						_cebuanaCustomerInformation = cebuanaCustomerInformation;
						lblProcessingStatus.Text = "Please enter customer validation and sender details.";
						Utils.ToggleControlEnabledState(true, _inputCustomerValidationControls);
						SetSenderInfoControlsState();
						DisplayCustomerDetails();
					}
				}
				else
				{
					this.DialogResult = DialogResult.Abort;
				}
			}
			catch (Exception error)
			{
				if (error is RemittanceException)
				{
					Utils.DisplayErrorMessageBox(error);
				}
				else
				{
					Utils.DisplayErrorMessageBox(new RemittanceException("An error has occured in the CRMS module. Please contact ICT Support Desk.", error));
				}

				ClearForm();
			}
		}

		private void DisplayCustomerDetails()
		{
			if (_cebuanaCustomerInformation != null)
			{
				txtCustomerNumber.Text = _cebuanaCustomerInformation.CustomerNumber;
				lblCustomerLastName.Text = _cebuanaCustomerInformation.LastName;
				lblCustomerFirstName.Text = _cebuanaCustomerInformation.FirstName;
				lblCustomerMiddleName.Text = _cebuanaCustomerInformation.MiddleName;

				#region Add Tooltip

				this.toolTip.SetToolTip(lblCustomerFirstName, _cebuanaCustomerInformation.FirstName);
				this.toolTip.SetToolTip(lblCustomerLastName, _cebuanaCustomerInformation.LastName);
				this.toolTip.SetToolTip(lblCustomerMiddleName, _cebuanaCustomerInformation.MiddleName);

				#endregion
			}
			else
			{
				MessageBox.Show("No customer selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void PayoutReferenceNumber()
		{
			if (!(_remittancePartnerLookupTransaction.LookupTransactionResult.TransactionStatus == TransFastControlLibrary.Utils.TransactionStatus.ForPayout || _remittancePartnerLookupTransaction.LookupTransactionResult.TransactionStatus == TransFastControlLibrary.Utils.TransactionStatus.ProcessedForPayout))
			{
				MessageBox.Show("This transaction is not for payout.", "Not available for payout", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			try
			{
				if (_remittancePartnerLookupTransaction.LookupTransactionResult.PayoutCurrency.Trim().ToUpper() != "PHP")
				{
					DialogResult dialogResult = MessageBox.Show("You are about to process a non-PHP transaction. Do you want to continue?", "Non-PHP Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (dialogResult != DialogResult.Yes)
					{
						ClearForm();
						return;
					}
				}
				else
				{
					if (Utils.IsAvailableBalanceSufficient(_remittancePartnerLookupTransaction.LookupTransactionResult.PayoutAmount) == false)
					{
						MessageBox.Show("Available balance is not enough for this payout transaction.", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}
			}
			catch (Exception error)
			{
				Utils.DisplayErrorMessageBox(error);
				return;
			}

			PayoutTransactionRequest payoutTransactionRequest = new PayoutTransactionRequest();
			payoutTransactionRequest.CebuanaBranchInformation = _parentRemittancePartnerControlMain.BranchInformation;

			payoutTransactionRequest.TransactionNumber = _remittancePartnerLookupTransaction.LookupTransactionResult.TransactionNumber;
			payoutTransactionRequest.PayoutAmount = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutAmount;
			payoutTransactionRequest.PayoutAmountWithServiceCharge = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutAmountWithServiceCharge;
			payoutTransactionRequest.PayoutCurrency = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutCurrency;
			payoutTransactionRequest.SendingCurrency = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutCurrency;
			payoutTransactionRequest.CurrencyConversionRate = _remittancePartnerLookupTransaction.LookupTransactionResult.CurrencyConversionRate;
			payoutTransactionRequest.PayoutCountry = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutCountry;

			payoutTransactionRequest.SenderFullName = _remittancePartnerLookupTransaction.LookupTransactionResult.SenderFullName;
			payoutTransactionRequest.SenderLastName = _remittancePartnerLookupTransaction.LookupTransactionResult.SenderLastName;
			payoutTransactionRequest.SenderFirstName = _remittancePartnerLookupTransaction.LookupTransactionResult.SenderFirstName;

			payoutTransactionRequest.ReceiverCustomerNumber = _cebuanaCustomerInformation.CustomerNumber;
			payoutTransactionRequest.ReceiverFullName = _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryFullName;
			payoutTransactionRequest.ReceiverLastName = _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryLastName;
			payoutTransactionRequest.ReceiverFirstName = _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryFirstName;
			payoutTransactionRequest.ReceiverIDCode = _cebuanaCustomerIDs[cboCustomerIDSubmitted.SelectedIndex].IDCode;
			payoutTransactionRequest.ReceiverIDType = _cebuanaCustomerIDs[cboCustomerIDSubmitted.SelectedIndex].IDDescription;
			payoutTransactionRequest.PartnerCode = RemittancePartnerConfiguration.PartnerCode;

			if (payoutTransactionRequest.ReceiverIDType.Contains("'"))
			{
				payoutTransactionRequest.ReceiverIDType = payoutTransactionRequest.ReceiverIDType.Replace("'", string.Empty);
			}
			payoutTransactionRequest.ReceiverIDNumber = txtCustomerIDSubmittedNumber.Text;
			payoutTransactionRequest.ReceiverCity = _cebuanaCustomerInformation.City;
			payoutTransactionRequest.ReceiverCountry = _cebuanaCustomerInformation.Country;
			payoutTransactionRequest.Token = Token;

			DateTime dateIssued = new DateTime(1900, 1, 1);
			DateTime dateExpiry = new DateTime(1900, 1, 1);
            string idDate = string.Empty;
            #region //DateIssued

            if (mskCustomerIDIssuedDate.Text.Contains("/"))
            {
                idDate = mskCustomerIDIssuedDate.Text.Replace("/", string.Empty);
            }
            else
            {
                idDate = mskCustomerIDIssuedDate.Text.Replace(" ", string.Empty);
            }

			if (idDate.Length.Equals(8))
			{
				try
				{
					DateTime.TryParse(mskCustomerIDIssuedDate.Text, out dateIssued);
				}
				catch
				{
					dateIssued = new DateTime(1900, 1, 1);
				}
			}
			else
			{
				dateIssued = new DateTime(1900, 1, 1);
			}
            #endregion

            #region//ExpiryDate

            if (mskCustomerIDExpiryDate.Text.Contains("/"))
            {
                idDate = mskCustomerIDExpiryDate.Text.Replace("/", string.Empty);
            }
            else
            {
                idDate = mskCustomerIDExpiryDate.Text.Replace(" ", string.Empty);
            }

            if (idDate.Length.Equals(8))
			{
				try
				{
					DateTime.TryParse(mskCustomerIDExpiryDate.Text, out dateExpiry);
				}
				catch
				{
					dateExpiry = new DateTime(1900, 1, 1);
				}
			}
			else
			{
				dateExpiry = new DateTime(1900, 1, 1);
			}
			#endregion

			payoutTransactionRequest.ReceiverIDIssuedDate = dateIssued.ToString("o");
			payoutTransactionRequest.ReceiverIDExpiryDate = dateExpiry.ToString("o");

			if (cboSendingCountry.SelectedIndex > -1)
				payoutTransactionRequest.SenderCountry = cboSendingCountry.SelectedValue.ToString();

			if (cboSendingState.SelectedIndex > -1)
				payoutTransactionRequest.SenderState = cboSendingState.SelectedValue.ToString();

			if (optEmailAddress.Checked == true)
				payoutTransactionRequest.SenderEmail = txtEmailAddress.Text;

			if (optMobileNumber.Checked == true)
				payoutTransactionRequest.SenderMobileNumber = string.Format("{0}{1}", lblPhoneCode.Text, txtMobileNumber.Text);

			payoutTransactionRequest.PayoutID = _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutID;
			payoutTransactionRequest.BeneficiaryPhoneNumber = _remittancePartnerLookupTransaction.LookupTransactionResult.BeneficiaryPhoneNumber;

			payoutTransactionRequest.TransactionNumber = _remittancePartnerLookupTransaction.LookupTransactionResult.TransactionNumber;
			payoutTransactionRequest.PayTokenID = _remittancePartnerLookupTransaction.LookupTransactionResult.PayTokenID;

            payoutTransactionRequest.AssignToken = _remittancePartnerLookupTransaction.LookupTransactionResult.AssignToken;
            payoutTransactionRequest.InvoiceUpdateID = _remittancePartnerLookupTransaction.LookupTransactionResult.InvoiceUpdateID;
            payoutTransactionRequest.InvoiceStatus = _remittancePartnerLookupTransaction.LookupTransactionResult.InvoiceStatus;

            PayoutTransaction payoutTransaction = new PayoutTransaction(payoutTransactionRequest);
			payoutTransaction.WebServiceURL = RemittancePartnerConfiguration.WebServiceURL;

			Utils.ToggleControlEnabledState(
				false,
				_inputCustomerControls,
				_inputCustomerValidationControls,
				_inputProcessingControls,
				_inputSenderDetailsControls);
			lblProcessingStatus.Text = "Processing payout...";
			timer1.Start();
			backgroundWorkerRemittancePayout.RunWorkerAsync(payoutTransaction);
		}

		private void ProcessPayoutTransactionResult()
		{
			switch (_remittancePartnerPayoutTransaction.PayoutTransactionResult.ResultCode)
			{
				case TransFastControlLibrary.Utils.PayoutTransactionResultCode.Successful:
					MessageBox.Show(_remittancePartnerPayoutTransaction.PayoutTransactionResult.MessageToClient, "Payout Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Utils.ToggleControlEnabledState(true, _inputPostProcessingControls);
					PostProcessing();
					break;
				case TransFastControlLibrary.Utils.PayoutTransactionResultCode.PartnerError:
				case TransFastControlLibrary.Utils.PayoutTransactionResultCode.ServerError:
					MessageBox.Show(_remittancePartnerPayoutTransaction.PayoutTransactionResult.MessageToClient, "WebService Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					lblProcessingStatus.Text = "Error";
					lblProcessingStatus.BackColor = Color.Red;
					break;
				case TransFastControlLibrary.Utils.PayoutTransactionResultCode.Unsuccessful:
				default:
					MessageBox.Show(_remittancePartnerPayoutTransaction.PayoutTransactionResult.MessageToClient, "Partner Remittance Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					lblProcessingStatus.BackColor = Color.Crimson;
					lblProcessingStatus.Text = "Payout Unsuccessful.";
					break;
			}

		}

		private void PostProcessing()
		{
			try
			{
				switch (_remittancePartnerLookupTransaction.LookupTransactionResult.PayoutCurrency.Trim().ToUpper())
				{
					case "PHP":
						{
							Utils.BranchLedgerCashout(_remittancePartnerPayoutTransaction.PayoutTransactionRequest.PayoutCurrency, _remittancePartnerPayoutTransaction.PayoutTransactionRequest.PayoutAmount, _remittancePartnerPayoutTransaction.PayoutTransactionRequest.TransactionNumber, _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverCustomerNumber);
							PrintReceipt();
						}
						break;
					case "USD":
						{
							PrintReceipt();
							DollarPayoutPopup.frmDollarPayout dollarPopup = new DollarPayoutPopup.frmDollarPayout();

							try
							{
#if !DEBUG
                                dollarPopup.DisplayDollarPayout(
                                    _remittancePartnerLookupTransaction.LookupTransactionResult.MultiCurrencyPayoutCode,
                                    _remittancePartnerLookupTransaction.LookupTransactionResult.TransactionNumber,
                                    string.Format("{0} {1}", _remittancePartnerLookupTransaction.LookupTransactionResult.SenderFirstName, _remittancePartnerLookupTransaction.LookupTransactionResult.SenderLastName),
                                    _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverCustomerNumber,
                                    string.Format("{0} {1} {2}", _cebuanaCustomerInformation.FirstName, _cebuanaCustomerInformation.MiddleName, _cebuanaCustomerInformation.LastName),
                                    _remittancePartnerLookupTransaction.LookupTransactionResult.PayoutAmount.ToString("N2"),
                                    false,
                                    string.Empty);
#endif
							}
							catch (Exception error)
							{
								throw new RemittanceException("Error in opening Dollar Payout. Please continue processing this transaction in the Dollar Payout module.", error);
							}
						}
						break;
					default:
						{
							PrintReceipt();
							MessageBox.Show("Please continue processing in multi-currency module.", "Multi-Currency Payout.", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						break;

				}

				lblProcessingStatus.BackColor = Color.LightGreen;
				lblProcessingStatus.Text = "Payout successful!";
			}
			catch (Exception error)
			{
				Utils.DisplayErrorMessageBox(error);
				lblProcessingStatus.BackColor = Color.Yellow;
				lblProcessingStatus.Text = "Payout successful, but with errors.";
			}
		}

		private void PrintReceipt()
		{
			MessageBox.Show("Please make sure there's a paper in your printer. Click OK when ready.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
			printDocument1.DocumentName = string.Format("{0}--{1}", RemittancePartnerConfiguration.PartnerCode, _remittancePartnerPayoutTransaction.PayoutTransactionResult.TransactionNumber);

			bool printStatus = false;
			do
			{
				try
				{
					if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\act_newform_InternationalRemittance.txt"))
					{
						NewPrintSettings();
					}
					else
					{
						printDocument1.Print();
					}
					printStatus = true;
					lblProcessingStatus.BackColor = Color.DeepSkyBlue;
					lblProcessingStatus.Text = "Transaction Complete";
				}
				catch
				{
					DialogResult dialogResult = MessageBox.Show("An error has occured while printing this receipt. Please make sure a printer is online and there is paper in the tray.\n\nClick OK to try printing again\nClick Cancel to cancel printing right now.", "Print", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
					if (dialogResult == DialogResult.Cancel)
					{
						break;
					}
				}
			}
			while (printStatus == false);

			if (printStatus == false)
			{
				MessageBox.Show("Warning: Printing was not completed. Please make sure that you print a receipt by clicking \"Print Receipt\".", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				lblProcessingStatus.BackColor = Color.Orange;
				lblProcessingStatus.Text = "Receipt not printed.";
			}
		}

		private void ClearForm()
		{
			if (_isCalledFromStaticMethod)
			{
				CloseForm();
			}
			else
			{
				if (_remittancePartnerLookupTransaction != null && _remittancePartnerLookupTransaction.LookupTransactionResult.ResultCode == TransFastControlLibrary.Utils.LookupTransactionResultCode.Successful)
				{
					if (_remittancePartnerPayoutTransaction == null || _remittancePartnerPayoutTransaction.PayoutTransactionResult.ResultCode != TransFastControlLibrary.Utils.PayoutTransactionResultCode.Successful)
					{
						MessageBox.Show("Placeholder for clearing form after lookup with no corresponding payout", "Placeholder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}

				InitializePayoutForm();
			}
		}

		private void CloseForm()
		{
			if (_isCalledFromStaticMethod)
			{
				if (_remittancePartnerLookupTransaction != null && _remittancePartnerLookupTransaction.LookupTransactionResult.ResultCode == TransFastControlLibrary.Utils.LookupTransactionResultCode.Successful)
				{
					if (_remittancePartnerPayoutTransaction == null || _remittancePartnerPayoutTransaction.PayoutTransactionResult.ResultCode != TransFastControlLibrary.Utils.PayoutTransactionResultCode.Successful)
					{
						this.DialogResult = DialogResult.Abort;
					}
				}

				this.Close();
				this.Dispose();
			}
			else
			{
				if (_remittancePartnerLookupTransaction != null && _remittancePartnerLookupTransaction.LookupTransactionResult.ResultCode == TransFastControlLibrary.Utils.LookupTransactionResultCode.Successful)
				{
					if (_remittancePartnerPayoutTransaction == null || _remittancePartnerPayoutTransaction.PayoutTransactionResult.ResultCode != TransFastControlLibrary.Utils.PayoutTransactionResultCode.Successful)
					{
						MessageBox.Show("Placeholder for closing form after lookup with no corresponding payout", "Placeholder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}

				this.Close();
				this.Dispose();
			}
		}

		private void ValidateForm()
		{
			if (ValidateControls() == false)
			{
				Utils.ToggleControlEnabledState(false, _inputProcessingControls);
				lblProcessingStatus.Text = "Please enter customer validation and sender details.";
				lblProcessingStatus.BackColor = Color.PaleGoldenrod;
				return;
			}
			else
			{
				DateTime dateIssued = new DateTime(1900, 1, 1);
				DateTime dateExpiry = new DateTime(1900, 1, 1);

				switch (cboCustomerIDSubmitted.SelectedValue.ToString())
				{
					case "DLC":
					case "PSS":
						#region //DateIssued
						if (mskCustomerIDIssuedDate.Text.Replace("/", string.Empty).Trim().Length.Equals(8))
						{
							try
							{
								DateTime.TryParse(mskCustomerIDIssuedDate.Text, out dateIssued);
								DateTime.Parse(mskCustomerIDIssuedDate.Text);
								//Issued date validation
								TimeSpan issued = dateIssued.Subtract(DateTime.Now);
								if (issued.TotalDays > 0)
								{
									Utils.ToggleControlEnabledState(false, _inputProcessingControls);
									lblProcessingStatus.Text = "Issued date should not be GREATER than the date today.";
									lblProcessingStatus.BackColor = Color.PaleGoldenrod;
									return;
								}
							}
							catch
							{
								Utils.ToggleControlEnabledState(false, _inputProcessingControls);
								lblProcessingStatus.Text = "Please enter customer ID issued date appropriately.";
								lblProcessingStatus.BackColor = Color.PaleGoldenrod;
								return;
							}
						}
						else
						{
							Utils.ToggleControlEnabledState(false, _inputProcessingControls);
							lblProcessingStatus.Text = "Please enter customer ID issued date.";
							lblProcessingStatus.BackColor = Color.PaleGoldenrod;
							return;
						}
						#endregion

						#region//ExpiryDate

						if (mskCustomerIDExpiryDate.Text.Replace("/", string.Empty).Trim().Length.Equals(8))
						{
							try
							{
								DateTime.TryParse(mskCustomerIDExpiryDate.Text, out dateExpiry);
								DateTime.Parse(mskCustomerIDExpiryDate.Text);
								TimeSpan expired = DateTime.Now.Subtract(dateExpiry);
								if (expired.Days > 0)
								{
									Utils.ToggleControlEnabledState(false, _inputProcessingControls);
									lblProcessingStatus.Text = "ID presented should not be EXPIRED.";
									lblProcessingStatus.BackColor = Color.PaleGoldenrod;
									return;
								}
							}
							catch
							{
								Utils.ToggleControlEnabledState(false, _inputProcessingControls);
								lblProcessingStatus.Text = "Please enter customer ID expiry date appropriately.";
								lblProcessingStatus.BackColor = Color.PaleGoldenrod;
								return;
							}
						}
						else
						{
							Utils.ToggleControlEnabledState(false, _inputProcessingControls);
							lblProcessingStatus.Text = "Please enter customer ID expiry date.";
							lblProcessingStatus.BackColor = Color.PaleGoldenrod;
							return;
						}
						#endregion

						#region//Issued and Expiry Date Validation
						if ((mskCustomerIDIssuedDate.Text.Replace("/", string.Empty).Trim().Length > 0
							&& mskCustomerIDExpiryDate.Text.Replace("/", string.Empty).Trim().Length > 0))
						{

							TimeSpan diff = dateExpiry.Subtract(dateIssued);
							if (diff.Days <= 0)
							{
								Utils.ToggleControlEnabledState(false, _inputProcessingControls);
								lblProcessingStatus.Text = "Please ensure that the Expiry Date is GREATER than Issued Date.";
								lblProcessingStatus.BackColor = Color.PaleGoldenrod;
								return;
							}
						}
						#endregion
						break;
                    default:
						if ((mskCustomerIDIssuedDate.Text.Replace("/", string.Empty).Trim().Length > 0
							|| mskCustomerIDExpiryDate.Text.Replace("/", string.Empty).Trim().Length > 0))
						{
							#region //DateIssued
							if (mskCustomerIDIssuedDate.Text.Replace("/", string.Empty).Trim().Length > 0)
							{
								if (mskCustomerIDIssuedDate.Text.Replace("/", string.Empty).Trim().Length.Equals(8))
								{
									try
									{
										DateTime.TryParse(mskCustomerIDIssuedDate.Text, out dateIssued);
										DateTime.Parse(mskCustomerIDIssuedDate.Text);
										TimeSpan issued = dateIssued.Subtract(DateTime.Now);
										if (issued.Days > 0)
										{
											Utils.ToggleControlEnabledState(false, _inputProcessingControls);
											lblProcessingStatus.Text = "Issued date should not be GREATER than the date today.";
											lblProcessingStatus.BackColor = Color.PaleGoldenrod;
											return;
										}
									}
									catch
									{
										Utils.ToggleControlEnabledState(false, _inputProcessingControls);
										lblProcessingStatus.Text = "Please enter customer ID issued date appropriately.";
										lblProcessingStatus.BackColor = Color.PaleGoldenrod;
										return;
									}
								}
								else
								{
									Utils.ToggleControlEnabledState(false, _inputProcessingControls);
									lblProcessingStatus.Text = "Please enter customer ID issued date appropriately.";
									lblProcessingStatus.BackColor = Color.PaleGoldenrod;
									return;
								}
							}
							#endregion

							#region//ExpiryDate
							if (mskCustomerIDExpiryDate.Text.Replace("/", string.Empty).Trim().Length > 0)
							{
								if (mskCustomerIDExpiryDate.Text.Replace("/", string.Empty).Trim().Length.Equals(8))
								{
									try
									{
										DateTime.TryParse(mskCustomerIDExpiryDate.Text, out dateExpiry);
										DateTime.Parse(mskCustomerIDExpiryDate.Text);
										TimeSpan expired = DateTime.Now.Subtract(dateExpiry);
										if (expired.Days > 0)
										{
											Utils.ToggleControlEnabledState(false, _inputProcessingControls);
											lblProcessingStatus.Text = "ID presented should not be EXPIRED.";
											lblProcessingStatus.BackColor = Color.PaleGoldenrod;
											return;
										}
									}
									catch
									{
										Utils.ToggleControlEnabledState(false, _inputProcessingControls);
										lblProcessingStatus.Text = "Please enter customer ID expiry date appropriately.";
										lblProcessingStatus.BackColor = Color.PaleGoldenrod;
										return;
									}
								}
								else
								{
									Utils.ToggleControlEnabledState(false, _inputProcessingControls);
									lblProcessingStatus.Text = "Please enter customer ID expiry date appropriately.";
									lblProcessingStatus.BackColor = Color.PaleGoldenrod;
									return;
								}
							}
							#endregion

							#region//Issued and Expiry Date Validation
							if ((mskCustomerIDIssuedDate.Text.Replace("/", string.Empty).Trim().Length > 0
								&& mskCustomerIDExpiryDate.Text.Replace("/", string.Empty).Trim().Length > 0))
							{

								TimeSpan diff = dateExpiry.Subtract(dateIssued);
								if (diff.Days <= 0)
								{
									Utils.ToggleControlEnabledState(false, _inputProcessingControls);
									lblProcessingStatus.Text = "Please ensure that the Expiry Date is GREATER than Issued Date.";
									lblProcessingStatus.BackColor = Color.PaleGoldenrod;
									return;
								}
							}
							#endregion

						}
						break;
				}

			}

			Utils.ToggleControlEnabledState(true, _inputProcessingControls);
			lblProcessingStatus.Text = "Click Process Payout to payout transaction.";
			lblProcessingStatus.BackColor = Color.LightGreen;
		}

		private bool ValidateControls()
		{
			if (cboCustomerIDSubmitted.SelectedIndex < 0
				|| txtCustomerIDSubmittedNumber.Text.Trim() == string.Empty
				)
			{
				return false;
			}

			if (cboSendingCountry.Items.Count > 0)
			{
				if (cboSendingCountry.SelectedIndex < 0)
				{
					return false;
				}
			}

			if (cboSendingState.Items.Count > 0)
			{
				if (cboSendingState.SelectedIndex < 0)
				{
					return false;
				}
			}

			if (optEmailAddress.Checked == true)
			{
				if (txtEmailAddress.Text.Trim() == string.Empty)
				{
					return false;
				}
			}

			if (optMobileNumber.Checked == true)
			{
				if (cboPhoneCode.SelectedIndex < 0
					|| txtMobileNumber.Text.Trim() == string.Empty
				)
				{
					return false;
				}
			}



			return true;
		}

		private bool ValidateInputs()
		{
			if (optEmailAddress.Checked == true)
			{
				if (Utils.CheckString(txtEmailAddress.Text.Trim(), Utils.CheckStringMode.EmailAddress) == false)
				{
					MessageBox.Show("Email address format is invalid.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}

			if (optMobileNumber.Checked == true)
			{
				if (Utils.CheckString(txtMobileNumber.Text.Trim(), Utils.CheckStringMode.Numeric) == false)
				{
					MessageBox.Show("Mobile number field should only contain numbers.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}

			if (optMobileNumber.Checked == true)
			{
				if (txtMobileNumber.Text.Trim().Length > 20)
				{
					MessageBox.Show("Mobile number field should contain 20 characters or less.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				if (txtMobileNumber.Text.Trim().Length < 4)
				{
					MessageBox.Show("Mobile number field should contain at least 4 digits.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

			}

			if (cboCustomerIDSubmitted.SelectedIndex > 0)
			{
				if (Utils.CheckString(txtCustomerIDSubmittedNumber.Text.Trim(), Utils.CheckStringMode.AlphaNumericWithDashes) == false)
				{
					MessageBox.Show("Please input a valid Customer ID number.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				if (txtCustomerIDSubmittedNumber.Text.Trim().Length < 3)
				{
					MessageBox.Show("ID number field should contain at least 3 digits.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}

				if (txtCustomerIDSubmittedNumber.Text.Trim().Length > 20)
				{
					MessageBox.Show("ID number field should only contain a maximum of 20 characters.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}

			if (cboCustomerIDSubmitted.Text == "24k Card(Domestic Padala)")
			{
				MessageBox.Show("24k Card is only acceptable for domestic remittance transaction.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			return true;
		}

		#endregion

		#region Events

		private void PayoutForm_Load(object sender, EventArgs e)
		{
			try
			{
				BuildCountryList();
				BuildCustomerIDTypesList();
				BindSendingCountryList();
				BindCountryPhoneCodeList();
				cboCustomerIDSubmitted.DropDownWidth = DropDownWidth(cboCustomerIDSubmitted);
				Token = Utils.GenerateToken(txtReferenceNumber.Text);

				if (Token == "0")
				{
					MessageBox.Show("No Token Generated.", "Generate Token", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					this.Close();
					this.Dispose();
					return;
				}
			}
			catch (Exception error)
			{
				Utils.DisplayErrorMessageBox(error);
				CloseForm();
				return;
			}

			if (_isCalledFromStaticMethod)
			{
				btnClearAll.Enabled = false;
			}

			if (!string.IsNullOrEmpty(txtReferenceNumber.Text))
			{
				LookupReferenceNumber();
			}
		}

		private void btnLoadReferenceNumber_Click(object sender, EventArgs e)
		{
			LookupReferenceNumber();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (progressBar1.Value == 100)
			{
				progressBar1.Value = 0;
			}
			else
			{
				progressBar1.Value = progressBar1.Value + 1;
			}
		}

		private void backgroundWorkerRemittanceLookup_DoWork(object sender, DoWorkEventArgs e)
		{
			LookupTransaction lookupTransaction = e.Argument as LookupTransaction;
			lookupTransaction.Lookup();
			e.Result = lookupTransaction;
			LookupStatusCode = lookupTransaction.LookupTransactionResult.ResultCode.ToString();
		}

		private void backgroundWorkerRemittanceLookup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			timer1.Stop();
			progressBar1.Value = 100;
			lblProcessingStatus.Text = "Done.";

			if (e.Error != null)
			{
				lblProcessingStatus.Text = "Error";
				lblProcessingStatus.BackColor = Color.Red;
				Utils.DisplayErrorMessageBox(e.Error);
				ClearForm();
			}
			else if (e.Cancelled == true)
			{
				lblProcessingStatus.Text = "Processing cancelled.";
				lblProcessingStatus.BackColor = Color.Blue;
				MessageBox.Show("Lookup cancelled.", "Cancelled.", MessageBoxButtons.OK, MessageBoxIcon.Information);
				ClearForm();
			}
			else if (e.Result == null)
			{
				lblProcessingStatus.Text = "Error";
				lblProcessingStatus.BackColor = Color.Red;
				MessageBox.Show("No result received. Please contact ICT Support Desk", "Result Missing", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				ClearForm();
			}
			else
			{
				LookupTransaction lookupTransaction = e.Result as LookupTransaction;
				_remittancePartnerLookupTransaction = lookupTransaction;
				ProcessLookupTransactionResult();
			}

			progressBar1.Value = 0;
		}

		private void optEmailAddress_CheckedChanged(object sender, EventArgs e)
		{
			txtEmailAddress.Enabled = optEmailAddress.Checked;
			txtEmailAddress.Text = string.Empty;
			ValidateForm();
		}

		private void optMobileNumber_CheckedChanged(object sender, EventArgs e)
		{
			Utils.ToggleControlEnabledState(
				optMobileNumber.Checked,
				cboPhoneCode,
				txtMobileNumber);

			Utils.ClearControls(
				lblPhoneCode,
				cboPhoneCode,
				txtMobileNumber);

			ValidateForm();
		}

		private void txtEmailAddress_TextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void txtMobileNumber_TextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void cboSendingCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				BindStateList();
			}
			catch (Exception error)
			{
				Utils.DisplayErrorMessageBox(error);
				CloseForm();
				return;
			}

			ValidateForm();
		}

		private void cboSendingState_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void cboPhoneCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboPhoneCode.SelectedIndex >= 0)
			{
				lblPhoneCode.Text = cboPhoneCode.SelectedValue.ToString();
			}
			else
			{
				lblPhoneCode.Text = string.Empty;
			}

			ValidateForm();
		}

		private void cboCustomerIDSubmitted_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void txtCustomerIDSubmittedNumber_TextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void mskCustomerIDIssuedDate_TextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}
		private void mskCustomerIDExpiryDate_TextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}
		private void btnProcessPayout_Click(object sender, EventArgs e)
		{
			if (ValidateInputs() == false)
				return;

			PayoutReferenceNumber();
		}

		private void backgroundWorkerRemittancePayout_DoWork(object sender, DoWorkEventArgs e)
		{
			PayoutTransaction payoutTransaction = e.Argument as PayoutTransaction;
			payoutTransaction.Payout();
			e.Result = payoutTransaction;
			PayoutStatusCode = payoutTransaction.PayoutTransactionResult.ResultCode.ToString();

		}

		private void backgroundWorkerRemittancePayout_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			timer1.Stop();
			progressBar1.Value = 100;
			lblProcessingStatus.Text = "Done";

			if (e.Error != null)
			{
				lblProcessingStatus.Text = "Error";
				lblProcessingStatus.BackColor = Color.Red;
				Utils.DisplayErrorMessageBox(e.Error);
			}
			else if (e.Cancelled == true)
			{
				lblProcessingStatus.Text = "Processing cancelled";
				lblProcessingStatus.BackColor = Color.Blue;
				MessageBox.Show("Payout cancelled.", "Cancelled.", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Utils.ToggleControlEnabledState(
					true,
					_inputCustomerControls,
					_inputCustomerValidationControls,
					_inputProcessingControls);

			}
			else if (e.Result == null)
			{
				lblProcessingStatus.Text = "Error";
				lblProcessingStatus.BackColor = Color.Red;
				MessageBox.Show("No result received. Please contact ICT Support Desk", "Result Missing", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				Utils.ToggleControlEnabledState(
					true,
					_inputCustomerControls,
					_inputCustomerValidationControls,
					_inputProcessingControls);
			}
			else
			{
				PayoutTransaction payoutTransaction = e.Result as PayoutTransaction;
				_remittancePartnerPayoutTransaction = payoutTransaction;
				ProcessPayoutTransactionResult();
			}

			progressBar1.Value = 0;
		}

		private void btnPrintReceipt_Click(object sender, EventArgs e)
		{
			PrintReceipt();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			PrintParameters printParameters = new PrintParameters();
			printParameters.ReferenceNumber = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.TransactionNumber;
			printParameters.TransactionDate = _remittancePartnerPayoutTransaction.PayoutTransactionResult.PayoutDate;
			printParameters.CustomerNumber = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverCustomerNumber;
			printParameters.SendingBranch = RemittancePartnerConfiguration.PartnerName;
			string senderName = string.IsNullOrEmpty(_remittancePartnerPayoutTransaction.PayoutTransactionRequest.SenderFirstName) ?
											string.IsNullOrEmpty(_remittancePartnerPayoutTransaction.PayoutTransactionRequest.SenderLastName)
																? _remittancePartnerPayoutTransaction.PayoutTransactionRequest.SenderFullName : _remittancePartnerPayoutTransaction.PayoutTransactionRequest.SenderLastName
											: String.Format("{0}, {1}", _remittancePartnerPayoutTransaction.PayoutTransactionRequest.SenderLastName, _remittancePartnerPayoutTransaction.PayoutTransactionRequest.SenderFirstName);
			printParameters.SenderName = senderName;
			string receiverName = string.IsNullOrEmpty(_remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverFirstName) ?
											string.IsNullOrEmpty(_remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverLastName)
																? _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverFullName : _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverLastName
											: String.Format("{0}, {1}", _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverLastName, _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverFirstName);
			printParameters.ReceiverName = receiverName;
			printParameters.PayoutBranch = String.Format("{0} {1}", _parentRemittancePartnerControlMain.BranchInformation.BranchCode, _parentRemittancePartnerControlMain.BranchInformation.BranchName);
			printParameters.PrincipalAmountCurrency = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.PayoutCurrency;
			printParameters.PrincipalAmount = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.PayoutAmount;
			printParameters.ServiceCharge = decimal.Zero;
			printParameters.DiscountAmount = decimal.Zero;
			printParameters.BranchUserID = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.CebuanaBranchInformation.BranchUserID;
			printParameters.BranchOperatingHours = Utils.GetBranchOperatingHours(_remittancePartnerPayoutTransaction.PayoutTransactionRequest.CebuanaBranchInformation.BranchCode);
			Utils.PrintRemittanceReceipt(printParameters, e);
		}

		private void btnClearAll_Click(object sender, EventArgs e)
		{
			if (!(backgroundWorkerRemittanceLookup.IsBusy || backgroundWorkerRemittancePayout.IsBusy))
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear this form?", "Clear Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

				if (dialogResult == DialogResult.Yes)
				{
					ClearForm();
				}
			}
		}

		private void btnCloseForm_Click(object sender, EventArgs e)
		{
			if (!(backgroundWorkerRemittanceLookup.IsBusy || backgroundWorkerRemittancePayout.IsBusy))
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this form?", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

				if (dialogResult == DialogResult.Yes)
				{
					CloseForm();
				}
			}
		}

		#endregion

		private void groupBoxPayoutProcessing_Enter(object sender, EventArgs e)
		{

		}
		#region For NRPF
		public void NewPrintSettings()
		{
			PrintParameters printParameters = new PrintParameters();
#if DEBUG
			printParameters.MarketingMessage = "Have a good day.";
#else
            printParameters.MarketingMessage = B2BUtilities.GlobalFunction.GetCompMessage();
#endif
			printParameters.ReferenceNumber = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.TransactionNumber;
			printParameters.TransactionDate = _remittancePartnerPayoutTransaction.PayoutTransactionResult.PayoutDate;
			printParameters.CustomerNumber = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverCustomerNumber;
			printParameters.SendingBranch = RemittancePartnerConfiguration.PartnerName;
			string senderName = String.Format("{0}, {1}", _remittancePartnerPayoutTransaction.PayoutTransactionRequest.SenderLastName, _remittancePartnerPayoutTransaction.PayoutTransactionRequest.SenderFirstName);
			printParameters.SenderName = Utils.AddEllipsisFullName(senderName, 28);
			string receiverName = String.Format("{0}, {1}", _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverLastName, _remittancePartnerPayoutTransaction.PayoutTransactionRequest.ReceiverFirstName);
			printParameters.ReceiverName = Utils.AddEllipsisFullName(receiverName, 28);
			printParameters.PayoutBranch = String.Format("{0} {1}", _parentRemittancePartnerControlMain.BranchInformation.BranchCode, _parentRemittancePartnerControlMain.BranchInformation.BranchName);
			printParameters.PrincipalAmountCurrency = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.PayoutCurrency;
			printParameters.PrincipalAmount = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.PayoutAmount;
			printParameters.ServiceCharge = decimal.Zero;
			printParameters.DiscountAmount = decimal.Zero;
			printParameters.BranchUserID = _remittancePartnerPayoutTransaction.PayoutTransactionRequest.CebuanaBranchInformation.BranchUserID;
			printParameters.BranchOperatingHours = Utils.GetBranchOperatingHours(_remittancePartnerPayoutTransaction.PayoutTransactionRequest.CebuanaBranchInformation.BranchCode);


			string[] detailArray = new string[16];
			detailArray[0] = string.Format("#{0}", printParameters.ReferenceNumber); // Control number
			detailArray[1] = printParameters.PayoutBranch;  // Payout branch
			detailArray[2] = printParameters.BranchOperatingHours; // Business hours
			detailArray[3] = printParameters.ReceiverName; // Receiver Name
			detailArray[4] = printParameters.CustomerNumber; // Client number
			// detailArray[5] = decimal.Zero.ToString(); // CLP Points
			detailArray[6] = printParameters.MarketingMessage; // Company Message 1
			detailArray[7] = string.Format("SENDER : {0}", printParameters.SenderName); // Sender Name     
			detailArray[8] = printParameters.SendingBranch; // Remittance Partner
			detailArray[9] = printParameters.TransactionDate.ToString("MM/dd/yyyy HH:mm"); // Date
			detailArray[10] = printParameters.BranchUserID; // Processed by
			detailArray[11] = printParameters.PrincipalAmount.ToString(); // Principal amount
			detailArray[12] = printParameters.ServiceCharge.ToString(); // Service charge
			detailArray[13] = printParameters.DiscountAmount.ToString(); // Discount
			detailArray[14] = printParameters.TotalAmount.ToString(); // Total
			detailArray[15] = printParameters.PrincipalAmountCurrency.ToString(); // Currency

			//************************************* PRINT from xml file *************************************//
			//PrintModule.PrintUtil.PrintFromFile(@"C:\Users\esfranco\Desktop\InternationalPayoutNew.xml", detailArray);            

			//************************************* PRINT from database *************************************//
#if DEBUG
			PrintModule.PrintUtil.Print("NRPF-InternationalPayout", detailArray, true);
#else
            PrintModule.PrintUtil.Print("NRPF-InternationalPayout", detailArray, false);
#endif
		}
		#endregion

		private new void KeyPress(object sender, KeyPressEventArgs e)
		{
			//Added: 04.02.2014 -Keng
			Control ctrl = sender as Control;
			int ctrlTag = Convert.ToInt32(ctrl.Tag);
			bool isValid = false;

			switch (ctrlTag)
			{
				case 0:
					isValid = Utils.KeyTrapping(Utils.KeyTrappingType.Alpha, e);
					break;
				case 1:
					isValid = Utils.KeyTrapping(Utils.KeyTrappingType.Numeric, e);
					break;
				case 2:
					isValid = Utils.KeyTrapping(Utils.KeyTrappingType.AlphaNumeric, e);
					break;
				case 3:
					isValid = Utils.KeyTrapping(Utils.KeyTrappingType.AlphaSpecialChar, e);
					break;
				case 4:
					isValid = Utils.KeyTrapping(Utils.KeyTrappingType.NumericSpecialChar, e);
					break;
				case 5:
					isValid = Utils.KeyTrapping(Utils.KeyTrappingType.AlphaNumericSpecialChar, e);
					break;
				default:
					isValid = false;
					break;
			}

			if (ctrl.Name.Equals("txtCustomerIDSubmittedNumber"))
			{
				if (e.KeyChar == '-')
				{
					isValid = Utils.TrapConsecutiveSpaces(string.Format("{0}{1}", Utils._Alpha, Utils._Numeric), txtCustomerIDSubmittedNumber);
				}
				else if (e.KeyChar == 32)
				{
					isValid = Utils.TrapConsecutiveSpaces(string.Format("{0}{1}-", Utils._Alpha, Utils._Numeric), txtCustomerIDSubmittedNumber);
				}
			}

			if (ctrl.Name.Equals("txtMobileNumber"))
			{
				if (e.KeyChar == 32)
				{
					isValid = true;
				}
			}

			e.Handled = isValid;
		}

		private void PayoutForm_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		int DropDownWidth(ComboBox myCombo)
		{
			int maxWidth = 0;
			int temp = 0;
			Graphics g = myCombo.CreateGraphics();
			Label label1 = new Label();
			Font font = myCombo.Font;
			int width = myCombo.DropDownWidth;
			int vertScrollBarWidth = (myCombo.Items.Count > myCombo.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

			foreach (var obj in myCombo.Items)
			{
				label1.Text = obj.ToString();
				temp = label1.PreferredWidth;

				maxWidth = (int)g.MeasureString(label1.Text, font).Width + vertScrollBarWidth;

				if (width < maxWidth)
				{
					width = maxWidth;
				}
			}
			label1.Dispose();
			return width;
		}

	}
}
