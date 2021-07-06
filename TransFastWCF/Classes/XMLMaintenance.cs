using System;
using System.Web.Services.Protocols;
using System.Xml;

public class XMLMaintenance
{
	public XMLMaintenance()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	public static SoapException BuildSoapException(

	  string errorCode,
	  string errorMessage,
	  string errorSource,
	  XmlQualifiedName faultCodeLocation)
	{

		string webServiceNameSpace = "http://PJLIPushRemittance.org/";
		string soapActor = String.Format("{0}/{1}", webServiceNameSpace, errorSource);

		XmlDocument xmlDocument = new XmlDocument();

		XmlNode soapErrorDetailNode = xmlDocument.CreateNode(
			XmlNodeType.Element,
			SoapException.DetailElementName.Name,
			SoapException.DetailElementName.Namespace);

		XmlNode errorNode = xmlDocument.CreateNode(
			XmlNodeType.Element,
			"Error",
			webServiceNameSpace);

		XmlNode errorCodeNode = xmlDocument.CreateNode(
			XmlNodeType.Element,
			"ErrorCode",
			webServiceNameSpace);

		errorCodeNode.InnerText = errorCode;

		XmlNode errorMessageNode = xmlDocument.CreateNode(
			XmlNodeType.Element,
			"ErrorMessage",
			webServiceNameSpace);

		errorMessageNode.InnerText = errorMessage;

		XmlNode errorSourceNode = xmlDocument.CreateNode(
			XmlNodeType.Element,
			"ErrorSource",
			webServiceNameSpace);

		errorSourceNode.InnerText = errorSource;

		errorNode.AppendChild(errorCodeNode);
		errorNode.AppendChild(errorMessageNode);
		errorNode.AppendChild(errorSourceNode);

		soapErrorDetailNode.AppendChild(errorNode);

		SoapException soapError = new SoapException(
			errorMessage,
			faultCodeLocation,
			soapActor,
			soapErrorDetailNode);
		soapError.Source = errorSource;
		return soapError;
	}
}