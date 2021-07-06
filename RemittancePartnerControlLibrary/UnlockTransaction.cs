using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Web.Services.Protocols;

namespace TransFastControlLibrary
{
	class UnlockTransaction
	{
		#region Fields
		private string _LookupStatusCode;
		private string _PayoutStatusCode;
		private string _SecretKey;
		private string _PaytokenID; //max money token id
		private string _token;
		private string _RefNo;
		string webResult = string.Empty;

		internal UnlockTransaction(UnlockTransactionRequest unlockTransactionRequest)
		{
			_unlockTransactionRequest = unlockTransactionRequest;
		}

		private UnlockTransactionRequest _unlockTransactionRequest;
		private UnlockTransactionResult _unlockTransactionResult;

		#endregion

		#region Properties

		internal UnlockTransactionRequest UnlockTransactionRequest
		{
			get { return _unlockTransactionRequest; }
		}

		internal UnlockTransactionResult UnlockTransactionResult
		{
			get { return _unlockTransactionResult; }
		}

		public string Token
		{
			get { return _token; }
			set { _token = value; }
		}

		public string LookupStatusCode
		{
			get { return _LookupStatusCode; }
			set { _LookupStatusCode = value; }
		}

		public string PayoutStatusCode
		{
			get { return _PayoutStatusCode; }
			set { _PayoutStatusCode = value; }
		}

		public string SecretKey
		{
			get { return _SecretKey; }
			set { _SecretKey = value; }
		}

		public string PaytokenID
		{
			get { return _PaytokenID; }
			set { _PaytokenID = value; }
		}

		public string RefNo
		{
			get { return _RefNo; }
			set { _RefNo = value; }
		}
		#endregion

		#region Methods

		internal void Unlock()
		{
			try
			{
				string uri = string.Format("{0}/{1}", RemittancePartnerConfiguration.PullRemAdapterURL, "ConnectToPullPartnerViaREST");
				string postData = string.Empty;

				#region Serializing JSON Request

				PullRemittanceRequest pullRemittanceRequestJSON = new PullRemittanceRequest
				{
					LookupTransactionRequest = new LookupTransactionRequest
					{
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

						PartnerCode = string.Empty,
						PayTokenID = string.Empty,
						Token = string.Empty,
						TransactionNumber = string.Empty
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
					PullMethod = Utils.PullMethod.Payout.ToString(),
					UnlockTransactionRequest = new UnlockTransactionRequest
					{
						AccessCode = string.Empty,
						AgentSessionID = _unlockTransactionRequest.AgentSessionID,
						ClientApplicationVersion = _unlockTransactionRequest.ClientApplicationVersion,
						PartnerCode = _unlockTransactionRequest.PartnerCode,
						PayTokenID = _unlockTransactionRequest.PayTokenID,
						RefNo = _unlockTransactionRequest.RefNo,
						Signature = _unlockTransactionRequest.Signature,
						Token = _unlockTransactionRequest.Token,
						UserName = _unlockTransactionRequest.UserName
					}
				};

				postData = JsonConvert.SerializeObject(pullRemittanceRequestJSON, Newtonsoft.Json.Formatting.Indented);

				#endregion

				string result = string.Empty;

				Utils.IgnoreBadCertificates();

				string jsonResponse = Utils.InvokeHttpMethod(uri, postData);

				Utils.WriteToEventLog(string.Format("PullRemittancePayout-Process{2}PayoutTransaction:{0} | {1}", uri, postData, RemittancePartnerConfiguration.PartnerCode.Substring(0, 3))
									 , System.Diagnostics.EventLogEntryType.Information);

				PullRemittanceResult pullTransactionResponse = JsonConvert.DeserializeObject<PullRemittanceResult>(jsonResponse);

				_unlockTransactionResult = pullTransactionResponse.UnlockTransactionResult;

			}
			catch (Exception error)
			{
				if (error is RemittanceException)
				{
					throw error;
				}
				else if (error is WebException)
				{
					if (error.Message.Contains("403") || error.Message.Contains("405")) //check if internal partner web service is up
					{
						throw new RemittanceException("Partner is temporarily deactivated due to insufficient funds and awaiting fund replenishment. Apply the standard spiel and do not refer the client to our direct competitor. Please try again later.");
					}
					else
					{
						throw new RemittanceException("An error has occured while paying out this transaction.", error);
					}
				}
				else if (error is SoapException)
				{
					throw new RemittanceException("An error in the web service has occured while paying out this transaction. ", error);
				}
				else
				{
					throw new RemittanceException("An error has occured while paying out this transaction. ", error);
				}
			}
		}
		#endregion
	}
}
