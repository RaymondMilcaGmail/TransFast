using System;
using System.Configuration;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WesternUnionWCF.Classes
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

		public static string StoredProcedureUpdatePayoutTransaction
		{
			get { return ConfigurationManager.AppSettings["StoredProcedureUpdatePayoutTransaction"].ToString(); }
		}

		public static string ConnectionStringRemittanceDatabase
		{
			get { return ConfigurationManager.ConnectionStrings["RemittanceDBConnection"].ToString(); }
		}

		public static bool InsertLog
		{
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["InsertLog"]) ? false : false; }
		}

		internal static bool UseDefaultProxy
		{
			get
			{
				string useDefaultProxy = ConfigurationManager.AppSettings["UseDefaultProxy"] ?? "True";
				return (string.IsNullOrEmpty(useDefaultProxy) ? true : Convert.ToBoolean(useDefaultProxy));
			}
		}

		public static string LogSource
		{
			get { return ConfigurationManager.AppSettings["LogSource"] != null ? ConfigurationManager.AppSettings["LogSource"] : string.Empty; }
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

        #region Partner Settings
        public static string GetMultiCurrencyPayoutCode
        {
            get { return ConfigurationManager.AppSettings["PayoutCodeUSD"].ToString(); }
        }

        public static string UserName
        {
            get { return ConfigurationManager.AppSettings["UserName"] != null ? ConfigurationManager.AppSettings["UserName"] : string.Empty; }
        }

        public static string PassWord
        {
            get { return ConfigurationManager.AppSettings["PassWord"] != null ? ConfigurationManager.AppSettings["PassWord"] : string.Empty; }
        }

        public static string PartnerCode
        {
            get { return ConfigurationManager.AppSettings["PartnerCode"] != null ? ConfigurationManager.AppSettings["PartnerCode"] : string.Empty; }
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