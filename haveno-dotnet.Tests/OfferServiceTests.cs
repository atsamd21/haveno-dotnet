using Haveno.Api.Models;
using Haveno.Api.Models.Requests;
using Haveno.Api.Services;
using Haveno.Tests.Helpers;
using Haveno.Tests.Wallet;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(7)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class OfferServiceTests
{
    private readonly IOffersService _offersService_user_1;
    private readonly IWalletService _walletService_user_1;
    private readonly IPaymentAccountService _paymentAccountService_user_1;

    private readonly IOffersService _offersService_user_2;
    private readonly IWalletService _walletService_user_2;
    private readonly IPaymentAccountService _paymentAccountService_user_2;

    private readonly MoneroWalletService _moneroWalletService;

    private static readonly HashSet<PaymentAccount> _paymentAccounts = [];

    public OfferServiceTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _offersService_user_1 = serviceProvider.GetRequiredKeyedService<IOffersService>("user_1");
        _walletService_user_1 = serviceProvider.GetRequiredKeyedService<IWalletService>("user_1");
        _paymentAccountService_user_1 = serviceProvider.GetRequiredKeyedService<IPaymentAccountService>("user_1");

        _offersService_user_2 = serviceProvider.GetRequiredKeyedService<IOffersService>("user_2");
        _walletService_user_2 = serviceProvider.GetRequiredKeyedService<IWalletService>("user_2");
        _paymentAccountService_user_2 = serviceProvider.GetRequiredKeyedService<IPaymentAccountService>("user_2");

        _moneroWalletService = serviceProvider.GetRequiredService<MoneroWalletService>();
    }

    private void ValidateMyOfferInfoMatchesPostOfferRequest(PostOfferRequest postOfferRequest, OfferInfo offerInfo)
    {
        Assert.Equal(postOfferRequest.Amount, offerInfo.Amount);
        Assert.Equal(postOfferRequest.MinAmount, offerInfo.MinAmount);
        Assert.Equal(postOfferRequest.SecurityDepositPercent, offerInfo.BuyerSecurityDepositPercent);
        Assert.Equal(postOfferRequest.Direction, offerInfo.Direction);
        Assert.Equal(postOfferRequest.PaymentAccountId, offerInfo.PaymentAccountId);
        Assert.Equal("XMR", offerInfo.BaseCurrencyCode);
        Assert.Equal(postOfferRequest.CurrencyCode, offerInfo.CounterCurrencyCode);
        Assert.Equal(postOfferRequest.UseMarketBasedPrice, offerInfo.UseMarketBasedPrice);
        Assert.False(string.IsNullOrEmpty(offerInfo.PubKeyRing));
        Assert.False(string.IsNullOrEmpty(offerInfo.VersionNr));
        Assert.False(string.IsNullOrEmpty(offerInfo.OwnerNodeAddress));
        Assert.False(string.IsNullOrEmpty(offerInfo.Id));
        Assert.False(string.IsNullOrEmpty(offerInfo.ArbitratorSigner));
        //Assert.False(string.IsNullOrEmpty(response.SplitOutputTxHash));
        Assert.True(string.IsNullOrEmpty(offerInfo.Challenge));
        Assert.False(offerInfo.IsPrivateOffer);
        Assert.True(offerInfo.IsActivated);
        Assert.True(offerInfo.IsMyOffer);
        Assert.NotEqual(DateTime.MinValue, offerInfo.Date);
    }

    private async Task PostAndValidateOffer(PostOfferRequest postOfferRequest)
    {
        var postOfferResponse = await _offersService_user_1.PostOfferAsync(postOfferRequest);

        ValidateMyOfferInfoMatchesPostOfferRequest(postOfferRequest, postOfferResponse);

        var getMyOfferResponse = await _offersService_user_1.GetMyOfferAsync(postOfferResponse.Id);

        ValidateMyOfferInfoMatchesPostOfferRequest(postOfferRequest, getMyOfferResponse);

        var getMyOffersResponse = await _offersService_user_1.GetMyOffersAsync(postOfferRequest.CurrencyCode, OfferDirection.ANY);
        var myOffer = getMyOffersResponse.FirstOrDefault(x => x.Id == postOfferResponse.Id);
        Assert.NotNull(myOffer);

        ValidateMyOfferInfoMatchesPostOfferRequest(postOfferRequest, myOffer);

        OfferInfo? offerInfoFromUser_2 = null;

        // Check offerinfo matches from another user
        Assert.True(await TestHelper.PollWithTimeoutAsync<IEnumerable<OfferInfo>>(
            _offersService_user_2.GetOffersAsync, 
            offerInfos => 
            {
                offerInfoFromUser_2 = offerInfos.FirstOrDefault(x => x.Id == postOfferResponse.Id);
                return offerInfoFromUser_2 is not null;
            }, 
            arguments: [postOfferRequest.CurrencyCode, OfferDirection.ANY]));

        Assert.Equal(postOfferRequest.Amount, offerInfoFromUser_2!.Amount);
        Assert.Equal(postOfferRequest.MinAmount, offerInfoFromUser_2.MinAmount);
        Assert.Equal(postOfferRequest.SecurityDepositPercent, offerInfoFromUser_2.BuyerSecurityDepositPercent);
        Assert.Equal(postOfferRequest.Direction, offerInfoFromUser_2.Direction);
        Assert.Equal(postOfferRequest.PaymentAccountId, offerInfoFromUser_2.PaymentAccountId);
        Assert.Equal("XMR", offerInfoFromUser_2.BaseCurrencyCode);
        Assert.Equal(postOfferRequest.CurrencyCode, offerInfoFromUser_2.CounterCurrencyCode);
        Assert.False(string.IsNullOrEmpty(offerInfoFromUser_2.PubKeyRing));
        Assert.False(string.IsNullOrEmpty(offerInfoFromUser_2.VersionNr));
        Assert.False(string.IsNullOrEmpty(offerInfoFromUser_2.OwnerNodeAddress));
        Assert.False(string.IsNullOrEmpty(offerInfoFromUser_2.Id));
        Assert.False(string.IsNullOrEmpty(offerInfoFromUser_2.ArbitratorSigner));
        //Assert.False(string.IsNullOrEmpty(response.SplitOutputTxHash));
        Assert.True(string.IsNullOrEmpty(offerInfoFromUser_2.Challenge));
        Assert.False(offerInfoFromUser_2.IsPrivateOffer);
        Assert.True(offerInfoFromUser_2.IsActivated);
        Assert.False(offerInfoFromUser_2.IsMyOffer);
        Assert.Equal(postOfferRequest.UseMarketBasedPrice, offerInfoFromUser_2.UseMarketBasedPrice);
        Assert.NotEqual(DateTime.MinValue, offerInfoFromUser_2.Date);
    }

    [Fact, TestPriority(10)]
    public async Task Create_Market_Based_Price_Buy_Offer()
    {
        var paymentAccountForm = await _paymentAccountService_user_1.GetPaymentAccountFormAsync(PaymentMethodId.ZELLE);

        var ACCOUNT_NAME = "atsamd21's zelle account for offer testing";
        var EMAIL_OR_MOBILE_NR = "07123456789";
        var HOLDER_NAME = "atsamd21";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR).Value = EMAIL_OR_MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;

        var paymentAccount = await _paymentAccountService_user_1.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        await WalletHelper.FundHavenoWallet(_walletService_user_1, _moneroWalletService);
        await WalletHelper.FundHavenoWallet(_walletService_user_2, _moneroWalletService);

        var request = new PostOfferRequest
        {
            Amount = 500_000_000_000,
            MinAmount = 400_000_000_000,
            ReserveExactAmount = false,
            IsNoDepositOffer = false,
            IsPrivateOffer = false,
            ExtraInfo = "Extra info",
            CurrencyCode = "USD",
            SecurityDepositPercent = 0.15,
            Direction = OfferDirection.BUY,
            PaymentAccountId = paymentAccount.Id,
            UseMarketBasedPrice = true,
        };

        await PostAndValidateOffer(request);
    }

    [Fact, TestPriority(20)]
    public async Task Create_Market_Percent_Buy_Offer()
    {
        var paymentAccounts = await _paymentAccountService_user_1.GetPaymentAccountsAsync();
        var paymentAccount = paymentAccounts.First(x => x.PaymentMethod.Id == PaymentMethodId.ZELLE);

        var request = new PostOfferRequest
        {
            Amount = 500_000_000_000,
            MinAmount = 400_000_000_000,
            ReserveExactAmount = false,
            IsNoDepositOffer = false,
            IsPrivateOffer = false,
            ExtraInfo = "Extra info",
            CurrencyCode = "USD",
            SecurityDepositPercent = 0.15,
            Direction = OfferDirection.BUY,
            PaymentAccountId = paymentAccount.Id,
            MarketPriceMarginPercent = 0.10,
            UseMarketBasedPrice = true
        };

        await PostAndValidateOffer(request);
    }

    [Fact, TestPriority(30)]
    public async Task Create_Fixed_Price_Buy_Offer()
    {
        var paymentAccounts = await _paymentAccountService_user_1.GetPaymentAccountsAsync();
        var paymentAccount = paymentAccounts.First(x => x.PaymentMethod.Id == PaymentMethodId.ZELLE);

        var request = new PostOfferRequest
        {
            Amount = 500_000_000_000,
            MinAmount = 400_000_000_000,
            ReserveExactAmount = false,
            IsNoDepositOffer = false,
            IsPrivateOffer = false,
            ExtraInfo = "Extra info",
            CurrencyCode = "USD",
            SecurityDepositPercent = 0.15,
            Direction = OfferDirection.BUY,
            PaymentAccountId = paymentAccount.Id,
            Price = 400m
        };

        await PostAndValidateOffer(request);
    }
}
