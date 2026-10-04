using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.GetTradeStatistics")]
internal interface IHavenoGetTradeStatisticsClient
{
    [OperationContract(Name = "GetTradeStatistics")]
    Task<GetTradeStatisticsReply> GetTradeStatisticsAsync(GetTradeStatisticsRequest getTradeStatisticsRequest, CancellationToken cancellationToken = default);
}
