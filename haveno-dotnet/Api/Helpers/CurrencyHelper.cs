using System.Globalization;

namespace Haveno.Api.Helpers;

//public enum FiatCurrency
//{
//    AFN,
//    EUR,
//    ALL,
//    DZD,
//    USD,
//    AOA,
//    XCD,
//    ARS,
//    AMD,
//    AWG,
//    AUD,
//    AZN,
//    BSD,
//    BHD,
//    BDT,
//    BBD,
//    BYN,
//    BZD,
//    XOF,
//    BMD,
//    BTN,
//    BOB,
//    BAM,
//    BWP,
//    BRL,
//    BND,
//    BGN,
//    BIF,
//    KHR,
//    XAF,
//    CAD,
//    CVE,
//    KYD,
//    CLP,
//    CNY,
//    COP,
//    KMF,
//    CDF,
//    NZD,
//    CRC,
//    CUP,
//    ANG,
//    CZK,
//    DKK,
//    DJF,
//    DOP,
//    EGP,
//    ERN,
//    ETB,
//    FKP,
//    FJD,
//    XPF,
//    GMD,
//    GEL,
//    GHS,
//    GIP,
//    GTQ,
//    GBP,
//    GNF,
//    GYD,
//    HTG,
//    HNL,
//    HKD,
//    HUF,
//    ISK,
//    INR,
//    IDR,
//    IRR,
//    IQD,
//    ILS,
//    JMD,
//    JPY,
//    JOD,
//    KZT,
//    KES,
//    KWD,
//    KGS,
//    LAK,
//    LBP,
//    ZAR,
//    LRD,
//    LYD,
//    CHF,
//    MOP,
//    MKD,
//    MGA,
//    MWK,
//    MYR,
//    MVR,
//    MRU,
//    MUR,
//    MXN,
//    MDL,
//    MNT,
//    MAD,
//    MZN,
//    MMK,
//    NAD,
//    NPR,
//    NIO,
//    NGN,
//    KPW,
//    NOK,
//    OMR,
//    PKR,
//    PAB,
//    PGK,
//    PYG,
//    PEN,
//    PHP,
//    PLN,
//    QAR,
//    RON,
//    RUB,
//    RWF,
//    SHP,
//    WST,
//    STN,
//    SAR,
//    RSD,
//    SCR,
//    SLE,
//    SGD,
//    SBD,
//    SOS,
//    KRW,
//    SSP,
//    LKR,
//    SDG,
//    SRD,
//    SZL,
//    SEK,
//    SYP,
//    TWD,
//    TJS,
//    TZS,
//    THB,
//    TOP,
//    TTD,
//    TND,
//    TRY,
//    TMT,
//    UGX,
//    UAH,
//    AED,
//    UYU,
//    UZS,
//    VUV,
//    VES,
//    VND,
//    YER,
//    ZMW
//}

//public enum CryptoCurrency
//{
//    BTC,
//    BCH,
//    ETH,
//    LTC,
//    DAI_ERC20,
//    USDT_ERC20,
//    USDT_TRC20,
//    USDC_ERC20,
//    DOGE,
//    XRP,
//    ADA,
//    SOL,
//    TRX
//}

//public enum NonFiatCurrency
//{
//    XAG,
//    XAU,
//    XGB
//}

//public static class NonFiatCurrencyHelper
//{
//    public static Dictionary<NonFiatCurrency, string> NonFiatCurrencyDictionary { get; } = new()
//    {
//        { NonFiatCurrency.XAG, "Silver" },
//        { NonFiatCurrency.XAU, "Gold" },
//        { NonFiatCurrency.XGB, "Goldback" }
//    };
//}

//public static class CryptoCurrencyHelper
//{
//    public static Dictionary<string, string> CryptoCurrenciesDictionary { get; } = new()
//    {
//        { "BTC", "Bitcoin" },
//        { "BCH", "Bitcoin Cash" },
//        { "ETH", "Ether" },
//        { "LTC", "Litecoin" },
//        { "DAI-ERC20", "Dai Stablecoin (ERC20)" },
//        { "USDT-ERC20", "Tether USD (ERC20)" },
//        { "USDT-TRC20", "Tether USD (TRC20)" },
//        { "USDC-ERC20", "USD Coin (ERC20)" },
//        { "DOGE", "Dogecoin" },
//        { "XRP", "Ripple" },
//        { "ADA", "Cardano" },
//        { "SOL", "Solana" },
//        { "TRX", "Tron" }
//    };
//}

public enum CurrencyCode
{
    // Traditional
    AFN,
    EUR,
    ALL,
    DZD,
    USD,
    AOA,
    XCD,
    ARS,
    AMD,
    AWG,
    AUD,
    AZN,
    BSD,
    BHD,
    BDT,
    BBD,
    BYN,
    BZD,
    XOF,
    BMD,
    BTN,
    BOB,
    BAM,
    BWP,
    BRL,
    BND,
    BGN,
    BIF,
    KHR,
    XAF,
    CAD,
    CVE,
    KYD,
    CLP,
    CNY,
    COP,
    KMF,
    CDF,
    NZD,
    CRC,
    CUP,
    ANG,
    CZK,
    DKK,
    DJF,
    DOP,
    EGP,
    ERN,
    ETB,
    FKP,
    FJD,
    XPF,
    GMD,
    GEL,
    GHS,
    GIP,
    GTQ,
    GBP,
    GNF,
    GYD,
    HTG,
    HNL,
    HKD,
    HUF,
    ISK,
    INR,
    IDR,
    IRR,
    IQD,
    ILS,
    JMD,
    JPY,
    JOD,
    KZT,
    KES,
    KWD,
    KGS,
    LAK,
    LBP,
    ZAR,
    LRD,
    LYD,
    CHF,
    MOP,
    MKD,
    MGA,
    MWK,
    MYR,
    MVR,
    MRU,
    MUR,
    MXN,
    MDL,
    MNT,
    MAD,
    MZN,
    MMK,
    NAD,
    NPR,
    NIO,
    NGN,
    KPW,
    NOK,
    OMR,
    PKR,
    PAB,
    PGK,
    PYG,
    PEN,
    PHP,
    PLN,
    QAR,
    RON,
    RUB,
    RWF,
    SHP,
    WST,
    STN,
    SAR,
    RSD,
    SCR,
    SLE,
    SGD,
    SBD,
    SOS,
    KRW,
    SSP,
    LKR,
    SDG,
    SRD,
    SZL,
    SEK,
    SYP,
    TWD,
    TJS,
    TZS,
    THB,
    TOP,
    TTD,
    TND,
    TRY,
    TMT,
    UGX,
    UAH,
    AED,
    UYU,
    UZS,
    VUV,
    VES,
    VND,
    YER,
    ZMW,
    // Non traditional
    XAG,
    XAU,
    XGB,
    // Crypto
    BTC, 
    BCH, 
    ETH, 
    LTC, 
    DAI_ERC20,
    USDT_ERC20,
    USDT_TRC20,
    USDC_ERC20, 
    DOGE,
    XRP, 
    ADA, 
    SOL, 
    TRX
}

//public static class CurrencyData
//{
//    public static Dictionary<string, string> CryptoCurrenciesDictionary { get; } = new()
//    {
//        { "BTC", "Bitcoin" },
//        { "BCH", "Bitcoin Cash" },
//        { "ETH", "Ether" },
//        { "LTC", "Litecoin" },
//        { "DAI-ERC20", "Dai Stablecoin (ERC20)" },
//        { "USDT-ERC20", "Tether USD (ERC20)" },
//        { "USDT-TRC20", "Tether USD (TRC20)" },
//        { "USDC-ERC20", "USD Coin (ERC20)" },
//        { "DOGE", "Dogecoin" },
//        { "XRP", "Ripple" },
//        { "ADA", "Cardano" },
//        { "SOL", "Solana" },
//        { "TRX", "Tron" },
//        { "ZEC", "Zcash" }
//    };

//    public static Dictionary<string, string> NonFiatCurrencyDictionary { get; } = new()
//    {
//        { "XAG", "Silver" },
//        { "XAU", "Gold" },
//        { "XGB", "Goldback" }
//    };

//    public static Dictionary<string, string> FiatCurrenciesDictionary { get; } = [];

//    public static Dictionary<string, string> AllCurrenciesDictionary { get; }

//    static CurrencyData()
//    {
//        var regionInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
//            .Select(x => new RegionInfo(x.Name));

//        //var regionInfos = CountryHelper.Countries
//        //    .Select(x => new RegionInfo(x.Name))
//        //    .DistinctBy(x => x.ISOCurrencySymbol);

//        foreach (var regionInfo in regionInfos)
//        {
//            FiatCurrenciesDictionary.Add(
//                regionInfo.ISOCurrencySymbol, 
//                regionInfo.CurrencyEnglishName);
//        }

//        AllCurrenciesDictionary = new(FiatCurrenciesDictionary);

//        foreach (var nonFiatCurrency in NonFiatCurrencyDictionary)
//        {
//            AllCurrenciesDictionary.Add(nonFiatCurrency.Key, nonFiatCurrency.Value);
//        }

//        foreach (var cryptoCurrency in CryptoCurrenciesDictionary)
//        {
//            AllCurrenciesDictionary.Add(cryptoCurrency.Key, cryptoCurrency.Value);
//        }
//    }
//}

//public static class FiatCurrencyHelper
//{
//    public static Dictionary<FiatCurrency, string> FiatCurrenciesDictionary { get; } = [];

//    static FiatCurrencyHelper()
//    {
//        var regionInfos = CountryHelper.Countries
//            .Select(x => new RegionInfo(x.Name))
//            .DistinctBy(x => x.ISOCurrencySymbol);

//        foreach (var regionInfo in regionInfos)
//        {
//            FiatCurrenciesDictionary.Add(Enum.Parse<FiatCurrency>(regionInfo.ISOCurrencySymbol), regionInfo.CurrencyEnglishName);
//        }
//    }

//    //public static NumberFormatInfo? GetNumberFormatForCurrency(CurrencyHelper currency)
//    //{
//    //    return GetCultureInfoForCurrency(currency)?.NumberFormat ?? null;
//    //}

//    //public static string? GetCurrencyFullName(CurrencyHelper currency)
//    //{
//    //    var cultureInfo = GetCultureInfoForCurrency(currency);
//    //    if (cultureInfo is null)
//    //        return null;

//    //    RegionInfo region = new(cultureInfo.Name);
//    //    return region.CurrencyEnglishName + $" ({currency})";
//    //}

//    //public static IEnumerable<string> GetCurrencyFullNames()
//    //{
//    //    foreach (var currency in Enum.GetValues<CurrencyHelper>())
//    //    {
//    //        var cultureInfo = GetCultureInfoForCurrency(currency);
//    //        if (cultureInfo is null)
//    //        {
//    //            yield return $"{currency}";
//    //        }
//    //        else
//    //        {
//    //            RegionInfo region = new(cultureInfo.Name);
//    //            yield return region.CurrencyEnglishName + $" ({currency})";
//    //        }
//    //    }
//    //}

//    //public static IEnumerable<KeyValuePair<string, string>> GetCurrencyFullNamesAndCurrencyCodeDictionary()
//    //{
//    //    foreach (var currency in Enum.GetValues<CurrencyHelper>())
//    //    {
//    //        var cultureInfo = GetCultureInfoForCurrency(currency);
//    //        if (cultureInfo is null)
//    //        {
//    //            yield return new KeyValuePair<string, string>(currency.ToString(), $"{currency}");
//    //        }
//    //        else
//    //        {
//    //            RegionInfo region = new(cultureInfo.Name);
//    //            yield return new KeyValuePair<string, string>(currency.ToString(), region.CurrencyEnglishName + $" ({currency})");
//    //        }
//    //    }
//    //}
//}

public static class CurrencyHelper 
{
    public static Dictionary<string, string> FiatCurrenciesDictionary { get; } = [];
    public static Dictionary<string, string> CryptoCurrenciesDictionary { get; } = new()
    {
        { "BTC", "Bitcoin" },
        { "BCH", "Bitcoin Cash" },
        { "ETH", "Ether" },
        { "LTC", "Litecoin" },
        { "DAI-ERC20", "Dai Stablecoin (ERC20)" },
        { "USDT-ERC20", "Tether USD (ERC20)" },
        { "USDT-TRC20", "Tether USD (TRC20)" },
        { "USDC-ERC20", "USD Coin (ERC20)" },
        { "DOGE", "Dogecoin" },
        { "XRP", "Ripple" },
        { "ADA", "Cardano" },
        { "SOL", "Solana" },
        { "TRX", "Tron" },
        { "ZEC", "Zcash" }
    };

    public static Dictionary<string, string> NonFiatCurrencyDictionary { get; } = new()
    {
        { "XAG", "Silver" },
        { "XAU", "Gold" },
        { "XGB", "Goldback" }
    };

    static CurrencyHelper()
    {
        var regionInfos = CountryHelper.CultureInfos
            .Select(x => new RegionInfo(x.Name))
            .Where(x => x.TwoLetterISORegionName.Length == 2)
            .DistinctBy(x => x.ISOCurrencySymbol)
            .OrderBy(x => x.CurrencyEnglishName);

        FiatCurrenciesDictionary = regionInfos.ToDictionary(x => x.ISOCurrencySymbol, y => y.CurrencyEnglishName);
    }
}
