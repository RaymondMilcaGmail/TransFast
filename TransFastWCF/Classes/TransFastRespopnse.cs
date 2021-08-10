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

    public class SenderDocument
    {
        public int Type { get; set; }
        public string Number { get; set; }
        public DateTime EmissionDate { get; set; }
        public string Emissor { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class ReceiverDocument
    {
        public int Type { get; set; }
        public string Number { get; set; }
        public DateTime EmissionDate { get; set; }
        public string Emissor { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class InvoiceAditionalData
    {
        public double ExchangeRate { get; set; }
        public string AccountCurrency { get; set; }
        public double AmmountDue { get; set; }
        public double ComissionDue { get; set; }
        public DateTime AvaliableDate { get; set; }
    }

    public class InvoiceData
    {
        public string SenderName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderCountry { get; set; }
        public string SenderCountryOfBirth { get; set; }
        public DateTime SenderdateOfBirth { get; set; }
        public int SenderSex { get; set; }
        public string SenderCity { get; set; }
        public string SenderProvince { get; set; }
        public string SenderPhone { get; set; }
        public SenderDocument SenderDocument { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverAdressLine1 { get; set; }
        public string ReceiverAdressLine2 { get; set; }
        public string ReceiverPhone1 { get; set; }
        public string ReceiverPhone2 { get; set; }
        public ReceiverDocument ReceiverDocument { get; set; }
        public DateTime ReceiverDOB { get; set; }
        public object BankAccount { get; set; }
        public int PaymentMethod { get; set; }
        public int InvoiceConsecutive { get; set; }
        public string InvoicePin { get; set; }
        public int InvoiceInternalID { get; set; }
        public string InvoiceMessage { get; set; }
        public double InvoiceAmmountToReceive { get; set; }
        public string InvoiceCurrency { get; set; }
        public string InvoiceExchangeRate { get; set; }
        public bool ReadyForPay { get; set; }
        public int InvoiceStatus { get; set; }
        public InvoiceAditionalData InvoiceAditionalData { get; set; }
    }

    public class PartnerLookupResultData
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
        public InvoiceData InvoiceData { get; set; }
    }

    public class UpdateTransactionResponse
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
        public string PaymentToken { get; set; }
    }

    public class ConfirmTransactionResponse
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
        public string PaymentToken { get; set; }
    }
}
