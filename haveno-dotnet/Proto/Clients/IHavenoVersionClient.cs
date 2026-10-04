using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.GetVersion")]
internal interface IHavenoVersionClient
{
    [OperationContract(Name = "GetVersion")]
    ValueTask<GetVersionReply> GetVersionAsync(GetVersionRequest getVersionRequest, CancellationToken cancellationToken = default);
}
