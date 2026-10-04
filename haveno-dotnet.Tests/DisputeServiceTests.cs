using Haveno.Api.Helpers;
using Haveno.Api.Models;
using Haveno.Api.Models.Enums;
using Haveno.Api.Models.Requests;
using Haveno.Api.Services;
using Haveno.Tests.Helpers;
using Haveno.Tests.Wallet;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(9)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class DisputeServiceTests
{
    private readonly IOffersService _offersService_user_1;
    private readonly IWalletService _walletService_user_1;
    private readonly ITradeService _tradeService_user_1;
    private readonly IPaymentAccountService _paymentAccountService_user_1;
    private readonly IDisputeService _disputeService_user_1;

    private readonly IOffersService _offersService_user_2;
    private readonly IWalletService _walletService_user_2;
    private readonly ITradeService _tradeService_user_2;
    private readonly IPaymentAccountService _paymentAccountService_user_2;
    private readonly IDisputeService _disputeService_user_2;

    private readonly IDisputeService _disputeService_arbitrator;

    private readonly MoneroWalletService _moneroWalletService;

    private static readonly HashSet<PaymentAccount> _paymentAccounts = [];

    public DisputeServiceTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _offersService_user_1 = serviceProvider.GetRequiredKeyedService<IOffersService>("user_1");
        _walletService_user_1 = serviceProvider.GetRequiredKeyedService<IWalletService>("user_1");
        _tradeService_user_1 = serviceProvider.GetRequiredKeyedService<ITradeService>("user_1");
        _paymentAccountService_user_1 = serviceProvider.GetRequiredKeyedService<IPaymentAccountService>("user_1");
        _disputeService_user_1 = serviceProvider.GetRequiredKeyedService<IDisputeService>("user_1");

        _offersService_user_2 = serviceProvider.GetRequiredKeyedService<IOffersService>("user_2");
        _walletService_user_2 = serviceProvider.GetRequiredKeyedService<IWalletService>("user_2");
        _tradeService_user_2 = serviceProvider.GetRequiredKeyedService<ITradeService>("user_2");
        _paymentAccountService_user_2 = serviceProvider.GetRequiredKeyedService<IPaymentAccountService>("user_2");
        _disputeService_user_2 = serviceProvider.GetRequiredKeyedService<IDisputeService>("user_2");

        _disputeService_arbitrator = serviceProvider.GetRequiredKeyedService<IDisputeService>("arbitrator");

        _moneroWalletService = serviceProvider.GetRequiredService<MoneroWalletService>();
    }

    [Fact, TestPriority(10)]
    public async Task Open_Dispute()
    {
        var paymentAccountForm = await _paymentAccountService_user_1.GetPaymentAccountFormAsync(PaymentMethodId.CASH_APP);

        var ACCOUNT_NAME = "atsamd21's cash app";
        var EMAIL_OR_MOBILE_NR = "07123456789";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR_OR_CASHTAG).Value = EMAIL_OR_MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount_user_1 = await _paymentAccountService_user_1.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount_user_1);

        ACCOUNT_NAME = "atsamd51's cash app";
        EMAIL_OR_MOBILE_NR = "09111499243";
        TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR_OR_CASHTAG).Value = EMAIL_OR_MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount_user_2 = await _paymentAccountService_user_2.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount_user_2);

        await WalletHelper.FundHavenoWallet(_walletService_user_1, _moneroWalletService);
        await WalletHelper.FundHavenoWallet(_walletService_user_2, _moneroWalletService);

        var postOfferRequest = new PostOfferRequest
        {
            Amount = 650_000_000_000,
            MinAmount = 400_000_000_000,
            ReserveExactAmount = false,
            IsNoDepositOffer = false,
            IsPrivateOffer = false,
            ExtraInfo = "Extra info",
            CurrencyCode = "USD",
            SecurityDepositPercent = 0.15,
            Direction = OfferDirection.SELL,
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
            Amount = 650_000_000_000,
            PaymentAccountId = paymentAccount_user_2.Id,
            OfferId = getOfferResponse.Id
        });

        await _moneroWalletService.StartMiningAsync(1, false, true);

        try
        {
            Assert.True(await TestHelper.PollWithTimeoutAsync<TradeInfo>(
                _tradeService_user_1.GetTradeAsync,
                trade =>
                {
                    var tradeRoleAndStep = TradeHelper.GetTradeRoleAndStep(trade);
                    return tradeRoleAndStep.Step == 2;
                },
                arguments: takeOfferResponse.Trade.TradeId));

            var user_1_trade = await _tradeService_user_1.GetTradeAsync(takeOfferResponse.Trade.TradeId);

            await _disputeService_user_1.OpenDisputeAsync(user_1_trade.TradeId);

            await TestHelper.PollWithTimeoutAsync<IEnumerable<Dispute>>(
                _disputeService_arbitrator.GetDisputesAsync,
                disputes => disputes.FirstOrDefault(x => x.TradeId == takeOfferResponse.Trade.TradeId) is not null);

            await _disputeService_arbitrator.ResolveDisputeAsync(new ResolveDisputeRequest
            {
                Reason = Shared.Enums.ReasonType.BankProblems,
                TradeId = takeOfferResponse.Trade.TradeId,
                Winner = Shared.Enums.WinnerType.Seller,
                SummaryNotes = "Some notes"
            });

            Assert.True(await TestHelper.PollWithTimeoutAsync<TradeInfo>(
                _tradeService_user_2.GetTradeAsync,
                tradeInfo => tradeInfo.DisputeState == TradeDisputeState.DISPUTE_CLOSED,
                timeout: 60_000,
                arguments: takeOfferResponse.Trade.TradeId));

            Assert.True(await TestHelper.PollWithTimeoutAsync<TradeInfo>(
                _tradeService_user_1.GetTradeAsync,
                tradeInfo => tradeInfo.DisputeState == TradeDisputeState.DISPUTE_CLOSED,
                timeout: 60_000,
                arguments: takeOfferResponse.Trade.TradeId));
        }
        finally
        {
            await _moneroWalletService.StopMiningAsync();
        }
    }
}
