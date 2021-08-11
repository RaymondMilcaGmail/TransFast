using System;
using System.ComponentModel;
using System.Linq;

public enum SoapFaultLocation
{
	ServerFault,
	ClientFault
}

public enum LookupTransactionResultCode
{
	UnrecognizedResponse,
	Successful,
	Unsuccessful,
	PartnerError,
	ServerError,
}

public enum DataTransactionResultCode
{
	UnrecognizedResponse,
	Successful,
	Unsuccessful,
	PartnerError,
	ServerError,
}

public enum PayoutTransactionResultCode
{
	UnrecognizedResponse,
	Successful,
	Unsuccessful,
	PartnerError,
	ServerError,
}

public enum UnlockTransactionResultCode
{
	UnrecognizedResponse,
	Successful,
	Unsuccessful,
	PartnerError,
	ServerError,
}

public enum TransactionStatus
{
    UnrecognizedStatus,
    ForPayout,          //UnPaid
    Blocked,            //ComplianceBlock
    PaidOut,            //Paid
    Cancelled,          //Cancelled
    ProcessedForPayout  //Processed, ready for payout
}

public enum PayoutMethod
{
    Token,
    Search,
    Begin,
    Create,
    Cancel,
    Confirm
}


public enum InvoiceStatusCode
{
    [Description("Invalid Invoice Status [0]")]
    Invalid = 0,
    [Description("Order is deleted not proceced")]
    DELETED = 1,
    [Description("The order is pending to validate")]
    UNVALIDATED = 2,
    [Description("The order is waiting for send")]
    OUTSTANDING_SEND = 3,
    [Description("In the process of transmission")]
    TRANSMITTION_PROCESS = 4,
    [Description("The order is locked in transmission")]
    ON_HOLD_AT_ADMINISTRATION = 5,
    [Description("The order is ready to be paid")]
    SEND = 7,
    [Description("The order has some type of incident(ready forpay)")]
    WITH_INCIDENTS = 8,
    [Description("Order is cancelled")]
    CANCELLED = 9,
    [Description("The order is an annulment")]
    CANCELLATION_BILLING = 10,
    [Description("The order is paid to the beneficiary")]
    PAID = 11,
    [Description("The order blocked by legal compliance")]
    LOCKED_IN_ADMINISTRATION = 14,
    [Description("The order has a request for cancellation")]
    CANCELLATION_REQUEST = 18,
}
public static class EnumHelper
{
    public static string GetEnumDescription(Enum value)
    {
        System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes != null && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}