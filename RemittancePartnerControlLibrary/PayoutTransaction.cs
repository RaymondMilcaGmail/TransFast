using System;
using System.Net;
using System.Web.Services.Protocols;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace TransFastControlLibrary
{
    class PayoutTransaction
    {
		#region Constructors

		internal PayoutTransaction(PayoutTransactionRequest payoutTransactionRequest)
		{
			_payoutTransactionRequest = payoutTransactionRequest;
		}

		string webResult = string.Empty;

		#endregion

		#region Fields

		private string _webServiceURL;

		private PayoutTransactionRequest _payoutTransactionRequest;

		private PayoutTransactionResult _payoutTransactionResult;

		#endregion

		#region Properties

		internal string WebServiceURL
		{
			get { return _webServiceURL; }
			set { _webServiceURL = value; }
		}

		internal PayoutTransactionRequest PayoutTransactionRequest
		{
			get { return _payoutTransactionRequest; }
			//set { _payoutTransactionRequest = value; }
		}

		internal PayoutTransactionResult PayoutTransactionResult
		{
			get { return _payoutTransactionResult; }
			//set { _payoutTransactionResult = value; }
		}

		#endregion

		#region Methods

		internal void Payout()
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
							BranchAreaCode = _payoutTransactionRequest.CebuanaBranchInformation.BranchAreaCode,
							BranchCode = _payoutTransactionRequest.CebuanaBranchInformation.BranchCode,
							BranchName = _payoutTransactionRequest.CebuanaBranchInformation.BranchName,
							BranchRegionCode = _payoutTransactionRequest.CebuanaBranchInformation.BranchRegionCode,
							BranchUserID = _payoutTransactionRequest.CebuanaBranchInformation.BranchUserID,
							ClientApplicationVersion = _payoutTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion,
							ClientMacAddress = _payoutTransactionRequest.CebuanaBranchInformation.ClientMacAddress
						},
						CurrencyConversionRate = _payoutTransactionRequest.CurrencyConversionRate,
						PartnerCode = _payoutTransactionRequest.PartnerCode,
						PayTokenID = _payoutTransactionRequest.PayTokenID,
						PayoutAmount = _payoutTransactionRequest.PayoutAmount,
						PayoutAmountWithServiceCharge = _payoutTransactionRequest.PayoutAmountWithServiceCharge,
						PayoutCountry = _payoutTransactionRequest.PayoutCountry,
						PayoutCurrency = _payoutTransactionRequest.PayoutCurrency,
						PayoutID = _payoutTransactionRequest.PayoutID,
						ReceiverCity = _payoutTransactionRequest.ReceiverCity,
						ReceiverCountry = _payoutTransactionRequest.ReceiverCountry,
						ReceiverCustomerNumber = _payoutTransactionRequest.ReceiverCustomerNumber,
						ReceiverFirstName = _payoutTransactionRequest.ReceiverFirstName,
						ReceiverFullName = _payoutTransactionRequest.ReceiverFullName,
						ReceiverIDCode = _payoutTransactionRequest.ReceiverIDCode,
						ReceiverIDExpiryDate = _payoutTransactionRequest.ReceiverIDExpiryDate,
						ReceiverIDIssuedDate = _payoutTransactionRequest.ReceiverIDIssuedDate,
						ReceiverIDNumber = _payoutTransactionRequest.ReceiverIDNumber,
						ReceiverIDType = _payoutTransactionRequest.ReceiverIDType,
						ReceiverLastName = _payoutTransactionRequest.ReceiverLastName,
						SenderCountry = _payoutTransactionRequest.SenderCountry,
						SenderEmail = _payoutTransactionRequest.SenderEmail,
						SenderFirstName = _payoutTransactionRequest.SenderFirstName,
						SenderFullName = _payoutTransactionRequest.SenderFullName,
						SenderID = _payoutTransactionRequest.SenderID,
						SenderLastName = _payoutTransactionRequest.SenderLastName,
						SenderMobileNumber = _payoutTransactionRequest.SenderMobileNumber,
						SenderState = _payoutTransactionRequest.SenderState,
						SendingCurrency = _payoutTransactionRequest.SendingCurrency,
						Token = _payoutTransactionRequest.Token,
                        TransactionNumber = _payoutTransactionRequest.TransactionNumber,
                        AssignToken = _payoutTransactionRequest.AssignToken,
                        InvoiceUpdateID = _payoutTransactionRequest.InvoiceUpdateID,
                        InvoiceStatus = _payoutTransactionRequest.InvoiceStatus
                    },
					PullMethod = Utils.PullMethod.Payout.ToString(),
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

				postData = JsonConvert.SerializeObject(pullRemittanceRequestJSON, Newtonsoft.Json.Formatting.Indented);

				#endregion

				string result = string.Empty;

				Utils.IgnoreBadCertificates();

				string jsonResponse = Utils.InvokeHttpMethod(uri, postData);

				Utils.WriteToEventLog(string.Format("PullRemittancePayout-Process{2}PayoutTransaction:{0} | {1}", uri, postData, RemittancePartnerConfiguration.PartnerCode.Substring(0, 3))
									 , System.Diagnostics.EventLogEntryType.Information);

				PullRemittanceResult pullTransactionResponse = JsonConvert.DeserializeObject<PullRemittanceResult>(jsonResponse);

				_payoutTransactionResult = pullTransactionResponse.PayoutTransactionResult;
				
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
