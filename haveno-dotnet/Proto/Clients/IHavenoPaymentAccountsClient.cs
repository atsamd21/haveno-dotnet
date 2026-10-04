using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.PaymentAccounts")]
internal interface IHavenoPaymentAccountsClient
{
    [OperationContract(Name = "CreatePaymentAccount")]
    Task<CreatePaymentAccountReply> CreatePaymentAccountAsync(CreatePaymentAccountRequest createPaymentAccountRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetPaymentAccounts")]
    Task<GetPaymentAccountsReply> GetPaymentAccountsAsync(GetPaymentAccountsRequest getPaymentAccountsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetPaymentMethods")]
    Task<GetPaymentMethodsReply> GetPaymentMethodsAsync(GetPaymentMethodsRequest getPaymentMethodsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetPaymentAccountForm")]
    Task<GetPaymentAccountFormReply> GetPaymentAccountFormAsync(GetPaymentAccountFormRequest getPaymentAccountFormRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetPaymentAccountFormAsJson")]
    Task<GetPaymentAccountFormAsJsonReply> GetPaymentAccountFormAsJsonAsync(GetPaymentAccountFormAsJsonRequest getPaymentAccountFormAsJsonRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CreateCryptoCurrencyPaymentAccount")]
    Task<CreateCryptoCurrencyPaymentAccountReply> CreateCryptoCurrencyPaymentAccountAsync(CreateCryptoCurrencyPaymentAccountRequest createCryptoCurrencyPaymentAccountRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "DeletePaymentAccount")]
    Task<DeletePaymentAccountReply> DeletePaymentAccountAsync(DeletePaymentAccountRequest deletePaymentAccountRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetCryptoCurrencyPaymentMethods")]
    Task<GetCryptoCurrencyPaymentMethodsReply> GetCryptoCurrencyPaymentMethodsAsync(GetCryptoCurrencyPaymentMethodsRequest getCryptoCurrencyPaymentMethodsRequest , CancellationToken cancellationToken = default);
    [OperationContract(Name = "ValidateFormField")]
    Task<ValidateFormFieldReply> ValidateFormFieldAsync(ValidateFormFieldRequest validateFormFieldRequest, CancellationToken cancellationToken = default);
}
