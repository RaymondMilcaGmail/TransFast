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