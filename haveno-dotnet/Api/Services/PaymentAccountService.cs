using Grpc.Core;
using Haveno.Api.Models;
using Haveno.Api.Models.Converters;
using Haveno.Api.Models.Requests;
using Haveno.Api.Singletons;
using Haveno.Extensions;
using Haveno.Proto.Clients;
using Microsoft.Extensions.Caching.Memory;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IPaymentAccountService
{
    Task<PaymentAccount> CreatePaymentAccountAsync(CreatePaymentAccountRequest createPaymentAccountRequest, CancellationToken cancellationToken = default);
    Task<PaymentAccountForm> GetPaymentAccountFormAsync(PaymentMethodId paymentMethodId, CancellationToken cancellationToken = default);
    Task<IEnumerable<PaymentAccount>> GetPaymentAccountsAsync(CancellationToken cancellationToken = default);
    Task DeletePaymentAccountAsync(string paymentAccountId, CancellationToken cancellationToken = default);
    Task<PaymentAccount> CreateCryptoCurrencyPaymentAccountAsync(CreateCryptoCurrencyPaymentAccountRequest createCryptoCurrencyPaymentAccountRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<PaymentMethod>> GetCryptoCurrencyPaymentMethodsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync(CancellationToken cancellationToken = default);
    Task<string> ValidateFormFieldAsync(ValidateFormFieldRequest validateFormFieldRequest, CancellationToken cancellationToken = default);
}

public sealed class PaymentAccountService : IPaymentAccountService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoPaymentAccountsClient _havenoPaymentAccountsClient;
    private readonly IMemoryCache _cache;

    public PaymentAccountService(GrpcChannelSingleton grpcChannelSingleton, IMemoryCache cache)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _cache = cache;
        _havenoPaymentAccountsClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoPaymentAccountsClient>();
    }

    public async Task<PaymentAccount> CreateCryptoCurrencyPaymentAccountAsync(CreateCryptoCurrencyPaymentAccountRequest createCryptoCurrencyPaymentAccountRequest, CancellationToken cancellationToken = default)
    {
        _cache.Remove("paymentAccounts");

        var response = await _havenoPaymentAccountsClient.CreateCryptoCurrencyPaymentAccountAsync(
            new Proto.Models.Requests.CreateCryptoCurrencyPaymentAccountRequest
            {
                AccountName = createCryptoCurrencyPaymentAccountRequest.AccountName,
                Address = createCryptoCurrencyPaymentAccountRequest.Address,
                CurrencyCode = createCryptoCurrencyPaymentAccountRequest.CurrencyCode,
                TradeInstant = createCryptoCurrencyPaymentAccountRequest.TradeInstant
            }, 
            cancellationToken);

        return response.PaymentAccount.Convert();
    }

    public async Task<PaymentAccount> CreatePaymentAccountAsync(CreatePaymentAccountRequest createPaymentAccountRequest, CancellationToken cancellationToken = default)
    {
        _cache.Remove("paymentAccounts");

        var response = await _havenoPaymentAccountsClient.CreatePaymentAccountAsync(
            new Proto.Models.Requests.CreatePaymentAccountRequest 
            {
                PaymentAccountForm = createPaymentAccountRequest.PaymentAccountForm.Convert()
            },
            cancellationToken);

        return response.PaymentAccount.Convert();
    }

    public async Task DeletePaymentAccountAsync(string paymentAccountId, CancellationToken cancellationToken = default)
    {
        _cache.Remove("paymentAccounts");

        await _havenoPaymentAccountsClient.DeletePaymentAccountAsync(
            new Proto.Models.Requests.DeletePaymentAccountRequest
            {
                PaymentAccountId = paymentAccountId
            }, 
            cancellationToken);
    }

    public async Task<IEnumerable<PaymentMethod>> GetCryptoCurrencyPaymentMethodsAsync(CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue<IEnumerable<PaymentMethod>>("cryptoCurrencyPaymentMethods", out var cachedCryptoPaymentMethods))
        {
            return cachedCryptoPaymentMethods!;
        }

        var response = await _havenoPaymentAccountsClient.GetCryptoCurrencyPaymentMethodsAsync(
            new Proto.Models.Requests.GetCryptoCurrencyPaymentMethodsRequest(), 
            cancellationToken);

        return _cache.Set("cryptoCurrencyPaymentMethods", response.PaymentMethods.Select(x => x.Convert()), DateTimeOffset.MaxValue);
    }

    public async Task<PaymentAccountForm> GetPaymentAccountFormAsync(PaymentMethodId paymentMethodId, CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue<PaymentAccountForm>($"paymentAccountForm:{paymentMethodId}", out var cachedPaymentAccountForm))
        {
            return cachedPaymentAccountForm!;
        }

        var response = await _havenoPaymentAccountsClient.GetPaymentAccountFormAsync(
            new Proto.Models.Requests.GetPaymentAccountFormRequest
            {
                PaymentMethodId = paymentMethodId.ToString()
            }, 
            cancellationToken);

        var paymentAccountForm = new PaymentAccountForm
        {
            Id = response.PaymentAccountForm.Id,
            Fields = response.PaymentAccountForm.Fields.Select(x => new PaymentAccountFormField
            {
                Id = x.Id,
                Label = x.Label,
                MaxLength = x.MaxLength,
                MinLength = x.MinLength,
                Value = x.Value,
                Type = x.Type,
                RequiredForCountries = x.RequiredForCountries,
                Component = x.Component,
                SupportedCurrencies = x.SupportedCurrencies.Select(y => new TradeCurrency
                {
                    Code = y.Code,
                    CryptoCurrency = y.CryptoCurrency is null ? null : new CryptoCurrency
                    {
                        IsAsset = y.CryptoCurrency.IsAsset
                    },
                    Name = y.Name,
                    TraditionalCurrency = y.TraditionalCurrency is null ? null : new TraditionalCurrency
                    {
                        
                    }
                }).ToList(),
                SupportedCountries = x.SupportedCountries.Select(y => y.Convert()).ToList(),
                SupportedSepaEuroCountries = x.SupportedSepaEuroCountries.Select(y => y.Convert()).ToList(),
                SupportedSepaNonEuroCountries = x.SupportedSepaNonEuroCountries.Select(y => y.Convert()).ToList(),
                RequiredIfAnyFieldHasValue = x.RequiredIfAnyFieldHasValue,
                Required = x.Required,
                SupportedValues = x.SupportedValues
            }).ToList()
        };

        return _cache.Set($"paymentAccountForm:{paymentMethodId}", paymentAccountForm, DateTimeOffset.MaxValue);
    }

    public async Task<IEnumerable<PaymentAccount>> GetPaymentAccountsAsync(CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue<IEnumerable<PaymentAccount>>("paymentAccounts", out var cachedPaymentAccounts))
        {
            return cachedPaymentAccounts!;
        }

        var response = await _havenoPaymentAccountsClient.GetPaymentAccountsAsync(
            new Proto.Models.Requests.GetPaymentAccountsRequest(),
            cancellationToken);

        return _cache.Set("paymentAccounts", response.PaymentAccounts.Select(x => x.Convert()), DateTimeOffset.MaxValue);
    }

    public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync(CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue<IEnumerable<PaymentMethod>>("paymentMethods", out var cachedPaymentMethods))
        {
            return cachedPaymentMethods!;
        }

        var response = await _havenoPaymentAccountsClient.GetPaymentMethodsAsync(
            new Proto.Models.Requests.GetPaymentMethodsRequest(),
            cancellationToken);

        return _cache.Set("paymentMethods", response.PaymentMethods.Select(x => x.Convert()), DateTimeOffset.MaxValue);
    }

    public async Task<string> ValidateFormFieldAsync(ValidateFormFieldRequest validateFormFieldRequest, CancellationToken cancellationToken = default)
    {
        try
        {
            await _havenoPaymentAccountsClient.ValidateFormFieldAsync(new Proto.Models.Requests.ValidateFormFieldRequest
            {
                FieldId = validateFormFieldRequest.FieldId,
                Value = validateFormFieldRequest.Value,
                Form = validateFormFieldRequest.Form.Convert()
            }, 
            cancellationToken);

            return string.Empty;
        }
        catch (RpcException e) 
        {
            return e.GetErrorMessage();
        }
    }
}
