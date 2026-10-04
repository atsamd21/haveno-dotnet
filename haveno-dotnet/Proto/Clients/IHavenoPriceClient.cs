using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.Price")]
internal interface IHavenoPriceClient
{
    [OperationContract(Name = "GetMarketPrice")]
    Task<MarketPriceReply> GetMarketPriceAsync(MarketPriceRequest marketPriceRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetMarketPrices")]
    Task<MarketPricesReply> GetMarketPricesAsync(MarketPricesRequest marketPricesRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetMarketDepth")]
    Task<MarketDepthReply> GetMarketDepthAsync(MarketDepthRequest marketDepthRequest, CancellationToken cancellationToken = default);
}
