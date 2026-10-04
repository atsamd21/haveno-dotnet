using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.Disputes")]
internal interface IHavenoDisputesClient
{
    [OperationContract(Name = "GetDispute")]
    Task<GetDisputeReply> GetDisputeAsync(GetDisputeRequest getDisputeRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetDisputes")]
    Task<GetDisputesReply> GetDisputesAsync(GetDisputesRequest getDisputesRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "OpenDispute")]
    Task<OpenDisputeReply> OpenDisputeAsync(OpenDisputeRequest openDisputeRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "ResolveDispute")]
    Task<ResolveDisputeReply> ResolveDisputeAsync(ResolveDisputeRequest resolveDisputeRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "SendDisputeChatMessage")]
    Task<SendDisputeChatMessageReply> SendDisputeChatMessageAsync(SendDisputeChatMessageRequest sendDisputeChatMessageRequest, CancellationToken cancellationToken = default);
}
