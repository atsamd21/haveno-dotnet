using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;
using Haveno.Api.Models;
using Haveno.Api.Models.Converters;
using Haveno.Api.Models.Requests;
using Haveno.Api.Singletons;

namespace Haveno.Api.Services;

public interface IOffersService
{
    Task<OfferInfo> PostOfferAsync(PostOfferRequest postOfferRequest, CancellationToken cancellationToken = default);
    Task<OfferInfo> GetMyOfferAsync(string offerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<OfferInfo>> GetMyOffersAsync(string currencyCode, OfferDirection direction, CancellationToken cancellationToken = default);
    Task CancelOfferAsync(string offerId, CancellationToken cancellationToken = default);
    Task<OfferInfo> GetOfferAsync(string offerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<OfferInfo>> GetOffersAsync(string currencyCode, OfferDirection direction, CancellationToken cancellationToken = default);
    Task<OfferInfo> EditOfferAsync(EditOfferRequest editOfferRequest, CancellationToken cancellationToken = default);
}

public sealed class OffersService : IOffersService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoOffersClient _havenoOffersClient;

    public OffersService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoOffersClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoOffersClient>();
    }

    public async Task<OfferInfo> EditOfferAsync(EditOfferRequest editOfferRequest, CancellationToken cancellationToken = default)
    {
        var response = await _havenoOffersClient.EditOfferAsync(new Proto.Models.Requests.EditOfferRequest
        {
            PaymentAccountId = editOfferRequest.PaymentAccountId,
            CurrencyCode = editOfferRequest.CurrencyCode,
            UseMarketBasedPrice = editOfferRequest.UseMarketBasedPrice,
            OfferId = editOfferRequest.OfferId,
            ExtraInfo = editOfferRequest.ExtraInfo,
            MarketPriceMarginPct = editOfferRequest.MarketPriceMarginPercent,

            // Revisit
            Price = editOfferRequest.Price == 0 ? string.Empty : editOfferRequest.Price.ToString(),
            TriggerPrice = editOfferRequest.TriggerPrice == 0 ? string.Empty : editOfferRequest.TriggerPrice.ToString()
        }, cancellationToken);

        return response.Offer.Convert();
    }

    public async Task CancelOfferAsync(string offerId, CancellationToken cancellationToken = default)
    {
        await _havenoOffersClient.CancelOfferAsync(
            new Proto.Models.Requests.CancelOfferRequest 
            { 
                Id =  offerId 
            },
            cancellationToken);
    }

    public async Task<OfferInfo> GetMyOfferAsync(string offerId, CancellationToken cancellationToken = default)
    {
        var response = await _havenoOffersClient.GetMyOfferAsync(
              new Proto.Models.Requests.GetMyOfferRequest
              {
                  Id = offerId
              },
              cancellationToken);

        return response.Offer.Convert();
    }

    public async Task<IEnumerable<OfferInfo>> GetMyOffersAsync(string currencyCode, OfferDirection direction, CancellationToken cancellationToken = default)
    {
        var response = await _havenoOffersClient.GetMyOffersAsync(
            new Proto.Models.Requests.GetMyOffersRequest
            {
                CurrencyCode = currencyCode,
                Direction = direction.ToHavenoString()
            },
            cancellationToken);

        return response.Offers.Select(x => x.Convert());
    }

    public async Task<OfferInfo> GetOfferAsync(string offerId, CancellationToken cancellationToken = default)
    {
        var response = await _havenoOffersClient.GetOfferAsync(
            new Proto.Models.Requests.GetOfferRequest
            {
                Id = offerId
            },
            cancellationToken);

        return response.Offer.Convert();
    }

    public async Task<IEnumerable<OfferInfo>> GetOffersAsync(string currencyCode, OfferDirection direction, CancellationToken cancellationToken = default)
    {
        var response = await _havenoOffersClient.GetOffersAsync(
            new Proto.Models.Requests.GetOffersRequest
            {
                CurrencyCode = currencyCode,
                Direction = direction.ToHavenoString()
            },
            cancellationToken);

        return response.Offers.Select(x => x.Convert());
    }

    public async Task<OfferInfo> PostOfferAsync(PostOfferRequest postOfferRequest, CancellationToken cancellationToken = default)
    {
        var response = await _havenoOffersClient.PostOfferAsync(
            new Proto.Models.Requests.PostOfferRequest
            {
                Amount = postOfferRequest.Amount,
                BuyerAsTakerWithoutDeposit = postOfferRequest.IsNoDepositOffer,
                MinAmount = postOfferRequest.MinAmount,
                PaymentAccountId = postOfferRequest.PaymentAccountId,
                ReserveExactAmount = postOfferRequest.ReserveExactAmount,
                CurrencyCode = postOfferRequest.CurrencyCode,
                Direction = postOfferRequest.Direction.ToHavenoString(),
                ExtraInfo = postOfferRequest.ExtraInfo,
                IsPrivateOffer = postOfferRequest.IsPrivateOffer,
                MarketPriceMarginPct = postOfferRequest.MarketPriceMarginPercent,
                Price = postOfferRequest.Price == 0 ? string.Empty : postOfferRequest.Price.ToString(),
                TriggerPrice = postOfferRequest.TriggerPrice == 0 ? string.Empty : postOfferRequest.TriggerPrice.ToString(),
                SecurityDepositPct = postOfferRequest.SecurityDepositPercent,
                SourceOfferId = postOfferRequest.SourceOfferId,
                UseMarketBasedPrice = postOfferRequest.UseMarketBasedPrice
            },
            cancellationToken);

        return response.Offer.Convert();
    }
}
