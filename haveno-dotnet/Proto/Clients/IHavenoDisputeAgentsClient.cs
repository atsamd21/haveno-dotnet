using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.DisputeAgents")]
internal interface IHavenoDisputeAgentsClient
{
    [OperationContract(Name = "RegisterDisputeAgent")]
    Task RegisterDisputeAgentAsync(RegisterDisputeAgentRequest registerDisputeAgentRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "UnregisterDisputeAgent")]
    Task UnregisterDisputeAgentAsync(UnregisterDisputeAgentRequest unregisterDisputeAgentRequest, CancellationToken cancellationToken = default);
}
