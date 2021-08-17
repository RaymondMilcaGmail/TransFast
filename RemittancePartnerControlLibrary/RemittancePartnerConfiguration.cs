using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using AppCryptor;
using System.Data;
using System.Windows.Forms;
using System.Net;

namespace TransFastControlLibrary
{
    class RemittancePartnerConfiguration
    {
        internal static string PartnerName
        {
			get { return "Trans-Fast S.A."; }
        }

        internal static string PartnerCode
        {
            get { return "TFS-PL"; }
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

		internal static string PullRemAdapterURL
		{
			get { return ConfigurationManager.AppSettings["PullRemAdapterURL"]; }
		}

		internal static string WebServiceURL
		{
			get { return ConfigurationManager.AppSettings["WebServiceURL"]; }
		}

        internal static string DBRemittanceConnectionString
        {
            get
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DBRemittance_ConnectionString"].ToString();
                    string connectionPassword = ConfigurationManager.AppSettings["DBRemittance_ConnStrPwd"];
                    string decryptedConnectionPassword;
                    try
                    {
                        decryptedConnectionPassword = AESCrypt.EncryptDecrypt(connectionPassword, "Decrypt");
                    }
                    catch
                    {
                        decryptedConnectionPassword = connectionPassword;
                    }

                    return string.Format("{0}{1};", connectionString, decryptedConnectionPassword);
                }
                catch (Exception error)
                {
                    throw new RemittanceException("An error has occured while getting the Remittance database configuration. Please contact ICT Support Desk.", error);
                }
            }
        }

        internal static int WebServiceCallTimeout
        {
            get { return 100000; }
        }

        internal static CebuanaCustomerID[] GetCebuanaCustomerIDs()
        {
            SqlConnection dbRemittanceConnection = new SqlConnection();
            try
            {
                dbRemittanceConnection.ConnectionString = RemittancePartnerConfiguration.DBRemittanceConnectionString;
                SqlCommand dbRemittanceCommand = new SqlCommand("dbo.GetRequiredID", dbRemittanceConnection);
                dbRemittanceCommand.CommandType = System.Data.CommandType.StoredProcedure;
                List<CebuanaCustomerID> cebuanaCustomerIDs = new List<CebuanaCustomerID>();
                dbRemittanceConnection.Open();
                SqlDataReader dbRemittanceReader = dbRemittanceCommand.ExecuteReader();
                while (dbRemittanceReader.Read())
                {
                    CebuanaCustomerID cebuanaCustomerID = new CebuanaCustomerID();
                    cebuanaCustomerID.IDCode = dbRemittanceReader["fldIDCode"].ToString();
                    cebuanaCustomerID.IDDescription = dbRemittanceReader["fldIDDescription"].ToString();
                    cebuanaCustomerIDs.Add(cebuanaCustomerID);
                }

                cebuanaCustomerIDs.Sort((x, y) => x.IDDescription.CompareTo(y.IDDescription));

                return cebuanaCustomerIDs.ToArray();
            }
            catch (RemittanceException remittanceError)
            {
                throw remittanceError;
            }
            catch (Exception error)
            {
                throw new RemittanceException("An error has occured while getting the required IDs list from the database. Please contact ICT Support Desk.", error);
            }
            finally
            {
                dbRemittanceConnection.Close();
            }
        }
    }
}
