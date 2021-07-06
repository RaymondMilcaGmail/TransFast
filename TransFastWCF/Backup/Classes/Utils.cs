using System;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace WesternUnionWCF.Classes
{
    public class Utils
	{
		public static void WriteToEventLog(string logMessage, EventLogEntryType eventLogEntryType)
		{
			try
			{
				if (!EventLog.SourceExists(RemittancePartnerConfiguration.ApplicationName, "."))
				{
					EventSourceCreationData eventSourceCreationData = new EventSourceCreationData(RemittancePartnerConfiguration.ApplicationName, "Application");
					EventLog.CreateEventSource(eventSourceCreationData);
				}

				using (EventLog eventLog = new EventLog("Application", ".", RemittancePartnerConfiguration.ApplicationName))
				{
					EventLogEntryCollection evec = eventLog.Entries;
					eventLog.WriteEntry(logMessage, eventLogEntryType);
				}
			}
			catch (Exception)
			{
			}
		}

		public static string FilterValidCharacters(string textParam, string validCharactersParam)
		{
			StringBuilder returnValue = new StringBuilder();

			char[] arytextParam = textParam.ToCharArray();

			Array.ForEach<char>(arytextParam, delegate(char text)
			{
				if (validCharactersParam.Contains(text.ToString().ToUpper()))
				{
					returnValue.Append(text.ToString());
				}
			});
			return returnValue.ToString();
		}

		public static string ComputeSha256Hash(string rawData)
		{
			// Create a SHA256   
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// ComputeHash - returns byte array  
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

				// Convert byte array to a string   
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}

        public static bool ValidateSecretKey(string secretKey, string transactionNumber, DateTime requestDateTime)
        {
            bool isValid = false;

            #region Secret Key
            string validSecretKey = B2BUtilities.GlobalFunction.ComputeHash_SHA512_V2(transactionNumber, RemittancePartnerConfiguration.ApplicationCode, requestDateTime);
            #endregion

            if (validSecretKey.ToLower() != secretKey.ToLower())
            {
                Utils.WriteToEventLog(string.Format("ValidateSecretKey:[{0}] {1}", RemittancePartnerConfiguration.ApplicationCode, "Invalid Secret Key!"), System.Diagnostics.EventLogEntryType.Error);
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }
	}
}