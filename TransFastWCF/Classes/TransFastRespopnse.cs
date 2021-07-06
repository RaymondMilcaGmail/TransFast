using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransFastWCF.TransFastRespopnse
{
    public class TokenResponse
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
        public string ReturnToken { get; set; }
    }

    public class GetAvaliableFilesResponse
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
        public List<AvaliableFIle> AvaliableFIles { get; set; }
    }

    public class GetFileResponse
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
        public List<FileContent> FileContents { get; set; }
    }

    public class CommitFileResponse
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
    }


    public class UpdateTransactionResponse
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
    }
    public class AvaliableFIle
    {
        public int Ordinal { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public DateTime FileDate { get; set; }
    }

    public class FileContent
    {
        public string SenderName { get; set; }
        public string SenderSurname { get; set; }
        public string SenderDocumentType { get; set; }
        public string SenderDocumentNumber { get; set; }
        public DateTime? SenderDocumentExpiration { get; set; }
        public string SenderDocumnetIssued { get; set; }
        public DateTime? SenderDocumentIssuedDate { get; set; }
        public string SenderStreet { get; set; }
        public string SenderHouseNumber { get; set; }
        public string SenderFloorAndDoor { get; set; }
        public string SenderCity { get; set; }
        public string SenderPostalCode { get; set; }
        public string SenderProvince { get; set; }
        public string SenderCountry { get; set; }
        public string SenderTelephone1 { get; set; }
        public string SenderTelephone2 { get; set; }
        public DateTime? SenderBirthDate { get; set; }
        public string SenderOccupation { get; set; }
        public int SenderSalary { get; set; }
        public string SenderNationality { get; set; }
        public string SenderSex { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string ReceiverDocument { get; set; }
        public string ReceiverAdressLine1 { get; set; }
        public string ReceiverAdressLine2 { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverTelephone1 { get; set; }
        public string ReceiverTelephone2 { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccountType { get; set; }
        public string BankAccountNumber { get; set; }
        public string AgentCode { get; set; }
        public int InvoiceAgentReference { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoicePassWord { get; set; }
        public double InvoiceAmmountToPay { get; set; }
        public string InvoiceCurrency { get; set; }
        public string InvoicePointOfPayment { get; set; }
        public string InvoiceModeOfPayment { get; set; }
        public string InvoiceMessage { get; set; }
        public string InvoiceStatus { get; set; }
    }


}
