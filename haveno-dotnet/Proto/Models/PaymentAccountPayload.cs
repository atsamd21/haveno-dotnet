using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "PaymentAccountPayload")]
internal class PaymentAccountPayload
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string PaymentMethodId { get; set; } = string.Empty;
    [ProtoMember(3)]
    public long MaxTradePeriod { get; set; }
    [ProtoMember(4)]
    public Dictionary<string, string> ExcludeFromJsonData { get; set; } = [];
    [ProtoMember(5)]
    public AliPayAccountPayload? AliPayAccountPayload { get; set; }
    [ProtoMember(6)]
    public ChaseQuickPayAccountPayload? ChaseQuickPayAccountPayload { get; set; }
    [ProtoMember(7)]
    public ZelleAccountPayload? ZelleAccountPayload { get; set; }
    [ProtoMember(8)]
    public CountryBasedPaymentAccountPayload? CountryBasedPaymentAccountPayload { get; set; }
    [ProtoMember(9)]
    public CryptoCurrencyAccountPayload? CryptoCurrencyAccountPayload { get; set; }
    [ProtoMember(10)]
    public FasterPaymentsAccountPayload? FasterPaymentsAccountPayload { get; set; }
    [ProtoMember(11)]
    public InteracETransferAccountPayload? InteracETransferAccountPayload { get; set; }
    [ProtoMember(12)]
    [Obsolete]
    public OKPayAccountPayload? OKPayAccountPayload { get; set; }
    [ProtoMember(13)]
    public PerfectMoneyAccountPayload? PerfectMoneyAccountPayload { get; set; }
    [ProtoMember(14)]
    public SwishAccountPayload? SwishAccountPayload { get; set; }
    [ProtoMember(15)]
    public USPostalMoneyOrderAccountPayload? USPostalMoneyOrderAccountPayload { get; set; }
    [ProtoMember(16)]
    public UpholdAccountPayload? UpholdAccountPayload { get; set; }
    [ProtoMember(17)]
    public CashAppAccountPayload? CashAppAccountPayload { get; set; }
    [ProtoMember(18)]
    public MoneyBeamAccountPayload? MoneyBeamAccountPayload { get; set; }
    [ProtoMember(19)]
    public VenmoAccountPayload? VenmoAccountPayload { get; set; }
    [ProtoMember(20)]
    public PopmoneyAccountPayload? PopmoneyAccountPayload { get; set; }
    [ProtoMember(21)]
    public RevolutAccountPayload? RevolutAccountPayload { get; set; }
    [ProtoMember(22)]
    public WeChatPayAccountPayload? WeChatPayAccountPayload { get; set; }
    [ProtoMember(23)]
    public MoneyGramAccountPayload? MoneyGramAccountPayload { get; set; }
    [ProtoMember(24)]
    public HalCashAccountPayload? HalCashAccountPayload { get; set; }
    [ProtoMember(25)]
    public PromptPayAccountPayload? PromptPayAccountPayload { get; set; }
    [ProtoMember(26)]
    public AdvancedCashAccountPayload? AdvancedCashAccountPayload { get; set; }
    [ProtoMember(27)]
    public InstantCryptoCurrencyAccountPayload? InstantCryptoCurrencyAccountPayload { get; set; }
    [ProtoMember(28)]
    public JapanBankAccountPayload? JapanBankAccountPayload { get; set; }
    [ProtoMember(29)]
    public TransferwiseAccountPayload? TransferwiseAccountPayload { get; set; }
    [ProtoMember(30)]
    public AustraliaPayidPayload? AustraliaPayidPayload { get; set; }
    [ProtoMember(31)]
    public AmazonGiftCardAccountPayload? AmazonGiftCardAccountPayload { get; set; }
    [ProtoMember(32)]
    public PayByMailAccountPayload? PayByMailAccountPayload { get; set; }
    [ProtoMember(33)]
    public CapitualAccountPayload? CapitualAccountPayload { get; set; }
    [ProtoMember(34)]
    public PayseraAccountPayload? PayseraAccountPayload { get; set; }
    [ProtoMember(35)]
    public PaxumAccountPayload? PaxumAccountPayload { get; set; }
    [ProtoMember(36)]
    public SwiftAccountPayload? SwiftAccountPayload { get; set; }
    [ProtoMember(37)]
    public CelPayAccountPayload? CelPayAccountPayload { get; set; }
    [ProtoMember(38)]
    public MoneseAccountPayload? MoneseAccountPayload { get; set; }
    [ProtoMember(39)]
    public VerseAccountPayload? VerseAccountPayload { get; set; }
    [ProtoMember(40)]
    public CashAtAtmAccountPayload? CashAtAtmAccountPayload { get; set; }
    [ProtoMember(41)]
    public PayPalAccountPayload? PayPalAccountPayload { get; set; }
    [ProtoMember(42)]
    public PaysafeAccountPayload? PaysafeAccountPayload { get; set; }
    [ProtoMember(43)]
    public TwintAccountPayload? TwintAccountPayload { get; set; }
    [ProtoMember(44)]
    public NipAccountPayload? NipAccountPayload { get; set; }
    [ProtoMember(45)]
    public PagoMovilAccountPayload? PagoMovilAccountPayload { get; set; }
    [ProtoMember(46)]
    public QrisAccountPayload? QrisAccountPayload { get; set; }
    [ProtoMember(47)]
    public PaparaAccountPayload? PaparaAccountPayload { get; set; }
    [ProtoMember(48)]
    public RaastAccountPayload? RaastAccountPayload { get; set; }
    [ProtoMember(49)]
    public PayNowAccountPayload? PayNowAccountPayload { get; set; }
    [ProtoMember(50)]
    public WeroAccountPayload? WeroAccountPayload { get; set; }
    [ProtoMember(51)]
    public FpsAccountPayload? FpsAccountPayload { get; set; }
    [ProtoMember(52)]
    public DuitNowAccountPayload? DuitNowAccountPayload { get; set; }
    [ProtoMember(53)]
    public MbWayAccountPayload? MbWayAccountPayload { get; set; }
    [ProtoMember(54)]
    public PayPayAccountPayload? PayPayAccountPayload { get; set; }
}

[ProtoContract(Name = "AliPayAccountPayload")]
internal class AliPayAccountPayload
{
    [ProtoMember(1)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "WeChatPayAccountPayload")]
internal class WeChatPayAccountPayload
{
    [ProtoMember(1)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "ChaseQuickPayAccountPayload")]
internal class ChaseQuickPayAccountPayload
{
    [ProtoMember(1)]
    public string Email { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "ZelleAccountPayload")]
internal class ZelleAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string EmailOrMobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "CountryBasedPaymentAccountPayload")]
internal class CountryBasedPaymentAccountPayload
{
    [ProtoMember(1)]
    public string CountryCode { get; set; } = string.Empty;
    [ProtoMember(2)]
    public List<string> AcceptedCountryCodes { get; set; } = [];
    [ProtoMember(3)]
    public BankAccountPayload? BankAccountPayload { get; set; }
    [ProtoMember(4)]
    public CashDepositAccountPayload? CashDepositAccountPayload { get; set; }
    [ProtoMember(5)]
    public SepaAccountPayload? SepaAccountPayload { get; set; }
    [ProtoMember(6)]
    public WesternUnionAccountPayload? WesternUnionAccountPayload { get; set; }
    [ProtoMember(7)]
    public SepaInstantAccountPayload? SepaInstantAccountPayload { get; set; }
    [ProtoMember(8)]
    public F2FAccountPayload? F2FAccountPayload { get; set; }
    [ProtoMember(9)]
    public UpiAccountPayload? UpiAccountPayload { get; set; }
    [ProtoMember(10)]
    public PaytmAccountPayload? PaytmAccountPayload { get; set; }
    [ProtoMember(11)]
    public IfscBasedAccountPayload? IfscBasedAccountPayload { get; set; }
    [ProtoMember(12)]
    public NequiAccountPayload? NequiAccountPayload { get; set; }
    [ProtoMember(13)]
    public BizumAccountPayload? BizumAccountPayload { get; set; }
    [ProtoMember(14)]
    public PixAccountPayload? PixAccountPayload { get; set; }
    [ProtoMember(15)]
    public SatispayAccountPayload? SatispayAccountPayload { get; set; }
    [ProtoMember(16)]
    public StrikeAccountPayload? StrikeAccountPayload { get; set; }
    [ProtoMember(17)]
    public TikkieAccountPayload? TikkieAccountPayload { get; set; }
    [ProtoMember(18)]
    public TransferwiseUsdAccountPayload? TransferwiseUsdAccountPayload { get; set; }
    [ProtoMember(19)]
    public SwiftAccountPayload? SwiftAccountPayload { get; set; }
    [ProtoMember(20)]
    public MpesaAccountPayload? MpesaAccountPayload { get; set; }
    [ProtoMember(21)]
    public MercadoPagoAccountPayload? MercadoPagoAccountPayload { get; set; }
    [ProtoMember(22)]
    public GcashAccountPayload? GcashAccountPayload { get; set; }
    [ProtoMember(23)]
    public MomoAccountPayload? MomoAccountPayload { get; set; }
    [ProtoMember(24)]
    public SpeiAccountPayload? SpeiAccountPayload { get; set; }
    [ProtoMember(25)]
    public BlikAccountPayload? BlikAccountPayload { get; set; }
    [ProtoMember(26)]
    public VippsMobilePayAccountPayload? VippsMobilePayAccountPayload { get; set; }
    [ProtoMember(27)]
    public SbpAccountPayload? SbpAccountPayload { get; set; }
    [ProtoMember(28)]
    public MirAccountPayload? MirAccountPayload { get; set; }
    [ProtoMember(29)]
    public YooMoneyAccountPayload? YooMoneyAccountPayload { get; set; }
    [ProtoMember(30)]
    public UkraineCardAccountPayload? UkraineCardAccountPayload { get; set; }
    [ProtoMember(31)]
    public KaspiAccountPayload? KaspiAccountPayload { get; set; }
}

[ProtoContract(Name = "BankAccountPayload")]
internal class BankAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string BankName { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankId { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string BranchId { get; set; } = string.Empty;
    [ProtoMember(5)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(6)]
    public string AccountType { get; set; } = string.Empty;
    [ProtoMember(7)]
    public string HolderTaxId { get; set; } = string.Empty;
    [Obsolete]
    [ProtoMember(8)]
    public string Email { get; set; } = string.Empty;
    [ProtoMember(9)]
    public NationalBankAccountPayload? NationalBankAccountPayload { get; set; }
    [ProtoMember(10)]
    public SameBankAccountPayload? SameBankAccontPayload { get; set; }
    [ProtoMember(11)]
    public SpecificBanksAccountPayload? SpecificBanksAccountPayload { get; set; }
    [ProtoMember(13)]
    public AchTransferAccountPayload? AchTransferAccountPayload { get; set; }
    [ProtoMember(14)]
    public DomesticWireTransferAccountPayload? DomesticWireTransferAccountPayload { get; set; }
    [ProtoMember(12)]
    public string NationalAccountId { get; set; } = string.Empty;
}

[ProtoContract(Name = "AchTransferAccountPayload")]
internal class AchTransferAccountPayload
{
    [ProtoMember(1)]
    public string HolderAddress { get; set; } = string.Empty;
}

[ProtoContract(Name = "DomesticWireTransferAccountPayload")]
internal class DomesticWireTransferAccountPayload
{
    [ProtoMember(1)]
    public string HolderAddress { get; set; } = string.Empty;
}

[ProtoContract(Name = "NationalBankAccountPayload")]
internal class NationalBankAccountPayload
{
    [ProtoMember(1)]
    public string Placeholder { get; set; } = string.Empty;
}

[ProtoContract(Name = "SameBankAccountPayload")]
internal class SameBankAccountPayload
{
    [ProtoMember(1)]
    public string Placeholder { get; set; } = string.Empty;
}

[ProtoContract(Name = "SpecificBanksAccountPayload")]
internal class SpecificBanksAccountPayload
{
    [ProtoMember(1)]
    public List<string> AcceptedBanks { get; set; } = [];
}

[ProtoContract(Name = "JapanBankAccountPayload")]
internal class JapanBankAccountPayload
{
    [ProtoMember(1)]
    public string BankName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string BankCode { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankBranchName { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string BankBranchCode { get; set; } = string.Empty;
    [ProtoMember(5)]
    public string BankAccountType { get; set; } = string.Empty;
    [ProtoMember(6)]
    public string BankAccountName { get; set; } = string.Empty;
    [ProtoMember(7)]
    public string BankAccountNumber { get; set; } = string.Empty;
}

[ProtoContract(Name = "AustraliaPayidPayload")]
internal class AustraliaPayidPayload
{
    [ProtoMember(1)]
    public string BankAccountName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string PayId { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string ExtraInfo { get; set; } = string.Empty;
}

[ProtoContract(Name = "CashDepositAccountPayload")]
internal class CashDepositAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderEmail { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankName { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string BankId { get; set; } = string.Empty;
    [ProtoMember(5)]
    public string BranchId { get; set; } = string.Empty;
    [ProtoMember(6)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(7)]
    public string AccountType { get; set; } = string.Empty;
    [ProtoMember(8)]
    public string Requirements { get; set; } = string.Empty;
    [ProtoMember(9)]
    public string HolderTaxId { get; set; } = string.Empty;
    [ProtoMember(10)]
    public string NationalAccountId { get; set; } = string.Empty;
}

[ProtoContract(Name = "MoneyGramAccountPayload")]
internal class MoneyGramAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string CountryCode { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string State { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string Email { get; set; } = string.Empty;
}

[ProtoContract(Name = "HalCashAccountPayload")]
internal class HalCashAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "WesternUnionAccountPayload")]
internal class WesternUnionAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string City { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string State { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string Email { get; set; } = string.Empty;
}

[ProtoContract(Name = "AmazonGiftCardAccountPayload")]
internal class AmazonGiftCardAccountPayload
{
    [ProtoMember(1)]
    public string EmailOrMobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string CountryCode { get; set; } = string.Empty;
}

[ProtoContract(Name = "SepaAccountPayload")]
internal class SepaAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Iban { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Bic { get; set; } = string.Empty;
}

[ProtoContract(Name = "SepaInstantAccountPayload")]
internal class SepaInstantAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Iban { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Bic { get; set; } = string.Empty;
}

[ProtoContract(Name = "CryptoCurrencyAccountPayload")]
internal class CryptoCurrencyAccountPayload
{
    [ProtoMember(1)]
    public string Address { get; set; } = string.Empty;
}

[ProtoContract(Name = "InstantCryptoCurrencyAccountPayload")]
internal class InstantCryptoCurrencyAccountPayload
{
    [ProtoMember(1)]
    public string Address { get; set; } = string.Empty;
}

[ProtoContract(Name = "FasterPaymentsAccountPayload")]
internal class FasterPaymentsAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string SortCode { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "InteracETransferAccountPayload")]
internal class InteracETransferAccountPayload
{
    [ProtoMember(1)]
    public string EmailOrMobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Question { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string Answer { get; set; } = string.Empty;
}

[ProtoContract(Name = "OKPayAccountPayload")]
internal class OKPayAccountPayload
{
    [ProtoMember(1)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "UpholdAccountPayload")]
internal class UpholdAccountPayload
{
    [ProtoMember(1)]
    public string AccountId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountOwner { get; set; } = string.Empty;
}

[ProtoContract(Name = "CashAppAccountPayload")]
internal class CashAppAccountPayload
{
    [ProtoMember(1)]
    public string EmailOrMobileNrOrCashtag { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string ExtraInfo { get; set; } = string.Empty;
}

[ProtoContract(Name = "MoneyBeamAccountPayload")]
internal class MoneyBeamAccountPayload
{
    [ProtoMember(1)]
    public string AccountId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "VenmoAccountPayload")]
internal class VenmoAccountPayload
{
    [ProtoMember(1)]
    public string EmailOrMobileNrOrUsername { get; set; } = string.Empty;
}

[ProtoContract(Name = "PayPalAccountPayload")]
internal class PayPalAccountPayload
{
    [ProtoMember(1)]
    public string EmailOrMobileNrOrUsername { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string ExtraInfo { get; set; } = string.Empty;
}

[ProtoContract(Name = "PopmoneyAccountPayload")]
internal class PopmoneyAccountPayload
{
    [ProtoMember(1)]
    public string AccountId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "RevolutAccountPayload")]
internal class RevolutAccountPayload
{
    [ProtoMember(1)]
    public string Username { get; set; } = string.Empty;
}

[ProtoContract(Name = "PerfectMoneyAccountPayload")]
internal class PerfectMoneyAccountPayload
{
    [ProtoMember(1)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "SwishAccountPayload")]
internal class SwishAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "USPostalMoneyOrderAccountPayload")]
internal class USPostalMoneyOrderAccountPayload
{
    [ProtoMember(1)]
    public string PostalAddress { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "F2FAccountPayload")]
internal class F2FAccountPayload
{
    [ProtoMember(1)]
    public string Contact { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string City { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string ExtraInfo { get; set; } = string.Empty;
}

[ProtoContract(Name = "IfscBasedAccountPayload")]
internal class IfscBasedAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Ifsc { get; set; } = string.Empty;
    [ProtoMember(4)]
    public object Payload { get; set; } = string.Empty;
}

[ProtoContract(Name = "NeftAccountPayload")]
internal class NeftAccountPayload { }

[ProtoContract(Name = "RtgsAccountPayload")]
internal class RtgsAccountPayload { }

[ProtoContract(Name = "ImpsAccountPayload")]
internal class ImpsAccountPayload { }

[ProtoContract(Name = "UpiAccountPayload")]
internal class UpiAccountPayload
{
    [ProtoMember(1)]
    public string VirtualPaymentAddress { get; set; } = string.Empty;
}

[ProtoContract(Name = "PaytmAccountPayload")]
internal class PaytmAccountPayload
{
    [ProtoMember(1)]
    public string EmailOrMobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "PayByMailAccountPayload")]
internal class PayByMailAccountPayload
{
    [ProtoMember(1)]
    public string PostalAddress { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Contact { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string ExtraInfo { get; set; } = string.Empty;
}

[ProtoContract(Name = "CashAtAtmAccountPayload")]
internal class CashAtAtmAccountPayload
{
    [ProtoMember(1)]
    public string ExtraInfo { get; set; } = string.Empty;
}

[ProtoContract(Name = "PromptPayAccountPayload")]
internal class PromptPayAccountPayload
{
    [ProtoMember(1)]
    public string PromptPayId { get; set; } = string.Empty;
}

[ProtoContract(Name = "AdvancedCashAccountPayload")]
internal class AdvancedCashAccountPayload
{
    [ProtoMember(1)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "TransferwiseAccountPayload")]
internal class TransferwiseAccountPayload
{
    [ProtoMember(1)]
    public string Email { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "TransferwiseUsdAccountPayload")]
internal class TransferwiseUsdAccountPayload
{
    [ProtoMember(1)]
    public string Email { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string HolderAddress { get; set; } = string.Empty;
}

[ProtoContract(Name = "PayseraAccountPayload")]
internal class PayseraAccountPayload
{
    [ProtoMember(1)]
    public string Email { get; set; } = string.Empty;
}

[ProtoContract(Name = "PaxumAccountPayload")]
internal class PaxumAccountPayload
{
    [ProtoMember(1)]
    public string Email { get; set; } = string.Empty;
}

[ProtoContract(Name = "CapitualAccountPayload")]
internal class CapitualAccountPayload
{
    [ProtoMember(1)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "CelPayAccountPayload")]
internal class CelPayAccountPayload
{
    [ProtoMember(1)]
    public string Email { get; set; } = string.Empty;
}

[ProtoContract(Name = "NequiAccountPayload")]
internal class NequiAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "BizumAccountPayload")]
internal class BizumAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "PixAccountPayload")]
internal class PixAccountPayload
{
    [ProtoMember(1)]
    public string PixKey { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "MoneseAccountPayload")]
internal class MoneseAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "SatispayAccountPayload")]
internal class SatispayAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "StrikeAccountPayload")]
internal class StrikeAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "TikkieAccountPayload")]
internal class TikkieAccountPayload
{
    [ProtoMember(1)]
    public string Iban { get; set; } = string.Empty;
}

[ProtoContract(Name = "VerseAccountPayload")]
internal class VerseAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "SwiftAccountPayload")]
internal class SwiftAccountPayload
{
    [ProtoMember(1)]
    public string BeneficiaryName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string BeneficiaryAccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BeneficiaryAddress { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string BeneficiaryCity { get; set; } = string.Empty;
    [ProtoMember(5)]
    public string BeneficiaryPhone { get; set; } = string.Empty;
    [ProtoMember(6)]
    public string SpecialInstructions { get; set; } = string.Empty;
    [ProtoMember(7)]
    public string BankSwiftCode { get; set; } = string.Empty;
    [ProtoMember(8)]
    public string BankCountryCode { get; set; } = string.Empty;
    [ProtoMember(9)]
    public string BankName { get; set; } = string.Empty;
    [ProtoMember(10)]
    public string BankBranch { get; set; } = string.Empty;
    [ProtoMember(11)]
    public string BankAddress { get; set; } = string.Empty;
    [ProtoMember(12)]
    public string IntermediarySwiftCode { get; set; } = string.Empty;
    [ProtoMember(13)]
    public string IntermediaryCountryCode { get; set; } = string.Empty;
    [ProtoMember(14)]
    public string IntermediaryName { get; set; } = string.Empty;
    [ProtoMember(15)]
    public string IntermediaryBranch { get; set; } = string.Empty;
    [ProtoMember(16)]
    public string IntermediaryAddress { get; set; } = string.Empty;
}

[ProtoContract(Name = "PaysafeAccountPayload")]
internal class PaysafeAccountPayload
{
    [ProtoMember(1)]
    public string Email { get; set; } = string.Empty;
}

[ProtoContract(Name = "MpesaAccountPayload")]
internal class MpesaAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string MobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "MercadoPagoAccountPayload")]
internal class MercadoPagoAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string EmailOrMobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "GcashAccountPayload")]
internal class GcashAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string MobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "MomoAccountPayload")]
internal class MomoAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string MobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "SpeiAccountPayload")]
internal class SpeiAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Clabe { get; set; } = string.Empty;
}

[ProtoContract(Name = "BlikAccountPayload")]
internal class BlikAccountPayload
{
    [ProtoMember(1)]
    public string ExtraInfo { get; set; } = string.Empty;
}

[ProtoContract(Name = "VippsMobilePayAccountPayload")]
internal class VippsMobilePayAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "TwintAccountPayload")]
internal class TwintAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "NipAccountPayload")]
internal class NipAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankName { get; set; } = string.Empty;
}

[ProtoContract(Name = "PagoMovilAccountPayload")]
internal class PagoMovilAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string MobileNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string HolderTaxId { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string BankName { get; set; } = string.Empty;
}

[ProtoContract(Name = "QrisAccountPayload")]
internal class QrisAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankName { get; set; } = string.Empty;
}

[ProtoContract(Name = "PaparaAccountPayload")]
internal class PaparaAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankName { get; set; } = string.Empty;
}

[ProtoContract(Name = "RaastAccountPayload")]
internal class RaastAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankName { get; set; } = string.Empty;
}

[ProtoContract(Name = "WeroAccountPayload")]
internal class WeroAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "FpsAccountPayload")]
internal class FpsAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankName { get; set; } = string.Empty;
}

[ProtoContract(Name = "DuitNowAccountPayload")]
internal class DuitNowAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankName { get; set; } = string.Empty;
}

[ProtoContract(Name = "MbWayAccountPayload")]
internal class MbWayAccountPayload
{
    [ProtoMember(1)]
    public string MobileNr { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string HolderName { get; set; } = string.Empty;
}

[ProtoContract(Name = "PayPayAccountPayload")]
internal class PayPayAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "SbpAccountPayload")]
internal class SbpAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string MobileNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "MirAccountPayload")]
internal class MirAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "YooMoneyAccountPayload")]
internal class YooMoneyAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "UkraineCardAccountPayload")]
internal class UkraineCardAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "KaspiAccountPayload")]
internal class KaspiAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
}

[ProtoContract(Name = "PayNowAccountPayload")]
internal class PayNowAccountPayload
{
    [ProtoMember(1)]
    public string HolderName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string AccountNr { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string BankName { get; set; } = string.Empty;
}
