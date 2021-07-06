using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Services.Protocols;
using TransFastWCF.TransFastRespopnse;
using TransFastWCFService.Classes;

namespace TransFastWCFService
{
    [WebService(Namespace = "http://PJLIPushRemittance.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [AspNetCompatibilityRequirements(
           RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TransFastWCF : ITransFastWCF
    {
        #region Constructor
        public TransFastWCF()
        { }
        #endregion

        #region Web Methods
        public PullRemittanceResult RemittancePartnerLookup(PullRemittanceRequest pullTransactionRequest)
        {
            PullRemittanceResult pullRemittanceResult = new PullRemittanceResult();
            try
            {
                LookupTransactionResult lookupTransactionResult = new LookupTransactionResult();
                bool isValidToken = TokenGen.Token.IsValid(pullTransactionRequest.LookupTransactionRequest.Token, RemittancePartnerConfiguration.RemittanceSecretKey, TimeSpan.FromMinutes(RemittancePartnerConfiguration.TokenExpiration));

                if (isValidToken == false)
                {
                    lookupTransactionResult.ResultCode = LookupTransactionResultCode.Unsuccessful;
                    lookupTransactionResult.MessageToClient = "[REM999] Invalid Token.";

                    pullRemittanceResult.LookupTransactionResult = lookupTransactionResult;

                    return pullRemittanceResult;
                }
                else
                {
                    return RemittancePartnerLookup_01(pullTransactionRequest.LookupTransactionRequest);
                }
            }
            catch (Exception ex)
            {
                Utils.WriteToEventLog(string.Format("RemittancePartnerLookup:[{0}] {1}", RemittancePartnerConfiguration.ApplicationCode, ex.Message), System.Diagnostics.EventLogEntryType.Error);

                LookupTransactionResult lookupTransactionResult = new LookupTransactionResult
                {
                    ResultCode = LookupTransactionResultCode.ServerError,
                    MessageToClient = ex.Message
                };

                pullRemittanceResult.LookupTransactionResult = lookupTransactionResult;

                return pullRemittanceResult;
            }
        }

        public PullRemittanceResult RemittancePartnerPayout(PullRemittanceRequest pullTransactionRequest)
        {
            PullRemittanceResult pullRemittanceResult = new PullRemittanceResult();
            try
            {
                PayoutTransactionResult payoutTransactionResult = new PayoutTransactionResult();
                bool isValidToken = TokenGen.Token.IsValid(pullTransactionRequest.PayoutTransactionRequest.Token, RemittancePartnerConfiguration.RemittanceSecretKey, TimeSpan.FromMinutes(RemittancePartnerConfiguration.TokenExpiration));

                if (isValidToken == false)
                {
                    payoutTransactionResult.ResultCode = PayoutTransactionResultCode.Unsuccessful;
                    payoutTransactionResult.MessageToClient = "[REM999] Invalid Token.";

                    pullRemittanceResult.PayoutTransactionResult = payoutTransactionResult;

                    return pullRemittanceResult;
                }
                else
                {
                    return RemittancePartnerPayout_01(pullTransactionRequest.PayoutTransactionRequest);
                }
            }
            catch (Exception ex)
            {
                Utils.WriteToEventLog(string.Format("RemittancePartnerPayout:[{0}] {1}", RemittancePartnerConfiguration.ApplicationCode, ex.Message), System.Diagnostics.EventLogEntryType.Error);

                PayoutTransactionResult payoutTransactionResult = new PayoutTransactionResult
                {
                    ResultCode = PayoutTransactionResultCode.ServerError,
                    MessageToClient = ex.Message
                };

                pullRemittanceResult.PayoutTransactionResult = payoutTransactionResult;

                return pullRemittanceResult;
            }
        }

        public string GenerateToken(GenerateTokenParameters generateTokenParameters)
        {
            string token = string.Empty;
            bool isValidSecretKey = Utils.ValidateSecretKey(generateTokenParameters.SecretKey, generateTokenParameters.ReferenceNumber, Convert.ToDateTime(generateTokenParameters.DateTime));
            try
            {
                if (isValidSecretKey == true)
                {
                    token = TokenGen.Token.Generate(RemittancePartnerConfiguration.RemittanceSecretKey, TimeSpan.FromMinutes(RemittancePartnerConfiguration.TokenExpiration));
                }
                else
                {
                    token = "0";
                }
            }
            catch (Exception ex)
            {
                token = "0";
                Utils.WriteToEventLog(string.Format("GenerateToken:[{0}] {1}", RemittancePartnerConfiguration.ApplicationCode, ex.Message), System.Diagnostics.EventLogEntryType.Error);
            }
            return token;
        }
        #endregion

        #region Methods
        private PullRemittanceResult RemittancePartnerLookup_01(LookupTransactionRequest lookupTransactionRequest)
        {
            PullRemittanceResult pullRemittanceResult = new PullRemittanceResult();
            try
            {
                pullRemittanceResult.LookupTransactionResult = lookupTransactionRequest.LookupTransaction();
                return pullRemittanceResult;
            }
            catch (Exception error)
            {
                Utils.WriteToEventLog(string.Format("RemittancePartnerLookup_01:{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);

                LookupTransactionResult errorResponse = new LookupTransactionResult();
                errorResponse.ResultCode = LookupTransactionResultCode.ServerError;

                if (error is RemittanceException)
                {
                    errorResponse.MessageToClient = error.Message;
                }
                else if (error is SoapException)
                {
                    errorResponse.MessageToClient = "An error in the partner's web service has occured while looking up the transaction.";
                }
                else if (error is WebException || error is CommunicationException)
                {
                    errorResponse.MessageToClient = "An error in the connection to the partner's web service has occured while looking up the transaction. Please try again later.";
                }
                else
                {
                    errorResponse.MessageToClient = "An error has occured while retrieving the transaction details from the partner. Please contact ICT Support Desk.";
                }

                #region default values
                errorResponse.TransactionDate = DateTime.Now;
                errorResponse.PayoutCountry = "PH";
                errorResponse.MultiCurrencyPayoutCode = "";

                errorResponse.SenderFirstName = "";
                errorResponse.SenderLastName = "";
                errorResponse.SenderFullName = "";
                errorResponse.SenderCountry = "";

                errorResponse.BeneficiaryFirstName = "";
                errorResponse.BeneficiaryLastName = "";
                errorResponse.BeneficiaryFullName = "";
                errorResponse.BeneficiaryPhoneNumber = "";

                errorResponse.PayoutAmount = 0;
                errorResponse.PayoutAmountWithServiceCharge = 0;
                errorResponse.PayoutCurrency = "";
                #endregion

                pullRemittanceResult.LookupTransactionResult = errorResponse;

                return pullRemittanceResult;
            }
        }

        private PullRemittanceResult RemittancePartnerPayout_01(PayoutTransactionRequest payoutTransactionRequest)
        {
            PullRemittanceResult pullRemittanceResult = new PullRemittanceResult();
            try
            {
                pullRemittanceResult.PayoutTransactionResult = payoutTransactionRequest.PayoutTransaction(payoutTransactionRequest);
                return pullRemittanceResult;
            }
            catch (Exception error)
            {
                Utils.WriteToEventLog(string.Format("RemittancePartnerPayout_01:{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);

                PayoutTransactionResult errorResponse = new PayoutTransactionResult();
                errorResponse.ResultCode = PayoutTransactionResultCode.ServerError;

                if (error is RemittanceException)
                {
                    errorResponse.MessageToClient = error.Message;
                }
                else if (error is SoapException)
                {
                    errorResponse.MessageToClient = "An error in the partner's web service has occured while paying out the transaction.";
                }
                else if (error is WebException || error is CommunicationException)
                {
                    errorResponse.MessageToClient = "An error in the connection to the partner's web service has occured while paying out the transaction. Please try again later.";
                }
                else
                {
                    errorResponse.MessageToClient = "An error has occured while paying out the transaction. Please contact ICT Support Desk.";
                }

                errorResponse.TransactionNumber = payoutTransactionRequest.TransactionNumber;
                errorResponse.PayoutDate = DateTime.Now;
                pullRemittanceResult.PayoutTransactionResult = errorResponse;

                return pullRemittanceResult;
            }
        }


        public string RequestToken(DataTransactionResult dataTransactionResult)
        {
            string Token = string.Empty;
            PullRemittanceResult pullRemittanceResult = new PullRemittanceResult();
            try
            {
                Token = dataTransactionResult.GetToken();
                TokenResponse responseDetails = JsonConvert.DeserializeObject<TokenResponse>(Token);
                if (responseDetails.ReturnResult.ToString() != "0")
                {
                    DataTransactionResult errorResponse = new DataTransactionResult();
                    errorResponse.ResultCode = LookupTransactionResultCode.ServerError;
                    errorResponse.MessageToClient = "An error has occured while retrieving Token from the partner. Please contact ICT Support Desk.";
                }
                return Token;
            }
            catch (Exception error)
            {
                Utils.WriteToEventLog(string.Format("RequestToken:{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);

                LookupTransactionResult errorResponse = new LookupTransactionResult();
                errorResponse.ResultCode = LookupTransactionResultCode.ServerError;

                if (error is RemittanceException)
                {
                    errorResponse.MessageToClient = error.Message;
                }
                else if (error is SoapException)
                {
                    errorResponse.MessageToClient = "An error in the partner's web service has occured while reqeusting for Token.";
                }
                else if (error is WebException || error is CommunicationException)
                {
                    errorResponse.MessageToClient = "An error in the connection to the partner's web service has occured while requesting for Token. Please try again later.";
                }
                else
                {
                    errorResponse.MessageToClient = "An error has occured while retrieving Token from the partner. Please contact ICT Support Desk.";
                }

                return Token;
            }
        }

        public string ProcessTransaction(DataTransactionResult dataTransactionResult)
        {
            string Token = dataTransactionResult.AssignToken;
            string result = string.Empty;
            string FunctionName = dataTransactionResult.FunctionName;
            try
            {
                Token = dataTransactionResult.AssignToken;
                if (Token == "")
                {
                    DataTransactionResult errorResponse = new DataTransactionResult();
                    errorResponse.ResultCode = LookupTransactionResultCode.ServerError;
                    errorResponse.MessageToClient = "An error has occured while accessing the data from the partner. Please contact ICT Support Desk.";
                }
                else
                {
                    result = dataTransactionResult.ProcessTransaction();
                }
                return result;
            }
            catch (Exception error)
            {
                Utils.WriteToEventLog(string.Format("ProcessTransaction " + FunctionName +":{0}", error.Message), System.Diagnostics.EventLogEntryType.Error);

                LookupTransactionResult errorResponse = new LookupTransactionResult();
                errorResponse.ResultCode = LookupTransactionResultCode.ServerError;

                if (error is RemittanceException)
                {
                    errorResponse.MessageToClient = error.Message;
                }
                else if (error is SoapException)
                {
                    errorResponse.MessageToClient = "An error in the partner's web service has occured while accessing the data.";
                }
                else if (error is WebException || error is CommunicationException)
                {
                    errorResponse.MessageToClient = "An error in the connection to the partner's web service has occured while accessing the data. Please try again later.";
                }
                else
                {
                    errorResponse.MessageToClient = "An error has occured while accessing the data from the partner. Please contact ICT Support Desk.";
                }

                return result;
            }
        }
        #endregion
    }
}
