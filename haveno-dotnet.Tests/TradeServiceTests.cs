using Haveno.Api.Helpers;
using Haveno.Api.Models;
using Haveno.Api.Models.Requests;
using Haveno.Api.Services;
using Haveno.Tests.Helpers;
using Haveno.Tests.Wallet;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(8)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class TradeServiceTests
{
    private readonly IOffersService _offersService_user_1;
    private readonly IWalletService _walletService_user_1;
    private readonly ITradeService _tradeService_user_1;
    private readonly IPaymentAccountService _paymentAccountService_user_1;

    private readonly IOffersService _offersService_user_2;
    private readonly IWalletService _walletService_user_2;
    private readonly ITradeService _tradeService_user_2;
    private readonly IPaymentAccountService _paymentAccountService_user_2;

    private readonly MoneroWalletService _moneroWalletService;

    private static readonly HashSet<PaymentAccount> _paymentAccounts = [];

    public TradeServiceTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _offersService_user_1 = serviceProvider.GetRequiredKeyedService<IOffersService>("user_1");
        _walletService_user_1 = serviceProvider.GetRequiredKeyedService<IWalletService>("user_1");
        _tradeService_user_1 = serviceProvider.GetRequiredKeyedService<ITradeService>("user_1");
        _paymentAccountService_user_1 = serviceProvider.GetRequiredKeyedService<IPaymentAccountService>("user_1");

        _offersService_user_2 = serviceProvider.GetRequiredKeyedService<IOffersService>("user_2");
        _walletService_user_2 = serviceProvider.GetRequiredKeyedService<IWalletService>("user_2");
        _tradeService_user_2 = serviceProvider.GetRequiredKeyedService<ITradeService>("user_2");
        _paymentAccountService_user_2 = serviceProvider.GetRequiredKeyedService<IPaymentAccountService>("user_2");

        _moneroWalletService = serviceProvider.GetRequiredService<MoneroWalletService>();
    }

    [Fact, TestPriority(10)]
    public async Task Take_Offer_And_Complete_Trade()
    {
        var paymentAccountForm = await _paymentAccountService_user_1.GetPaymentAccountFormAsync(PaymentMethodId.ZELLE);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL_OR_MOBILE_NR = "07123456789";
        var HOLDER_NAME = "atsamd21";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR).Value = EMAIL_OR_MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;

        var paymentAccount_user_1 = await _paymentAccountService_user_1.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount_user_1);

        ACCOUNT_NAME = "atsamd51";
        EMAIL_OR_MOBILE_NR = "09111499243";
        HOLDER_NAME = "atsamd51";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR).Value = EMAIL_OR_MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;

        var paymentAccount_user_2 = await _paymentAccountService_user_2.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount_user_2);

        await WalletHelper.FundHavenoWallet(_walletService_user_1, _moneroWalletService);
        await WalletHelper.FundHavenoWallet(_walletService_user_2, _moneroWalletService);

        var postOfferRequest = new PostOfferRequest
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
            PaymentAccountId = paymentAccount_user_1.Id,
            UseMarketBasedPrice = true,
            MarketPriceMarginPercent = 0.15
        };

        var postOfferResponse = await _offersService_user_1.PostOfferAsync(postOfferRequest);

        var getMyOfferResponse = await _offersService_user_1.GetMyOfferAsync(postOfferResponse.Id);

        await Task.Delay(5_000);

        var getOfferResponse = await _offersService_user_2.GetOfferAsync(postOfferResponse.Id);

        var takeOfferResponse = await _tradeService_user_2.TakeOfferAsync(new TakeOfferRequest
        {
            Amount = 500_000_000_000,
            PaymentAccountId = paymentAccount_user_2.Id,
            OfferId = getOfferResponse.Id
        });

        await _moneroWalletService.StartMiningAsync(1, false, true);

        try
        {
            Assert.True(await TestHelper.PollWithTimeoutAsync<TradeInfo>(
                _tradeService_user_1.GetTradeAsync, (user_1_trade) =>
                {
                    var tradeRoleAndStep = TradeHelper.GetTradeRoleAndStep(user_1_trade);
                    return tradeRoleAndStep.Step == 2;
                }, arguments: takeOfferResponse.Trade.TradeId));

            await _tradeService_user_1.ConfirmPaymentSentAsync(takeOfferResponse.Trade.TradeId);

            Assert.True(await TestHelper.PollWithTimeoutAsync<TradeInfo>(
                _tradeService_user_2.GetTradeAsync, (user_2_trade) =>
                {
                    var tradeRoleAndStep = TradeHelper.GetTradeRoleAndStep(user_2_trade);
                    return tradeRoleAndStep.Step == 3;
                }, arguments: takeOfferResponse.Trade.TradeId));

            await _tradeService_user_2.ConfirmPaymentReceivedAsync(takeOfferResponse.Trade.TradeId);

            await Task.Delay(10_000);

            Assert.True(await TestHelper.PollWithTimeoutAsync<TradeInfo>(
                _tradeService_user_1.GetTradeAsync, (user_1_trade) =>
                {
                    var tradeRoleAndStep = TradeHelper.GetTradeRoleAndStep(user_1_trade);
                    return tradeRoleAndStep.Step == 4;
                }, arguments: takeOfferResponse.Trade.TradeId));

            await _tradeService_user_1.CompleteTradeAsync(takeOfferResponse.Trade.TradeId);

            var user_1_trade = await _tradeService_user_1.GetTradeAsync(takeOfferResponse.Trade.TradeId);
            Assert.True(user_1_trade.IsCompleted);

            Assert.True(await TestHelper.PollWithTimeoutAsync<TradeInfo>(
                _tradeService_user_2.GetTradeAsync, (user_2_trade) =>
                {
                    var tradeRoleAndStep = TradeHelper.GetTradeRoleAndStep(user_2_trade);
                    return tradeRoleAndStep.Step == 4;
                }, arguments: takeOfferResponse.Trade.TradeId));

            await _tradeService_user_2.CompleteTradeAsync(takeOfferResponse.Trade.TradeId);

            var user_2_trade = await _tradeService_user_2.GetTradeAsync(takeOfferResponse.Trade.TradeId);
            Assert.True(user_2_trade.IsCompleted);
        }
        finally
        {
            await _moneroWalletService.StopMiningAsync();
        }
    }
}
