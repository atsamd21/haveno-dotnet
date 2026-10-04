namespace Haveno.Api.Models;

// Used to fetch payment accounts and in OfferInfo
public enum PaymentMethodId
{
    HAL_CASH,
    SEPA,
    SEPA_INSTANT,
    MONEY_BEAM,
    FASTER_PAYMENTS,
    SWISH,
    ZELLE,
    POPMONEY,
    US_POSTAL_MONEY_ORDER,
    VENMO,
    INTERAC_E_TRANSFER,
    CASH_DEPOSIT,
    PAY_BY_MAIL,
    CASH_AT_ATM,
    MONEY_GRAM,
    WESTERN_UNION,
    NATIONAL_BANK,
    SAME_BANK,
    SPECIFIC_BANKS,
    F2F,
    AMAZON_GIFT_CARD,
    UPHOLD,
    REVOLUT,
    PERFECT_MONEY,
    ADVANCED_CASH,
    TRANSFERWISE,
    TRANSFERWISE_USD,
    PAYSERA,
    PAXUM,
    NEFT,
    RTGS,
    IMPS,
    UPI,
    PAYTM,
    NEQUI,
    BIZUM,
    PIX,
    CAPITUAL,
    CELPAY,
    MONESE,
    SATISPAY,
    TIKKIE,
    VERSE,
    STRIKE,
    SWIFT,
    ACH_TRANSFER,
    DOMESTIC_WIRE_TRANSFER,
    PAYPAL,
    CASH_APP,
    PAYSAFE,
    JAPAN_BANK,
    AUSTRALIA_PAYID,
    ALI_PAY,
    WECHAT_PAY,
    PROMPT_PAY,
    BLOCK_CHAINS,
    BLOCK_CHAINS_INSTANT,
    MERCADO_PAGO,
    MOMO,
    MPESA,
    BLIK,
    VIPPS_MOBILEPAY,
    TWINT,
    NIP,
    PAGO_MOVIL,
    QRIS,
    PAPARA,
    RAAST,
    PAYNOW,
    WERO,
    FPS,
    DUITNOW,
    MB_WAY,
    PAYPAY,
    SBP,
    MIR,
    YOOMONEY,
    UKRAINE_CARD,
    KASPI,
    SPEI,
    GCASH
}

public class PaymentAccountPayload
{
    public string Id { get; set; } = string.Empty;
    public PaymentMethodId PaymentMethodId { get; set; }
    public TimeSpan MaxTradePeriod { get; set; }
    public Dictionary<string, string> ExcludeFromJsonData { get; set; } = [];
    public AliPayAccountPayload? AliPayAccountPayload { get; set; }
    public ChaseQuickPayAccountPayload? ChaseQuickPayAccountPayload { get; set; }
    public ZelleAccountPayload? ZelleAccountPayload { get; set; }
    public CountryBasedPaymentAccountPayload? CountryBasedPaymentAccountPayload { get; set; }
    public CryptoCurrencyAccountPayload? CryptoCurrencyAccountPayload { get; set; }
    public FasterPaymentsAccountPayload? FasterPaymentsAccountPayload { get; set; }
    public InteracETransferAccountPayload? InteracETransferAccountPayload { get; set; }
    public PerfectMoneyAccountPayload? PerfectMoneyAccountPayload { get; set; }
    public SwishAccountPayload? SwishAccountPayload { get; set; }
    public USPostalMoneyOrderAccountPayload? USPostalMoneyOrderAccountPayload { get; set; }
    public UpholdAccountPayload? UpholdAccountPayload { get; set; }
    public CashAppAccountPayload? CashAppAccountPayload { get; set; }
    public MoneyBeamAccountPayload? MoneyBeamAccountPayload { get; set; }
    public VenmoAccountPayload? VenmoAccountPayload { get; set; }
    public PopmoneyAccountPayload? PopmoneyAccountPayload { get; set; }
    public RevolutAccountPayload? RevolutAccountPayload { get; set; }
    public WeChatPayAccountPayload? WeChatPayAccountPayload { get; set; }
    public MoneyGramAccountPayload? MoneyGramAccountPayload { get; set; }
    public HalCashAccountPayload? HalCashAccountPayload { get; set; }
    public PromptPayAccountPayload? PromptPayAccountPayload { get; set; }
    public AdvancedCashAccountPayload? AdvancedCashAccountPayload { get; set; }
    public InstantCryptoCurrencyAccountPayload? InstantCryptoCurrencyAccountPayload { get; set; }
    public JapanBankAccountPayload? JapanBankAccountPayload { get; set; }
    public TransferwiseAccountPayload? TransferwiseAccountPayload { get; set; }
    public AustraliaPayidPayload? AustraliaPayidPayload { get; set; }
    public AmazonGiftCardAccountPayload? AmazonGiftCardAccountPayload { get; set; }
    public PayByMailAccountPayload? PayByMailAccountPayload { get; set; }
    public CapitualAccountPayload? CapitualAccountPayload { get; set; }
    public PayseraAccountPayload? PayseraAccountPayload { get; set; }
    public PaxumAccountPayload? PaxumAccountPayload { get; set; }
    public SwiftAccountPayload? SwiftAccountPayload { get; set; }
    public CelPayAccountPayload? CelPayAccountPayload { get; set; }
    public MoneseAccountPayload? MoneseAccountPayload { get; set; }
    public VerseAccountPayload? VerseAccountPayload { get; set; }
    public CashAtAtmAccountPayload? CashAtAtmAccountPayload { get; set; }
    public PayPalAccountPayload? PayPalAccountPayload { get; set; }
    public PaysafeAccountPayload? PaysafeAccountPayload { get; set; }
    public TwintAccountPayload? TwintAccountPayload { get; set; }
    public NipAccountPayload? NipAccountPayload { get; set; }
    public PagoMovilAccountPayload? PagoMovilAccountPayload { get; set; }
    public QrisAccountPayload? QrisAccountPayload { get; set; }
    public PaparaAccountPayload? PaparaAccountPayload { get; set; }
    public RaastAccountPayload? RaastAccountPayload { get; set; }
    public PayNowAccountPayload? PayNowAccountPayload { get; set; }
    public WeroAccountPayload? WeroAccountPayload { get; set; }
    public FpsAccountPayload? FpsAccountPayload { get; set; }
    public DuitNowAccountPayload? DuitNowAccountPayload { get; set; }
    public MbWayAccountPayload? MbWayAccountPayload { get; set; }
    public PayPayAccountPayload? PayPayAccountPayload { get; set; }
}

public class AliPayAccountPayload
{
    public string AccountNr { get; set; } = string.Empty;
}

public class WeChatPayAccountPayload
{
    public string AccountNr { get; set; } = string.Empty;
}

public class ChaseQuickPayAccountPayload
{
    public string Email { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class ZelleAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string EmailOrMobileNr { get; set; } = string.Empty;
}

public class CountryBasedPaymentAccountPayload
{
    public string CountryCode { get; set; } = string.Empty;
    public List<string> AcceptedCountryCodes { get; set; } = [];
    public BankAccountPayload? BankAccountPayload { get; set; } 
    public CashDepositAccountPayload? CashDepositAccountPayload { get; set; }
    public SepaAccountPayload? SepaAccountPayload { get; set; }
    public WesternUnionAccountPayload? WesternUnionAccountPayload { get; set; }
    public SepaInstantAccountPayload? SepaInstantAccountPayload { get; set; }
    public F2FAccountPayload? F2FAccountPayload { get; set; }
    public UpiAccountPayload? UpiAccountPayload { get; set; }
    public PaytmAccountPayload? PaytmAccountPayload { get; set; }
    public IfscBasedAccountPayload? IfscBasedAccountPayload { get; set; }
    public NequiAccountPayload? NequiAccountPayload { get; set; }
    public BizumAccountPayload? BizumAccountPayload { get; set; }
    public PixAccountPayload? PixAccountPayload { get; set; }
    public SatispayAccountPayload? SatispayAccountPayload { get; set; }
    public StrikeAccountPayload? StrikeAccountPayload { get; set; }
    public TikkieAccountPayload? TikkieAccountPayload { get; set; }
    public TransferwiseUsdAccountPayload? TransferwiseUsdAccountPayload { get; set; }
    public SwiftAccountPayload? SwiftAccountPayload { get; set; }
    public MpesaAccountPayload? MpesaAccountPayload { get; set; }
    public MercadoPagoAccountPayload? MercadoPagoAccountPayload { get; set; }
    public GcashAccountPayload? GcashAccountPayload { get; set; }
    public MomoAccountPayload? MomoAccountPayload { get; set; }
    public SpeiAccountPayload? SpeiAccountPayload { get; set; }
    public BlikAccountPayload? BlikAccountPayload { get; set; }
    public VippsMobilePayAccountPayload? VippsMobilePayAccountPayload { get; set; }
    public SbpAccountPayload? SbpAccountPayload { get; set; }
    public MirAccountPayload? MirAccountPayload { get; set; }
    public YooMoneyAccountPayload? YooMoneyAccountPayload { get; set; }
    public UkraineCardAccountPayload? UkraineCardAccountPayload { get; set; }
    public KaspiAccountPayload? KaspiAccountPayload { get; set; }
}

public class BankAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string BankId { get; set; } = string.Empty;
    public string BranchId { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public string HolderTaxId { get; set; } = string.Empty;
    public NationalBankAccountPayload? NationalBankAccountPayload { get; set; }
    public SameBankAccountPayload? SameBankAccountPayload { get; set; }
    public SpecificBanksAccountPayload? SpecificBanksAccountPayload { get; set; }
    public AchTransferAccountPayload? AchTransferAccountPayload { get; set; }
    public DomesticWireTransferAccountPayload? DomesticWireTransferAccountPayload { get; set; }
    public string NationalAccountId { get; set; } = string.Empty;
}

public class AchTransferAccountPayload
{
    public string HolderAddress { get; set; } = string.Empty;
}

public class DomesticWireTransferAccountPayload
{
    public string HolderAddress { get; set; } = string.Empty;
}

public class NationalBankAccountPayload
{
    public string Placeholder { get; set; } = string.Empty;
}

public class SameBankAccountPayload
{
    public string Placeholder { get; set; } = string.Empty;
}

public class SpecificBanksAccountPayload
{
    public List<string> AcceptedBanks { get; set; } = [];
}

public class JapanBankAccountPayload
{
    public string BankName { get; set; } = string.Empty;
    public string BankCode { get; set; } = string.Empty;
    public string BankBranchName { get; set; } = string.Empty;
    public string BankBranchCode { get; set; } = string.Empty;
    public string BankAccountType { get; set; } = string.Empty;
    public string BankAccountName { get; set; } = string.Empty;
    public string BankAccountNumber { get; set; } = string.Empty;
}

public class AustraliaPayidPayload
{
    public string BankAccountName { get; set; } = string.Empty;
    public string PayId { get; set; } = string.Empty;
    public string ExtraInfo { get; set; } = string.Empty;
}

public class CashDepositAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string HolderEmail { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string BankId { get; set; } = string.Empty;
    public string BranchId { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public string Requirements { get; set; } = string.Empty;
    public string HolderTaxId { get; set; } = string.Empty;
    public string NationalAccountId { get; set; } = string.Empty;
}

public class MoneyGramAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class HalCashAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
}

public class WesternUnionAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class AmazonGiftCardAccountPayload
{
    public string EmailOrMobileNr { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
}

public class SepaAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string Iban { get; set; } = string.Empty;
    public string Bic { get; set; } = string.Empty;
}

public class SepaInstantAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string Iban { get; set; } = string.Empty;
    public string Bic { get; set; } = string.Empty;
}

public class CryptoCurrencyAccountPayload
{
    public string Address { get; set; } = string.Empty;
}

public class InstantCryptoCurrencyAccountPayload
{
    public string Address { get; set; } = string.Empty;
}

public class FasterPaymentsAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string SortCode { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
}

public class InteracETransferAccountPayload
{
    public string EmailOrMobileNr { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

public class OKPayAccountPayload
{
    public string AccountNr { get; set; } = string.Empty;
}

public class UpholdAccountPayload
{
    public string AccountId { get; set; } = string.Empty;
    public string AccountOwner { get; set; } = string.Empty;
}

public class CashAppAccountPayload
{
    public string EmailOrMobileNrOrCashtag { get; set; } = string.Empty;
    public string ExtraInfo { get; set; } = string.Empty;
}

public class MoneyBeamAccountPayload
{
    public string AccountId { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class VenmoAccountPayload
{
    public string EmailOrMobileNrOrUsername { get; set; } = string.Empty;
}

public class PayPalAccountPayload
{
    public string EmailOrMobileNrOrUsername { get; set; } = string.Empty;
    public string ExtraInfo { get; set; } = string.Empty;
}

public class PopmoneyAccountPayload
{
    public string AccountId { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class RevolutAccountPayload
{
    public string Username { get; set; } = string.Empty;
}

public class PerfectMoneyAccountPayload
{
    public string AccountNr { get; set; } = string.Empty;
}

public class SwishAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class USPostalMoneyOrderAccountPayload
{
    public string PostalAddress { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class F2FAccountPayload
{
    public string Contact { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ExtraInfo { get; set; } = string.Empty;
}

public class IfscBasedAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string Ifsc { get; set; } = string.Empty;
    public object Payload { get; set; } = string.Empty;
}

public class NeftAccountPayload { }

public class RtgsAccountPayload { }

public class ImpsAccountPayload { }

public class UpiAccountPayload
{
    public string VirtualPaymentAddress { get; set; } = string.Empty;
}

public class PaytmAccountPayload
{
    public string EmailOrMobileNr { get; set; } = string.Empty;
}

public class PayByMailAccountPayload
{
    public string PostalAddress { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string ExtraInfo { get; set; } = string.Empty;
}

public class CashAtAtmAccountPayload
{
    public string ExtraInfo { get; set; } = string.Empty;
}

public class PromptPayAccountPayload
{
    public string PromptPayId { get; set; } = string.Empty;
}

public class AdvancedCashAccountPayload
{
    public string AccountNr { get; set; } = string.Empty;
}

public class TransferwiseAccountPayload
{
    public string Email { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class TransferwiseUsdAccountPayload
{
    public string Email { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string HolderAddress { get; set; } = string.Empty;
}

public class PayseraAccountPayload
{
    public string Email { get; set; } = string.Empty;
}

public class PaxumAccountPayload
{
    public string Email { get; set; } = string.Empty;
}

public class CapitualAccountPayload
{
    public string AccountNr { get; set; } = string.Empty;
}

public class CelPayAccountPayload
{
    public string Email { get; set; } = string.Empty;
}

public class NequiAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
}

public class BizumAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
}

public class PixAccountPayload
{
    public string PixKey { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class MoneseAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class SatispayAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class StrikeAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
}

public class TikkieAccountPayload
{
    public string Iban { get; set; } = string.Empty;
}

public class VerseAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
}

public class SwiftAccountPayload
{
    public string BeneficiaryName { get; set; } = string.Empty;
    public string BeneficiaryAccountNr { get; set; } = string.Empty;
    public string BeneficiaryAddress { get; set; } = string.Empty;
    public string BeneficiaryCity { get; set; } = string.Empty;
    public string BeneficiaryPhone { get; set; } = string.Empty;
    public string SpecialInstructions { get; set; } = string.Empty;
    public string BankSwiftCode { get; set; } = string.Empty;
    public string BankCountryCode { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string BankBranch { get; set; } = string.Empty;
    public string BankAddress { get; set; } = string.Empty;
    public string IntermediarySwiftCode { get; set; } = string.Empty;
    public string IntermediaryCountryCode { get; set; } = string.Empty;
    public string IntermediaryName { get; set; } = string.Empty;
    public string IntermediaryBranch { get; set; } = string.Empty;
    public string IntermediaryAddress { get; set; } = string.Empty;
}

public class PaysafeAccountPayload
{
    public string Email { get; set; } = string.Empty;
}

public class MpesaAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string MobileNr { get; set; } = string.Empty;
}

public class MercadoPagoAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string EmailOrMobileNr { get; set; } = string.Empty;
}

public class GcashAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string MobileNr { get; set; } = string.Empty;
}

public class MomoAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string MobileNr { get; set; } = string.Empty;
}

public class SpeiAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string Clabe { get; set; } = string.Empty;
}

public class BlikAccountPayload
{
    public string ExtraInfo { get; set; } = string.Empty;
}

public class VippsMobilePayAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class TwintAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class NipAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
}

public class PagoMovilAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string MobileNr { get; set; } = string.Empty;
    public string HolderTaxId { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
}

public class QrisAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
}

public class PaparaAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
}

public class RaastAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
}

public class WeroAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class FpsAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
}

public class DuitNowAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
}

public class MbWayAccountPayload
{
    public string MobileNr { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
}

public class PayPayAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
}

public class SbpAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string MobileNr { get; set; } = string.Empty;
}

public class MirAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
}

public class YooMoneyAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
}

public class UkraineCardAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
}

public class KaspiAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
}

public class PayNowAccountPayload
{
    public string HolderName { get; set; } = string.Empty;
    public string AccountNr { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
}
