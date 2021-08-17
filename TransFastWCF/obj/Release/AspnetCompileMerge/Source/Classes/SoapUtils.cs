using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Web.Services.Protocols;
using System.IO;
using System.Globalization;

internal class SoapUtils
{
	private static readonly string _soapEnvelope = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope\" xmlns:xsd=\"http://services.xm.org/xsd\">\n<soapenv:Body>\n{0}</soapenv:Body>\n</soapenv:Envelope>";
	private static readonly string _faultEnvelope = "<soapenv:Fault>\n{0}</soapenv:Fault>";

	private static string Serialize<T>(T objectInstance)
	{
		try
		{
			if (objectInstance == null)
			{
				return string.Empty;
			}

			using (MemoryStream memoryStream = new MemoryStream())
			{
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				xmlWriterSettings.Indent = true;
				xmlWriterSettings.OmitXmlDeclaration = true;
				xmlWriterSettings.ConformanceLevel = ConformanceLevel.Document;
				xmlWriterSettings.CloseOutput = true;

				using (XmlWriter writer = XmlWriter.Create(memoryStream, xmlWriterSettings))
				//using (XmlTextWriter writer = XmlTextWriter.XmlTextWriter(memoryStream, Encoding.UTF8))
				{
					//writer.Formatting = Formatting.Indented;
					XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
					xmlSerializerNamespaces.Add("xsd", "http://services.xm.org/xsd");

					XmlSerializer serializer = new XmlSerializer(typeof(T));
					serializer.Serialize(writer, objectInstance, xmlSerializerNamespaces);
					memoryStream.Seek(0, SeekOrigin.Begin);

					using (StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8))
					{
						string xmlString = reader.ReadToEnd();
						string[] lines = xmlString.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

						StringBuilder xmlStringBuilder = new StringBuilder();

						for (int i = 0; i < lines.Length; i++)
						{
							if (lines[i].Contains(":nil=\"true\""))
								continue;

							xmlStringBuilder.AppendLine(lines[i]);
						}

						string type = typeof(T).Name;
						char[] typeArray = type.ToCharArray();
						typeArray[0] = char.ToLower(typeArray[0]);

						xmlStringBuilder.Replace(type, new string(typeArray));

						return xmlStringBuilder.ToString();
					}
				}
			}
		}
		catch
		{
			return string.Empty;
		}
	}

	internal static string SerializeObject<T>(T objectInstance)
	{
		return WrapInSoapEnvelope(Serialize<T>(objectInstance), false);
	}

	internal static string SerializeSoapException(SoapException soapError)
	{
		StringBuilder serializedSoapError = new StringBuilder();
		serializedSoapError.Append("<faultcode>");
		serializedSoapError.Append(soapError.Code.ToString());
		serializedSoapError.Replace("http://schemas.xmlsoap.org/soap/envelope/", "soapenv");
		serializedSoapError.AppendLine("</faultcode>");
		serializedSoapError.Append("<faultstring>");
		serializedSoapError.Append(soapError.Message);
		serializedSoapError.AppendLine("</faultstring>");
		serializedSoapError.AppendLine(SoapUtils.Serialize<XmlNode>(soapError.Detail));
		string serializedSoapErrorString = WrapInSoapEnvelope(serializedSoapError.ToString(), true);
		return serializedSoapErrorString;
	}

	private static string WrapInSoapEnvelope(string input, bool isError)
	{
		if (isError == true)
			input = string.Format(_faultEnvelope, input);

		input = string.Format(_soapEnvelope, input);

		return input;
	}
}
