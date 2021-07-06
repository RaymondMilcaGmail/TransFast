using System;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.Web;
using System.Xml;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransFastWCFService.Classes
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

        public static string CreateSessionID()
        {
            CustomSession manager = new CustomSession();
            return manager.CreateSessionID(HttpContext.Current);
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

        public static string ProcessTransactionRequest(string uri, string request)
        {
            string result = string.Empty;

            HttpWebRequest httpWebRequest = WebRequest.Create(@uri) as HttpWebRequest;

            byte[] data = Encoding.UTF8.GetBytes(request);

            if(!RemittancePartnerConfiguration.UseDefaultProxy)
                httpWebRequest.Proxy = RemittancePartnerConfiguration.WebProxy;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = data.Length;

            using (Stream newStream = httpWebRequest.GetRequestStream())
            {
                newStream.Write(data, 0, data.Length);
            }

            using (WebResponse response = httpWebRequest.GetResponse())
            {
                // Get the stream containing content returned by the server.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content.
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        public static string ProcessRequest(string uri, string request)
        {
            string result = string.Empty;

            HttpWebRequest httpWebRequest = WebRequest.Create(@uri) as HttpWebRequest;

            byte[] data = Encoding.UTF8.GetBytes(request);

            if (!RemittancePartnerConfiguration.UseDefaultProxy)
                httpWebRequest.Proxy = RemittancePartnerConfiguration.WebProxy;
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = data.Length;

            using (Stream newStream = httpWebRequest.GetRequestStream())
            {
                newStream.Write(data, 0, data.Length);
            }

            using (WebResponse response = httpWebRequest.GetResponse())
            {
                // Get the stream containing content returned by the server.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content.
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        public static string ProcessRequest(string uri, string request, string header)
        {
            string result = string.Empty;

            HttpWebRequest httpWebRequest = WebRequest.Create(@uri) as HttpWebRequest;

            //convert request to Json
            var dict1 = HttpUtility.ParseQueryString(request);
            var dict = new Dictionary<string, string>();
            foreach (string key in dict1.Keys)
            {
                dict.Add(key, dict1[key]);
            }
            string json = JsonConvert.SerializeObject(dict);
            //end convert

            if (!RemittancePartnerConfiguration.UseDefaultProxy)
                httpWebRequest.Proxy = RemittancePartnerConfiguration.WebProxy;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Headers[RemittancePartnerConfiguration.TransfastHeader] = header;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            using (WebResponse response = httpWebRequest.GetResponse())
            {
                // Get the stream containing content returned by the server.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content.
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }
        public static string ProcessSecuredRequest(string uri, string request, string token)
        {
            string result = string.Empty;

            HttpWebRequest httpWebRequest = WebRequest.Create(@uri) as HttpWebRequest;

            byte[] data = Encoding.UTF8.GetBytes(request);

            if (!RemittancePartnerConfiguration.UseDefaultProxy)
                httpWebRequest.Proxy = RemittancePartnerConfiguration.WebProxy;
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = data.Length;

            using (Stream newStream = httpWebRequest.GetRequestStream())
            {
                newStream.Write(data, 0, data.Length);
            }

            using (WebResponse response = httpWebRequest.GetResponse())
            {
                // Get the stream containing content returned by the server.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content.
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }
    }
}