using System.ServiceModel;
using System.ServiceModel.Web;
using TransFastWCFService.Classes;

namespace TransFastWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
	public interface ITransFastWCF
    {
        [OperationContract]
        PullRemittanceResult RemittancePartnerLookup(PullRemittanceRequest pullTransactionRequest);

        [OperationContract]
        PullRemittanceResult RemittancePartnerPayout(PullRemittanceRequest pullTransactionRequest);

        [OperationContract]
        string GenerateToken(GenerateTokenParameters generateTokenParameters);

        [OperationContract]
        DataTransactionResult RequestToken(DataTransactionResult dataTransactionResult);

    }
}
