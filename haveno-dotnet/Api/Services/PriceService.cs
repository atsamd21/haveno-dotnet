using Haveno.Api.Models;
using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IPriceService
{
    Task<decimal> GetMarketPriceAsync(string currencyCode, CancellationToken cancellationToken = default);
    Task<IEnumerable<MarketPriceInfo>> GetMarketPricesAsync(CancellationToken cancellationToken = default);
    Task<MarketDepthInfo> GetMarketDepthAsync(string currencyCode, CancellationToken cancellationToken = default);
}

public sealed class PriceService : IPriceService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoPriceClient _havenoPriceClient;

    public PriceService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoPriceClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoPriceClient>();
    }

    public async Task<MarketDepthInfo> GetMarketDepthAsync(string currencyCode, CancellationToken cancellationToken = default)
    {
        var response = await _havenoPriceClient.GetMarketDepthAsync(new Proto.Models.Requests.MarketDepthRequest
        {
            CurrencyCode = currencyCode
        },
        cancellationToken);

        return new MarketDepthInfo
        {
            BuyDepth = response.MarketDepth.BuyDepth,
            BuyPrices = response.MarketDepth.BuyPrices,
            CurrencyCode = response.MarketDepth.CurrencyCode,
            SellDepth = response.MarketDepth.SellDepth,
            SellPrices = response.MarketDepth.SellPrices
        };
    }

    public async Task<decimal> GetMarketPriceAsync(string currencyCode, CancellationToken cancellationToken = default)
    {
        var response = await _havenoPriceClient.GetMarketPriceAsync(new Proto.Models.Requests.MarketPriceRequest
        {
            CurrencyCode = currencyCode
        },
        cancellationToken);

        return (decimal)response.Price;
    }

    public async Task<IEnumerable<MarketPriceInfo>> GetMarketPricesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoPriceClient.GetMarketPricesAsync(
            new Proto.Models.Requests.MarketPricesRequest(), 
            cancellationToken);

        return response.MarketPrice.Select(x => new MarketPriceInfo
        {
            CurrencyCode = x.CurrencyCode,
            Price = x.Price,
        });
    }
}
