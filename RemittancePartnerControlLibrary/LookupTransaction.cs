using System;
using System.Net;
using System.Web.Services.Protocols;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace TransFastControlLibrary
{
	class LookupTransaction
	{
		#region Contructors

		internal LookupTransaction(LookupTransactionRequest lookupTransactionRequest)
		{
			_lookupTransactionRequest = lookupTransactionRequest;
		}

		string webResult = string.Empty;

		private LookupTransaction()
			: this(null)
		{ }

		#endregion

		#region Fields

		private string _webServiceURL;

		private LookupTransactionRequest _lookupTransactionRequest;

		private LookupTransactionResult _lookupTransactionResult;

		#endregion

		#region Properties

		internal string WebServiceURL
		{
			get { return _webServiceURL; }
			set { _webServiceURL = value; }
		}

		internal LookupTransactionResult LookupTransactionResult
		{
			get { return _lookupTransactionResult; }
			set { _lookupTransactionResult = value; }
		}

		#endregion

		#region Methods

		internal void Lookup()
		{
			try
			{
				string uri = string.Format("{0}/{1}", RemittancePartnerConfiguration.PullRemAdapterURL, "ConnectToPullPartnerViaREST");
				string postData = string.Empty;

				#region Serializing JSON Request


				PullRemittanceResult pullRemittanceResult = new PullRemittanceResult();

				PullRemittanceRequest pullRemittanceRequest = new PullRemittanceRequest
				{
					LookupTransactionRequest = new LookupTransactionRequest
					{
						CebuanaBranchInformation = new CebuanaBranchInformation
						{
							BranchAreaCode = _lookupTransactionRequest.CebuanaBranchInformation.BranchAreaCode,
							BranchCode = _lookupTransactionRequest.CebuanaBranchInformation.BranchCode,
							BranchName = _lookupTransactionRequest.CebuanaBranchInformation.BranchName,
							BranchRegionCode = _lookupTransactionRequest.CebuanaBranchInformation.BranchRegionCode,
							BranchUserID = _lookupTransactionRequest.CebuanaBranchInformation.BranchUserID,
							ClientApplicationVersion = _lookupTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion,
							ClientMacAddress = _lookupTransactionRequest.CebuanaBranchInformation.ClientMacAddress
						},

						PartnerCode = _lookupTransactionRequest.PartnerCode,
						PayTokenID = _lookupTransactionRequest.PayTokenID,
						Token = _lookupTransactionRequest.Token,
						TransactionNumber = _lookupTransactionRequest.TransactionNumber
					},

					PayoutTransactionRequest = new PayoutTransactionRequest
					{
						BeneficiaryPhoneNumber = string.Empty,
						CebuanaBranchInformation = new CebuanaBranchInformation
						{
							BranchAreaCode = string.Empty,
							BranchCode = string.Empty,
							BranchName = string.Empty,
							BranchRegionCode = string.Empty,
							BranchUserID = string.Empty,
							ClientApplicationVersion = string.Empty,
							ClientMacAddress = string.Empty
						},
						CurrencyConversionRate = 0,
						PartnerCode = string.Empty,
						PayTokenID = string.Empty,
						PayoutAmount = 0,
						PayoutAmountWithServiceCharge = 0,
						PayoutCountry = string.Empty,
						PayoutCurrency = string.Empty,
						PayoutID = string.Empty,
						ReceiverCity = string.Empty,
						ReceiverCountry = string.Empty,
						ReceiverCustomerNumber = string.Empty,
						ReceiverFirstName = string.Empty,
						ReceiverFullName = string.Empty,
						ReceiverIDCode = string.Empty,
						ReceiverIDExpiryDate = string.Empty,
						ReceiverIDIssuedDate = string.Empty,
						ReceiverIDNumber = string.Empty,
						ReceiverIDType = string.Empty,
						ReceiverLastName = string.Empty,
						SenderCountry = string.Empty,
						SenderEmail = string.Empty,
						SenderFirstName = string.Empty,
						SenderFullName = string.Empty,
						SenderID = string.Empty,
						SenderLastName = string.Empty,
						SenderMobileNumber = string.Empty,
						SenderState = string.Empty,
						SendingCurrency = string.Empty,
						Token = string.Empty,
						TransactionNumber = string.Empty
					},
					PullMethod = Utils.PullMethod.Lookup.ToString(),
					UnlockTransactionRequest = new UnlockTransactionRequest
					{
						AccessCode = string.Empty,
						AgentSessionID = string.Empty,
						ClientApplicationVersion = string.Empty,
						PartnerCode = string.Empty,
						PayTokenID = string.Empty,
						RefNo = string.Empty,
						Signature = string.Empty,
						Token = string.Empty,
						UserName = string.Empty
					}
				};

				postData = JsonConvert.SerializeObject(pullRemittanceRequest, Newtonsoft.Json.Formatting.Indented);

				#endregion

				string result = string.Empty;

				Utils.IgnoreBadCertificates();

				string jsonResponse = Utils.InvokeHttpMethod(uri, postData);

				Utils.WriteToEventLog(string.Format("PullRemittancePayout-Process{2}LookupTransaction:{0} | {1}", uri, postData, RemittancePartnerConfiguration.PartnerCode.Substring(0,3))
										, System.Diagnostics.EventLogEntryType.Information);

				PullRemittanceResult pullTransactionResponse = JsonConvert.DeserializeObject<PullRemittanceResult>(jsonResponse);

				_lookupTransactionResult = pullTransactionResponse.LookupTransactionResult;

			}
			catch (Exception error)
			{
				if (error is RemittanceException)
				{
					throw error;
				}
				else if (error is WebException)
				{
					throw new RemittanceException("Reference number lookup failed. Branch may be OFFLINE.", error);
				}
				else if (error is SoapException)
				{
					throw new RemittanceException("An error in the web service has occured while looking up this transaction. ", error);
				}
				else
				{
					throw new RemittanceException("An error has occured while looking up this transaction. ", error);
				}
			}
		}

		public static void IgnoreBadCertificates()
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
		}

		#endregion
	}
}
