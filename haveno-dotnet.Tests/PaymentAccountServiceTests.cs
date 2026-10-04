using Haveno.Api.Models;
using Haveno.Api.Models.Requests;
using Haveno.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(5)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class PaymentAccountServiceTests
{
    private readonly IPaymentAccountService _paymentAccountService;

    private static readonly HashSet<PaymentAccount> _paymentAccounts = [];

    public PaymentAccountServiceTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _paymentAccountService = serviceProvider.GetRequiredKeyedService<IPaymentAccountService>("user_1");
    }

    [Fact, TestPriority(10)]
    public async Task CASH_AT_ATM()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.CASH_AT_ATM);

        var ACCOUNT_NAME = "atsamd21";
        var EXTRA_INFO = "Some extra information";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EXTRA_INFO).Value = EXTRA_INFO;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(EXTRA_INFO, paymentAccount.PaymentAccountPayload.CashAtAtmAccountPayload!.ExtraInfo);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
    }

    [Fact, TestPriority(20)]
    public async Task FASTER_PAYMENTS()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.FASTER_PAYMENTS);

        var ACCOUNT_NAME = "atsamd21";
        var HOLDER_NAME = "atsamd21";
        // Without lines
        var SORT_CODE = "123456";
        var ACCOUNT_NR = "12345678";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.SORT_CODE).Value = SORT_CODE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NR).Value = ACCOUNT_NR;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.FasterPaymentsAccountPayload!.HolderName);
        Assert.Equal(SORT_CODE, paymentAccount.PaymentAccountPayload.FasterPaymentsAccountPayload!.SortCode);
        Assert.Equal(ACCOUNT_NR, paymentAccount.PaymentAccountPayload.FasterPaymentsAccountPayload!.AccountNr);
    }

    [Fact, TestPriority(30)]
    public async Task F2F()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.F2F);

        var ACCOUNT_NAME = "atsamd21";
        var COUNTRY = "US";
        var TRADE_CURRENCIES = "USD";
        var CONTACT = "atsamd21@test.com";
        var CITY = "New York";
        var EXTRA_INFO = "Some extra information";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.COUNTRY).Value = COUNTRY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.CONTACT).Value = CONTACT;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.CITY).Value = CITY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EXTRA_INFO).Value = EXTRA_INFO;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(COUNTRY, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.CountryCode);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(CONTACT, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.F2FAccountPayload!.Contact);
        Assert.Equal(CITY, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.F2FAccountPayload!.City);
        Assert.Equal(EXTRA_INFO, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.F2FAccountPayload!.ExtraInfo);
    }

    [Fact, TestPriority(40)]
    public async Task MONEY_GRAM()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.MONEY_GRAM);
        var ACCOUNT_NAME = "atsamd21";
        var COUNTRY = "US";
        var STATE = "New York";
        var HOLDER_NAME = "atsamd21";
        var EMAIL = "atsamd21@test.com";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.COUNTRY).Value = COUNTRY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.STATE).Value = STATE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL).Value = EMAIL;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(COUNTRY, paymentAccount.PaymentAccountPayload.MoneyGramAccountPayload!.CountryCode);
        Assert.Equal(STATE, paymentAccount.PaymentAccountPayload.MoneyGramAccountPayload!.State);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.MoneyGramAccountPayload!.HolderName);
        Assert.Equal(EMAIL, paymentAccount.PaymentAccountPayload.MoneyGramAccountPayload!.Email);
    }

    [Fact, TestPriority(50)]
    public async Task PAXUM()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.PAXUM);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL = "atsamd21@test.com";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL).Value = EMAIL;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(EMAIL, paymentAccount.PaymentAccountPayload.PaxumAccountPayload!.Email);
    }

    [Fact, TestPriority(60)]
    public async Task PAY_BY_MAIL()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.PAY_BY_MAIL);
        var ACCOUNT_NAME = "atsamd21";
        var POSTAL_ADDRESS = "456 Test Street\nSpringfield, IL 38081\nUnited States";
        var CONTACT = "atsamd21@test.com";
        var EXTRA_INFO = "Some extra info";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.POSTAL_ADDRESS).Value = POSTAL_ADDRESS;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.CONTACT).Value = CONTACT;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EXTRA_INFO).Value = EXTRA_INFO;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(POSTAL_ADDRESS, paymentAccount.PaymentAccountPayload.PayByMailAccountPayload!.PostalAddress);
        Assert.Equal(EXTRA_INFO, paymentAccount.PaymentAccountPayload.PayByMailAccountPayload!.ExtraInfo);
        Assert.Equal(CONTACT, paymentAccount.PaymentAccountPayload.PayByMailAccountPayload!.Contact);
    }

    [Fact, TestPriority(70)]
    public async Task REVOLUT()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.REVOLUT);

        var ACCOUNT_NAME = "atsamd21";
        var USERNAME = "atsamd21";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.USERNAME).Value = USERNAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(USERNAME, paymentAccount.PaymentAccountPayload.RevolutAccountPayload!.Username);
    }

    [Fact, TestPriority(80)]
    public async Task SEPA()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.SEPA);

        var ACCOUNT_NAME = "atsamd21";
        var COUNTRY = "DE";
        var ACCEPTED_COUNTRY_CODES = "DE";
        var HOLDER_NAME = "atsamd51";
        var IBAN = "DE89370400440532013000";
        var BIC = "COBADEFFXXX";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.COUNTRY).Value = COUNTRY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BIC).Value = BIC;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.IBAN).Value = IBAN;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCEPTED_COUNTRY_CODES).Value = ACCEPTED_COUNTRY_CODES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.SepaAccountPayload!.HolderName);
        Assert.Equal(BIC, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.SepaAccountPayload!.Bic);
        Assert.Equal(IBAN, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.SepaAccountPayload!.Iban);
        Assert.Equal(ACCEPTED_COUNTRY_CODES, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.AcceptedCountryCodes.First());
        Assert.Equal(COUNTRY, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.CountryCode);
    }

    [Fact, TestPriority(90)]
    public async Task SEPA_INSTANT()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.SEPA_INSTANT);

        var ACCOUNT_NAME = "atsamd21";
        var COUNTRY = "DE";
        var ACCEPTED_COUNTRY_CODES = "DE";
        var HOLDER_NAME = "atsamd51";
        var IBAN = "DE89370400440532013000";
        var BIC = "COBADEFFXXX";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.COUNTRY).Value = COUNTRY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BIC).Value = BIC;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.IBAN).Value = IBAN;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCEPTED_COUNTRY_CODES).Value = ACCEPTED_COUNTRY_CODES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.SepaInstantAccountPayload!.HolderName);
        Assert.Equal(BIC, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.SepaInstantAccountPayload!.Bic);
        Assert.Equal(IBAN, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.SepaInstantAccountPayload!.Iban);
        Assert.Equal(ACCEPTED_COUNTRY_CODES, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.AcceptedCountryCodes.First());
        Assert.Equal(COUNTRY, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.CountryCode);
    }

    [Fact, TestPriority(100)]
    public async Task STRIKE()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.STRIKE);

        var ACCOUNT_NAME = "atsamd21";
        var COUNTRY = "US";
        var HOLDER_NAME = "atsamd21";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.COUNTRY).Value = COUNTRY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.StrikeAccountPayload!.HolderName);
        Assert.Equal(COUNTRY, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.CountryCode);
    }

    [Fact, TestPriority(110)]
    public async Task SWIFT()
    {
        // Deep copy hack for now, cache returns a reference
        var paymentAccountForm = JsonSerializer.Deserialize<PaymentAccountForm>(
            JsonSerializer.Serialize(await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.SWIFT)))!;

        var ACCOUNT_NAME = "atsamd21's SWIFT account";
        var BANK_SWIFT_CODE = "DEUTDEFFXXX";
        var BANK_COUNTRY_CODE = "DE";
        var BANK_NAME = "Test bank";
        var BANK_BRANCH = "Test branch";
        var BANK_ADDRESS = "Test address 123";
        var BENEFICIARY_NAME = "atsamd21";
        var BENEFICIARY_ACCOUNT_NR = "DE12500105170678901234";
        var BENEFICIARY_ADDRESS = "Goethestraße 8";
        var BENEFICIARY_CITY = "Berlin";
        var BENEFICIARY_PHONE = "07123456789";
        var SPECIAL_INSTRUCTIONS = "Some extra instructions";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_SWIFT_CODE).Value = BANK_SWIFT_CODE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_COUNTRY_CODE).Value = BANK_COUNTRY_CODE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_NAME).Value = BANK_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_BRANCH).Value = BANK_BRANCH;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_ADDRESS).Value = BANK_ADDRESS;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_NAME).Value = BENEFICIARY_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_ACCOUNT_NR).Value = BENEFICIARY_ACCOUNT_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_ADDRESS).Value = BENEFICIARY_ADDRESS;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_CITY).Value = BENEFICIARY_CITY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_PHONE).Value = BENEFICIARY_PHONE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.SPECIAL_INSTRUCTIONS).Value = SPECIAL_INSTRUCTIONS;

        // Optional
        paymentAccountForm.Fields.RemoveAll(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_SWIFT_CODE);
        paymentAccountForm.Fields.RemoveAll(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_COUNTRY_CODE);
        paymentAccountForm.Fields.RemoveAll(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_NAME);
        paymentAccountForm.Fields.RemoveAll(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_BRANCH);
        paymentAccountForm.Fields.RemoveAll(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_ADDRESS);

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(BANK_SWIFT_CODE, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankSwiftCode);
        Assert.Equal(BANK_COUNTRY_CODE, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankCountryCode);
        Assert.Equal(BANK_NAME, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankName);
        Assert.Equal(BANK_BRANCH, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankBranch);
        Assert.Equal(BANK_ADDRESS, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankAddress);
        Assert.Equal(BENEFICIARY_NAME, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryName);
        Assert.Equal(BENEFICIARY_ACCOUNT_NR, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryAccountNr);
        Assert.Equal(BENEFICIARY_ADDRESS, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryAddress);
        Assert.Equal(BENEFICIARY_CITY, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryCity);
        Assert.Equal(BENEFICIARY_PHONE, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryPhone);
        Assert.Equal(SPECIAL_INSTRUCTIONS, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.SpecialInstructions);
    }

    [Fact, TestPriority(120)]
    public async Task SWIFT_WITH_INTERMEDIARY_BANK()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.SWIFT);

        var ACCOUNT_NAME = "atsamd21's SWIFT account 2";
        var BANK_SWIFT_CODE = "DEUTDEFFXXX";
        var BANK_COUNTRY_CODE = "DE";
        var BANK_NAME = "Test bank";
        var BANK_BRANCH = "Test branch";
        var BANK_ADDRESS = "Test address 123";
        var BENEFICIARY_NAME = "atsamd21";
        var BENEFICIARY_ACCOUNT_NR = "DE12500105170678901234";
        var BENEFICIARY_ADDRESS = "Goethestraße 8";
        var BENEFICIARY_CITY = "Berlin";
        var BENEFICIARY_PHONE = "07123456789";
        var SPECIAL_INSTRUCTIONS = "Some extra instructions";

        var INTERMEDIARY_SWIFT_CODE = "11111111111";
        var INTERMEDIARY_COUNTRY_CODE = "DE";
        var INTERMEDIARY_NAME = "Deutsche Bank AG";
        var INTERMEDIARY_BRANCH = "Frankfurt Main Branch";
        var INTERMEDIARY_ADDRESS = "Taunusanlage 12, 60325 Frankfurt am Main, Germany";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_SWIFT_CODE).Value = BANK_SWIFT_CODE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_COUNTRY_CODE).Value = BANK_COUNTRY_CODE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_NAME).Value = BANK_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_BRANCH).Value = BANK_BRANCH;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_ADDRESS).Value = BANK_ADDRESS;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_NAME).Value = BENEFICIARY_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_ACCOUNT_NR).Value = BENEFICIARY_ACCOUNT_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_ADDRESS).Value = BENEFICIARY_ADDRESS;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_CITY).Value = BENEFICIARY_CITY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BENEFICIARY_PHONE).Value = BENEFICIARY_PHONE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.SPECIAL_INSTRUCTIONS).Value = SPECIAL_INSTRUCTIONS;

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_SWIFT_CODE).Value = INTERMEDIARY_SWIFT_CODE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_COUNTRY_CODE).Value = INTERMEDIARY_COUNTRY_CODE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_NAME).Value = INTERMEDIARY_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_BRANCH).Value = INTERMEDIARY_BRANCH;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.INTERMEDIARY_ADDRESS).Value = INTERMEDIARY_ADDRESS;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(BANK_SWIFT_CODE, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankSwiftCode);
        Assert.Equal(BANK_COUNTRY_CODE, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankCountryCode);
        Assert.Equal(BANK_NAME, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankName);
        Assert.Equal(BANK_BRANCH, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankBranch);
        Assert.Equal(BANK_ADDRESS, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BankAddress);
        Assert.Equal(BENEFICIARY_NAME, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryName);
        Assert.Equal(BENEFICIARY_ACCOUNT_NR, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryAccountNr);
        Assert.Equal(BENEFICIARY_ADDRESS, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryAddress);
        Assert.Equal(BENEFICIARY_CITY, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryCity);
        Assert.Equal(BENEFICIARY_PHONE, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.BeneficiaryPhone);
        Assert.Equal(SPECIAL_INSTRUCTIONS, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.SpecialInstructions);

        Assert.Equal(INTERMEDIARY_SWIFT_CODE, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.IntermediarySwiftCode);
        Assert.Equal(INTERMEDIARY_COUNTRY_CODE, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.IntermediaryCountryCode);
        Assert.Equal(INTERMEDIARY_NAME, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.IntermediaryName);
        Assert.Equal(INTERMEDIARY_BRANCH, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.IntermediaryBranch);
        Assert.Equal(INTERMEDIARY_ADDRESS, paymentAccount.PaymentAccountPayload.SwiftAccountPayload!.IntermediaryAddress);
    }

    [Fact, TestPriority(130)]
    public async Task TRANSFERWISE()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.TRANSFERWISE);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL = "atsamd21@test.com";
        var TRADE_CURRENCIES = "AUD";
        var HOLDER_NAME = "atsamd21";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL).Value = EMAIL;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(EMAIL, paymentAccount.PaymentAccountPayload.TransferwiseAccountPayload!.Email);
    }

    [Fact, TestPriority(140)]
    public async Task UPHOLD()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.UPHOLD);

        var ACCOUNT_NAME = "atsamd21";
        var ACCOUNT_ID = "1234";
        var ACCOUNT_OWNER = "atsamd21";
        var TRADE_CURRENCIES = "EUR";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_OWNER).Value = ACCOUNT_OWNER;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_ID).Value = ACCOUNT_ID;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(ACCOUNT_ID, paymentAccount.PaymentAccountPayload.UpholdAccountPayload!.AccountId);
        Assert.Equal(ACCOUNT_OWNER, paymentAccount.PaymentAccountPayload.UpholdAccountPayload!.AccountOwner);
    }

    [Fact, TestPriority(150)]
    public async Task ZELLE()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.ZELLE);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL_OR_MOBILE_NR = "07123456789";
        var HOLDER_NAME = "atsamd21";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR).Value = EMAIL_OR_MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.ZelleAccountPayload!.HolderName);
        Assert.Equal(EMAIL_OR_MOBILE_NR, paymentAccount.PaymentAccountPayload.ZelleAccountPayload!.EmailOrMobileNr);
    }

    [Fact, TestPriority(160)]
    public async Task AUSTRALIA_PAYID()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.AUSTRALIA_PAYID);

        var ACCOUNT_NAME = "atsamd21";
        var PAYID = "07123456789";
        var BANK_ACCOUNT_NAME = "atsamd21";
        var EXTRA_INFO = "extra info";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.PAYID).Value = PAYID;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_ACCOUNT_NAME).Value = BANK_ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EXTRA_INFO).Value = EXTRA_INFO;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(EXTRA_INFO, paymentAccount.PaymentAccountPayload.AustraliaPayidPayload!.ExtraInfo);
        Assert.Equal(PAYID, paymentAccount.PaymentAccountPayload.AustraliaPayidPayload!.PayId);
        Assert.Equal(BANK_ACCOUNT_NAME, paymentAccount.PaymentAccountPayload.AustraliaPayidPayload!.BankAccountName);
    }

    [Fact, TestPriority(170)]
    public async Task CASH_APP()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.CASH_APP);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL_OR_MOBILE_NR_OR_CASHTAG = "atsamd21@test.com";
        var EXTRA_INFO = "extra info";
        var TRADE_CURRENCIES = "GBP";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR_OR_CASHTAG).Value = EMAIL_OR_MOBILE_NR_OR_CASHTAG;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EXTRA_INFO).Value = EXTRA_INFO;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(EXTRA_INFO, paymentAccount.PaymentAccountPayload.CashAppAccountPayload!.ExtraInfo);
        Assert.Equal(EMAIL_OR_MOBILE_NR_OR_CASHTAG, paymentAccount.PaymentAccountPayload.CashAppAccountPayload!.EmailOrMobileNrOrCashtag);
    }

    [Fact, TestPriority(180)]
    public async Task PAYPAL()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.PAYPAL);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL_OR_MOBILE_NR_OR_USERNAME = "atsamd21@test.com";
        var EXTRA_INFO = "extra info";
        var TRADE_CURRENCIES = "GBP";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR_OR_USERNAME).Value = EMAIL_OR_MOBILE_NR_OR_USERNAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EXTRA_INFO).Value = EXTRA_INFO;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(EXTRA_INFO, paymentAccount.PaymentAccountPayload.PayPalAccountPayload!.ExtraInfo);
        Assert.Equal(EMAIL_OR_MOBILE_NR_OR_USERNAME, paymentAccount.PaymentAccountPayload.PayPalAccountPayload!.EmailOrMobileNrOrUsername);
    }

    [Fact, TestPriority(190)]
    public async Task VENMO()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.VENMO);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL_OR_MOBILE_NR_OR_USERNAME = "atsamd21@test.com";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR_OR_USERNAME).Value = EMAIL_OR_MOBILE_NR_OR_USERNAME;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(EMAIL_OR_MOBILE_NR_OR_USERNAME, paymentAccount.PaymentAccountPayload.VenmoAccountPayload!.EmailOrMobileNrOrUsername);
    }

    [Fact, TestPriority(200)]
    public async Task PAYSAFE()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.PAYSAFE);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL = "atsamd21@test.com";
        var TRADE_CURRENCIES = "GBP";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL).Value = EMAIL;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(EMAIL, paymentAccount.PaymentAccountPayload.PaysafeAccountPayload!.Email);
    }

    [Fact, TestPriority(210)]
    public async Task WECHAT_PAY()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.WECHAT_PAY);

        var ACCOUNT_NAME = "atsamd21";
        var ACCOUNT_NR = "12345678";
        var TRADE_CURRENCIES = "GBP";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NR).Value = ACCOUNT_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(ACCOUNT_NR, paymentAccount.PaymentAccountPayload.WeChatPayAccountPayload!.AccountNr);
    }

    [Fact, TestPriority(220)]
    public async Task ALI_PAY()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.ALI_PAY);

        var ACCOUNT_NAME = "atsamd21";
        var ACCOUNT_NR = "12345678";
        var TRADE_CURRENCIES = "AED";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NR).Value = ACCOUNT_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(ACCOUNT_NR, paymentAccount.PaymentAccountPayload.AliPayAccountPayload!.AccountNr);
    }

    [Fact, TestPriority(230)]
    public async Task SWISH()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.SWISH);

        var ACCOUNT_NAME = "atsamd21";
        var HOLDER_NAME = "atsamd21";
        var MOBILE_NR = "07123456789";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.MOBILE_NR).Value = MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(MOBILE_NR, paymentAccount.PaymentAccountPayload.SwishAccountPayload!.MobileNr);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.SwishAccountPayload!.HolderName);
    }

    [Fact, TestPriority(240)]
    public async Task TRANSFERWISE_USD()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.TRANSFERWISE_USD);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL = "atsamd21@test.com";
        var HOLDER_ADDRESS = "123 test street";
        var HOLDER_NAME = "atsamd21";
        var COUNTRY = "US";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL).Value = EMAIL;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_ADDRESS).Value = HOLDER_ADDRESS;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.COUNTRY).Value = COUNTRY;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(COUNTRY, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.CountryCode);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.TransferwiseUsdAccountPayload!.HolderName);
        Assert.Equal(HOLDER_ADDRESS, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.TransferwiseUsdAccountPayload!.HolderAddress);
        Assert.Equal(EMAIL, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.TransferwiseUsdAccountPayload!.Email);
    }

    // Does not return supported countries - needs to be fixed
    [Fact, TestPriority(250)]
    public async Task AMAZON_GIFT_CARD()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.AMAZON_GIFT_CARD);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL_OR_MOBILE_NR = "atsamd21@test.com";
        var COUNTRY = "US";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR).Value = EMAIL_OR_MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.COUNTRY).Value = COUNTRY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(EMAIL_OR_MOBILE_NR, paymentAccount.PaymentAccountPayload.AmazonGiftCardAccountPayload!.EmailOrMobileNr);
        Assert.Equal(COUNTRY, paymentAccount.PaymentAccountPayload.AmazonGiftCardAccountPayload!.CountryCode);
    }

    [Fact, TestPriority(260)]
    public async Task ACH_TRANSFER()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.ACH_TRANSFER);

        var ACCOUNT_NAME = "atsamd21";
        var HOLDER_ADDRESS = "123 test street";
        var HOLDER_NAME = "atsamd21";
        var BANK_NAME = "Test bank";
        var ACCOUNT_NR = "98765432";
        var BRANCH_ID = "BR045";
        var ACCOUNT_TYPE = "Checking";
        var COUNTRY = "US";
        var TRADE_CURRENCIES = "USD";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_ADDRESS).Value = HOLDER_ADDRESS;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BANK_NAME).Value = BANK_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.BRANCH_ID).Value = BRANCH_ID;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NR).Value = ACCOUNT_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_TYPE).Value = ACCOUNT_TYPE;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.COUNTRY).Value = COUNTRY;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(COUNTRY, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.CountryCode);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
        Assert.Equal(HOLDER_ADDRESS, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.BankAccountPayload!.AchTransferAccountPayload!.HolderAddress);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.BankAccountPayload!.HolderName);
        Assert.Equal(BANK_NAME, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.BankAccountPayload!.BankName);
        Assert.Equal(ACCOUNT_NR, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.BankAccountPayload!.AccountNr);
        Assert.Equal(BRANCH_ID, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.BankAccountPayload!.BranchId);
        Assert.Equal(ACCOUNT_TYPE, paymentAccount.PaymentAccountPayload.CountryBasedPaymentAccountPayload!.BankAccountPayload!.AccountType);
    }

    [Fact, TestPriority(270)]
    public async Task INTERAC_E_TRANSFER()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.INTERAC_E_TRANSFER);

        var ACCOUNT_NAME = "atsamd21";
        var EMAIL_OR_MOBILE_NR = "atsamd21@test.com";
        var HOLDER_NAME = "atsamd21";
        var QUESTION = "a very secret question";
        var ANSWER = "answer";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EMAIL_OR_MOBILE_NR).Value = EMAIL_OR_MOBILE_NR;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.QUESTION).Value = QUESTION;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ANSWER).Value = ANSWER;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.InteracETransferAccountPayload!.HolderName);
        Assert.Equal(EMAIL_OR_MOBILE_NR, paymentAccount.PaymentAccountPayload.InteracETransferAccountPayload!.EmailOrMobileNr);
        Assert.Equal(QUESTION, paymentAccount.PaymentAccountPayload.InteracETransferAccountPayload!.Question);
        Assert.Equal(ANSWER, paymentAccount.PaymentAccountPayload.InteracETransferAccountPayload!.Answer);
    }

    [Fact, TestPriority(280)]
    public async Task US_POSTAL_MONEY_ORDER()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.US_POSTAL_MONEY_ORDER);

        var ACCOUNT_NAME = "atsamd21";
        var POSTAL_ADDRESS = "123 Test Street";
        var HOLDER_NAME = "atsamd21";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.HOLDER_NAME).Value = HOLDER_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.POSTAL_ADDRESS).Value = POSTAL_ADDRESS;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        _paymentAccounts.Add(paymentAccount);

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(HOLDER_NAME, paymentAccount.PaymentAccountPayload.USPostalMoneyOrderAccountPayload!.HolderName);
        Assert.Equal(POSTAL_ADDRESS, paymentAccount.PaymentAccountPayload.USPostalMoneyOrderAccountPayload!.PostalAddress);
    }

    [Fact, TestPriority(400)]
    public async Task All_Crypto()
    {
        Dictionary<string, string[]> cryptoAndAddresses = new()
        {
            { "BTC", ["1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa", "34xp4vRoCGJym3xR7yCVPFHoCNxv4Twseo", "3M219KR5vEneNb47ewrPfWyb5jQ2DjxRP6"] },
            { "BCH", ["qp3wjpa3tjlj042zj4m4g7xw7n6n8f3s0l5t8s4pqt", "qr95x0jx8m3fj8w0s6xv0p4gy5r3t6gk8y9f5j2l7h", "qq07k2p5s0r4x3v8t9n6w5y0l2m8h4j7g3p6f0t9v2"] },
            { "ETH", ["0x742d35Cc6634C0532925a3b844Bc454e4438f44e", "0x8ba1f109551bD432803012645Ac136ddd64DBA72", "0x267be1c1d684f78cb4f6a176c4911b741e4ffdc0"] },
            { "LTC", ["LMHEFMwRsQ3nHDfb9zZqynLHxjuJ2hgyyW", "MC2JYMPVWaxqUb9qUkUbjtUwoNMo1tPaLF", "ltc1qhzjptwpym9afcdjhs7jcz6fd0jma0l0rc0e5yr"] },
            { "DAI-ERC20", ["0x4e83362442b8d1bec281594cea3050c8eb01311c", "0x742d35cc6634c0532925a3b844bc454e4438f44e", "0x267be1c1d684f78cb4f6a176c4911b741e4ffdc0"] },
            { "USDT-ERC20", ["0xdAC17F958D2ee523a2206206994597C13D831ec7", "0x742d35Cc6634C0532925a3b844Bc454e4438f44e", "0x28C6c06298d514Db089934071355E5743bf21d60"]},
            { "USDT-TRC20", ["TXLAQ63Xg1NAzckPwKHvzw7CSEmLMEqcdj", "TQqY9dL9x5Y5Yz3u9JteLo75fW4rWuHwoS", "TDhL2jZ7xwP3E2m9A2nJmS8LZ8dC7x1z9Q"] },
            { "USDC-ERC20", ["0xA0b86991c6218b36c1d19D4a2e9Eb0cE3606eB48", "0x742d35Cc6634C0532925a3b844Bc454e4438f44e", "0x28C6c06298d514Db089934071355E5743bf21d60"] },
            { "ADA", ["addr1q8gg2r3vf9zggn48g7m8vx62rwf6warcs4k7ej8mdzmqmesj30jz7psduyk6n4n2qrud2xlv9fgj53n6ds3t8cs4fvzs05yzmz", "addr1q8gg2r3vf9zggn48g7m8vx62rwf6warcs4k7ej8mdzmqmesj30jz7psduyk6n4n2qrud2xlv9fgj53n6ds3t8cs4fvzs05yzmz", "addr1q8gg2r3vf9zggn48g7m8vx62rwf6warcs4k7ej8mdzmqmesj30jz7psduyk6n4n2qrud2xlv9fgj53n6ds3t8cs4fvzs05yzmz"]},
            { "DOGE", ["D78vnQmhBnVwYcr89ZbszhZz5kdTQdMzde", "D8XCFksmTuraYJom9vXqjLoyKdoLo5Sb7M", "DEYjzD9KjoAZ4Aix5qToXWKX5Sa7WMHv7j"] },
            { "XRP", ["rUocf1ixKzTuEe34kmVhRvGqNCofY1NJzV", "rHb9CJAWyB4rj91VRWn96DkukG4bwdtyTh", "rDsbeomae4FXwgQTJp9Rs64Qg9vDiTCdBv"] },
            { "SOL", ["7EcDhSYGxXyscszYEp35KHN8vvw3svAuLKTzXwCFLtV", "7EcDhSYGxXyscszYEp35KHN8vvw3svAuLKTzXwCFLtV", "DpNXPNWvWoHaZ9P3WtfGCb2ZdLihW8VW1w1Ph4KDH9iG"] },
            { "TRX", ["TRjE1H8dxypKM1NZRdysbs9wo7huR4bdNz", "TRjE1H8dxypKM1NZRdysbs9wo7huR4bdNz", "TRjE1H8dxypKM1NZRdysbs9wo7huR4bdNz"] },
            { "ZEC", ["t1ZQ5NzfZxWp4m3q8c4fGFtfiHkvk1s9dJt", "t14oHp2v54vfmdgQ3v3SNuQga8JKHTNi2a1", "t3aPMe94jMKyrgkbH5SSukimvdMFJ59EFhP"] }
        };

        foreach (var crypto in cryptoAndAddresses)
        {
            var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.BLOCK_CHAINS);

            var ACCOUNT_NAME = $"atsamd21 {crypto.Key}";
            var ADDRESS = crypto.Value[0];
            var TRADE_CURRENCIES = crypto.Key;

            paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
            paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ADDRESS).Value = ADDRESS;
            paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

            var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
            {
                PaymentAccountForm = paymentAccountForm
            });

            _paymentAccounts.Add(paymentAccount);

            Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
            Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
            Assert.Equal(ADDRESS, paymentAccount.PaymentAccountPayload.CryptoCurrencyAccountPayload!.Address);

            ACCOUNT_NAME = $"atsamd21 {crypto.Key} 2";
            ADDRESS = crypto.Value[1];
            TRADE_CURRENCIES = crypto.Key;

            paymentAccount = await _paymentAccountService.CreateCryptoCurrencyPaymentAccountAsync(new CreateCryptoCurrencyPaymentAccountRequest
            {
                Address = ADDRESS,
                AccountName = ACCOUNT_NAME,
                CurrencyCode = TRADE_CURRENCIES,
                TradeInstant = false
            });

            _paymentAccounts.Add(paymentAccount);

            Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
            Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
            Assert.Equal(ADDRESS, paymentAccount.PaymentAccountPayload.CryptoCurrencyAccountPayload!.Address);

            ACCOUNT_NAME = $"atsamd21 {crypto.Key} instant";
            ADDRESS = crypto.Value[2];
            TRADE_CURRENCIES = crypto.Key;

            paymentAccount = await _paymentAccountService.CreateCryptoCurrencyPaymentAccountAsync(new CreateCryptoCurrencyPaymentAccountRequest
            {
                Address = ADDRESS,
                AccountName = ACCOUNT_NAME,
                CurrencyCode = TRADE_CURRENCIES,
                TradeInstant = true
            });

            _paymentAccounts.Add(paymentAccount);

            Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
            Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);
            Assert.Equal(ADDRESS, paymentAccount.PaymentAccountPayload.InstantCryptoCurrencyAccountPayload!.Address);
        }
    }

    [Fact, TestPriority(500)]
    public async Task Get_Payment_Accounts_Should_Match_Created_Accounts()
    {
        var paymentAccounts = await _paymentAccountService.GetPaymentAccountsAsync();

        var createdPaymentAccountIds = new HashSet<string>(_paymentAccounts.Select(x => x.Id));

        Assert.True(createdPaymentAccountIds.SetEquals(new HashSet<string>(paymentAccounts.Select(x => x.Id))));
    }

    [Fact, TestPriority(510)]
    public async Task Delete_Account()
    {
        var paymentAccountForm = await _paymentAccountService.GetPaymentAccountFormAsync(PaymentMethodId.CASH_AT_ATM);

        var ACCOUNT_NAME = "atsamd21's account to be deleted";
        var EXTRA_INFO = "Info";
        var TRADE_CURRENCIES = "GBP";

        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.ACCOUNT_NAME).Value = ACCOUNT_NAME;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.EXTRA_INFO).Value = EXTRA_INFO;
        paymentAccountForm.Fields.First(x => x.Id == Shared.Enums.FieldId.TRADE_CURRENCIES).Value = TRADE_CURRENCIES;

        var paymentAccount = await _paymentAccountService.CreatePaymentAccountAsync(new CreatePaymentAccountRequest
        {
            PaymentAccountForm = paymentAccountForm
        });

        Assert.NotNull((await _paymentAccountService.GetPaymentAccountsAsync()).FirstOrDefault(x => x.Id == paymentAccount.Id));

        Assert.Equal(ACCOUNT_NAME, paymentAccount.AccountName);
        Assert.Equal(EXTRA_INFO, paymentAccount.PaymentAccountPayload.CashAtAtmAccountPayload!.ExtraInfo);
        Assert.Equal(TRADE_CURRENCIES, paymentAccount.TradeCurrencies.First().Code);

        await _paymentAccountService.DeletePaymentAccountAsync(paymentAccount.Id);
        var paymentAccounts = await _paymentAccountService.GetPaymentAccountsAsync();

        Assert.Null(paymentAccounts.FirstOrDefault(x => x.Id == paymentAccount.Id));
    }
}
