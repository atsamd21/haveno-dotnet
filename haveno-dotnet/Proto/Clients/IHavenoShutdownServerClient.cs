using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.ShutdownServer")]
internal interface IHavenoShutdownServerClient
{
    [OperationContract(Name = "Stop")]
    Task<StopReply> StopAsync(StopRequest stopRequest, CancellationToken cancellationToken = default);

}
