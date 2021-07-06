using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using WesternUnionWCF.Classes;
using System.ServiceModel.Activation;
using System.Globalization;

namespace WesternUnionWCF
{
    [WebService(Namespace = "http://PJLIPushRemittance.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [AspNetCompatibilityRequirements(
           RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WesternUnionWCF : IWesternUnionWCF
    {
        #region Constructor
        public WesternUnionWCF()
        { }
        #endregion

        #region Web Methods
        public PullRemittanceResult RemittancePartnerLookup(PullRemittanceRequest pullTransactionRequest)
        {
            PullRemittanceResult pullRemittanceResult = new PullRemittanceResult();
            try
            {
                if (VerifyIClickVersionFormat(pullTransactionRequest.LookupTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion))
                {
                    string iClickVersion = pullTransactionRequest.LookupTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion.Replace(".", string.Empty);
                    if (Convert.ToInt32(iClickVersion) >= RemittancePartnerConfiguration.iClickVersion)
                    {
                        #region Validate Token
                        LookupTransactionResult lookupTransactionResult = new LookupTransactionResult();
                        bool isValidToken = TokenGen.Token.IsValid(pullTransactionRequest.LookupTransactionRequest.Token, RemittancePartnerConfiguration.PullRemSecretKey, TimeSpan.FromMinutes(RemittancePartnerConfiguration.TokenExpiration));
                        if (isValidToken == false)
                        {
                            throw new WebFaultException<string>("[REM999] Invalid Request.", HttpStatusCode.BadRequest);
                        }
                        else
                        {
                            return RemittancePartnerLookup_01(pullTransactionRequest.LookupTransactionRequest);
                        }

                        #endregion
                    }

                    switch (pullTransactionRequest.LookupTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion)
                    {
                        default:
                            return RemittancePartnerLookup_01(pullTransactionRequest.LookupTransactionRequest);
                    }
                }
                else
                {
                    Utils.WriteToEventLog(string.Format("RemittancePartnerPayout: IClick Application Version Format verification failed. iClick Application Version supplied: \"{0}\"", pullTransactionRequest.LookupTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion), System.Diagnostics.EventLogEntryType.Error);
                    throw new WebFaultException<string>("[REM999] Invalid Request.", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                Utils.WriteToEventLog(string.Format("RemittancePartnerLookup:[{0}] {1}", RemittancePartnerConfiguration.ApplicationCode, ex.Message), System.Diagnostics.EventLogEntryType.Error);
                throw new WebFaultException<string>("[REM999] Invalid Request.", HttpStatusCode.BadRequest);
            }
        }

        public PullRemittanceResult RemittancePartnerPayout(PullRemittanceRequest pullTransactionRequest)
        {
            PullRemittanceResult pullRemittanceResult = new PullRemittanceResult();
            try
            {
                if (VerifyIClickVersionFormat(pullTransactionRequest.PayoutTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion))
                {
                    string iClickVersion = pullTransactionRequest.PayoutTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion.Replace(".", string.Empty);
                    if (Convert.ToInt32(iClickVersion) >= RemittancePartnerConfiguration.iClickVersion)
                    {
                        #region Validate Token
                        PayoutTransactionResult payoutTransactionResult = new PayoutTransactionResult();
                        bool isValidToken = TokenGen.Token.IsValid(pullTransactionRequest.PayoutTransactionRequest.Token, RemittancePartnerConfiguration.PullRemSecretKey, TimeSpan.FromMinutes(RemittancePartnerConfiguration.TokenExpiration));
                        if (isValidToken == false)
                        {
                            throw new WebFaultException<string>("[REM999] Invalid Request.", HttpStatusCode.BadRequest);
                        }
                        else
                        {
                            return RemittancePartnerPayout_01(pullTransactionRequest.PayoutTransactionRequest);
                        }

                        #endregion
                    }

                    switch (pullTransactionRequest.PayoutTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion)
                    {
                        default:
                            return RemittancePartnerPayout_01(pullTransactionRequest.PayoutTransactionRequest);
                    }
                }
                else
                {
                    Utils.WriteToEventLog(string.Format("RemittancePartnerPayout: IClick Application Version Format verification failed. iClick Application Version supplied: \"{0}\"", pullTransactionRequest.PayoutTransactionRequest.CebuanaBranchInformation.ClientApplicationVersion), System.Diagnostics.EventLogEntryType.Error);
                    throw new WebFaultException<string>("[REM999] Invalid Request.", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                Utils.WriteToEventLog(string.Format("RemittancePartnerPayout:[{0}] {1}", RemittancePartnerConfiguration.ApplicationCode, ex.Message), System.Diagnostics.EventLogEntryType.Error);
                throw new WebFaultException<string>("[REM999] Invalid Request.", HttpStatusCode.BadRequest);
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

                return pullRemittanceResult;
            }
        }
        #endregion
    }
}
