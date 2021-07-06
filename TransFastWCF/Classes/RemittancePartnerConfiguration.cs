using System;
using System.Configuration;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace TransFastWCFService.Classes
{
    public class RemittancePartnerConfiguration
	{
		public static string ApplicationName
		{
            get { return ConfigurationManager.AppSettings["ApplicationName"].ToString(); }
		}

		public static string ApplicationCode
		{
            get { return ConfigurationManager.AppSettings["ApplicationCode"].ToString(); }
		}


        public static string EntityLogin
        {
            get { return ConfigurationManager.AppSettings["EntityLogin"].ToString(); }
        }
        public static string EntityPass
        {
            get { return ConfigurationManager.AppSettings["EntityPass"].ToString(); }
        }
        public static string TerminalID
        {
            get { return ConfigurationManager.AppSettings["TerminalID"].ToString(); }
        }


        public static string TransfastHeader
        {
            get { return ConfigurationManager.AppSettings["TransfastHeader"].ToString(); }
        }


        public static string GetAutorization
        {
            get { return ConfigurationManager.AppSettings["CoGetAutorization"].ToString(); }
        }

        public static string GetFiles
        {
            get { return ConfigurationManager.AppSettings["GetFiles"].ToString(); }
        }


        public static string CommitFile
        {
            get { return ConfigurationManager.AppSettings["CommitFile"].ToString(); }
        }


        public static string UpdateTransaction
        {
            get { return ConfigurationManager.AppSettings["UpdateTransaction"].ToString(); }
        }


        public static bool LoggingActivated
        {
            get
            {
                return ((ConfigurationManager.AppSettings["LoggingActivated"] != null)
                  ? Convert.ToBoolean(ConfigurationManager.AppSettings["LoggingActivated"]) : false);
            }
        }

        public static bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["IgnoreSslErrors"]))
            {
                return true;
            }
            else
            {
                return policyErrors == SslPolicyErrors.None;
            }
        }

        public static string ConnectionStringRemittanceDatabase
		{
			get { return ConfigurationManager.ConnectionStrings["RemittanceDBConnection"].ToString(); }
		}

        public static string StoredProcedureInsertPayoutTransaction
        {
            get { return ConfigurationManager.AppSettings["StoredProcedureInsertPayoutTransaction"].ToString(); }
        }

        public static string StoredProcedureUpdatePayoutTransaction
        {
            get { return ConfigurationManager.AppSettings["StoredProcedureUpdatePayoutTransaction"].ToString(); }
        }

        public static string GetAppSettingsValue(string appSettingsKey)
		{
			string appSettingsValue;
			appSettingsKey = appSettingsKey.Trim().ToUpper();

			if (ConfigurationManager.AppSettings[appSettingsKey] != null)
			{
				appSettingsValue = ConfigurationManager.AppSettings[appSettingsKey];
			}
			else
			{
				appSettingsValue = string.Empty;
			}

			return appSettingsValue;
		}

        #region Proxy Setting
        public static WebProxy WebProxy
        {
            get
            {
                try
                {
                    string proxyHost = ConfigurationManager.AppSettings["ProxyHost"];
                    int proxyPort = Convert.ToInt32(ConfigurationManager.AppSettings["ProxyPort"]);
                    string proxyUsername = ConfigurationManager.AppSettings["ProxyUsername"];
                    string proxyPassword = ConfigurationManager.AppSettings["ProxyPassword"];
                    string proxyDomain = ConfigurationManager.AppSettings["ProxyDomain"];

                    if (proxyHost == null || proxyPort == 0)
                    {
                        return null;
                    }

                    WebProxy webProxy = new WebProxy(proxyHost, proxyPort);

                    if (proxyUsername == null || proxyPassword == null)
                    {
                        return webProxy;
                    }

                    if (proxyDomain == null)
                    {
                        webProxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword);
                    }
                    else
                    {
                        webProxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword, proxyDomain);
                    }

                    return webProxy;
                }
                catch
                {
                    return null;
                }
            }
        }

        internal static bool UseDefaultProxy
        {
            get
            {
                string useDefaultProxy = ConfigurationManager.AppSettings["UseDefaultProxy"] ?? "True";
                return (string.IsNullOrEmpty(useDefaultProxy) ? true : Convert.ToBoolean(useDefaultProxy));
            }
        }

        public static string ProxyHost
        {
            get { return ConfigurationManager.AppSettings["ProxyHost"] != null ? ConfigurationManager.AppSettings["ProxyHost"] : string.Empty; }
        }

        public static string ProxyPort
        {
            get { return ConfigurationManager.AppSettings["ProxyPort"] != null ? ConfigurationManager.AppSettings["ProxyPort"] : string.Empty; }
        }
        #endregion

        #region Partner Settings
        public static decimal PHPMaxPayoutLimit
        {
            get { return Convert.ToDecimal(ConfigurationManager.AppSettings["PHPMaxPayoutLimit"]); }
        }
        public static decimal USDMaxPayoutLimit
        {
            get { return Convert.ToDecimal(ConfigurationManager.AppSettings["USDMaxPayoutLimit"]); }
        }
        public static string GetMultiCurrencyPayoutCode
        {
            get { return ConfigurationManager.AppSettings["PayoutCodeUSD"].ToString(); }
        }

        public static string WS_URL
        {
            get { return ConfigurationManager.AppSettings["WS_URL"] != null ? ConfigurationManager.AppSettings["WS_URL"] : string.Empty; }
        }

        public static string Lookup_Endpoint
        {
            get { return ConfigurationManager.AppSettings["Lookup_Endpoint"] != null ? ConfigurationManager.AppSettings["Lookup_Endpoint"] : string.Empty; }
        }

        public static string Payout_Endpoint
        {
            get { return ConfigurationManager.AppSettings["Payout_Endpoint"] != null ? ConfigurationManager.AppSettings["Payout_Endpoint"] : string.Empty; }
        }

        public static string Password
        {
            get { return ConfigurationManager.AppSettings["Password"] != null ? ConfigurationManager.AppSettings["Password"] : string.Empty; }
        }

        public static string SecurityKey
        {
            get { return ConfigurationManager.AppSettings["SecurityKey"] != null ? ConfigurationManager.AppSettings["SecurityKey"] : string.Empty; }
        }

        public static string URL_FORMAT
        {
            get { return "{0}/{1}"; }
        }

        public static string Credentials
        {
            get { return string.Format("password={0}&securityKey={1}", Password, SecurityKey); }
        }

        public static string POSTData
        {
            get { return string.Format("{0}&transactionNo={1}&uniqueID={2}", Credentials, "{0}", "{1}"); }
        }

        public static string TokenCredentials
        {
            get { return string.Format("EntityLogin={0}&EntityPass={1}", EntityLogin, EntityPass); }
        }

        public static string POSTDataGetToken
        {
            get { return string.Format("EntityType={0}&EntityCode={1}&{2}&TerminalID={3}", 5, 0, TokenCredentials, TerminalID); }
        }
        public static string POSTData_Payout
        {
            get { return string.Format("{0}{1}", POSTData, "&vendorTxNumber={1}"); }
        }   

        #endregion

        #region Security Settings
        public static bool TLSActivated
        {
            get
            {
                return ((ConfigurationManager.AppSettings["isTLS12"] != null)
                  ? Convert.ToBoolean(ConfigurationManager.AppSettings["isTLS12"]) : false);
            }
        }

        public static Int32 SecurityProtocolType
        {
            get { return ConfigurationManager.AppSettings["SecurityProtocolType"] != null ? Convert.ToInt32(ConfigurationManager.AppSettings["SecurityProtocolType"]) : 0; }
        }

        public static string RemittanceSecretKey
		{
            get { return ConfigurationManager.AppSettings["RemittanceSecretKey"] != null ? ConfigurationManager.AppSettings["RemittanceSecretKey"].ToString() : string.Empty; }
		}

		public static int TokenExpiration
		{
			get { return ConfigurationManager.AppSettings["TokenExpiration"] != null ? Convert.ToInt32(ConfigurationManager.AppSettings["TokenExpiration"]) : 0; }
		}
		#endregion
	}
}