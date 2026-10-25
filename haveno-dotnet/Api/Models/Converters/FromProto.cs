using Haveno.Api.Models.Enums;
using Haveno.Extensions;
using System.Globalization;

namespace Haveno.Api.Models.Converters;

internal static class FromProto
{
    public static Region Convert(this Proto.Models.Region region)
    {
        return new Region
        {
            Code = region.Code,
            Name = region.Name
        };
    }

    public static Country Convert(this Proto.Models.Country country)
    {
        return new Country
        {
            Code = country.Code,
            Name = country.Name,
            Region = country.Region.Convert()
        };
    }

    public static XmrIncomingTransfer Convert(this Proto.Models.XmrIncomingTransfer xmrIncomingTransfer)
    {
        return new XmrIncomingTransfer
        {
            AccountIndex = xmrIncomingTransfer.AccountIndex,
            Address = xmrIncomingTransfer.Address,
            Amount = ulong.Parse(xmrIncomingTransfer.Amount),
            NumSuggestedConfirmations = xmrIncomingTransfer.NumSuggestedConfirmations,
            SubaddressIndex = xmrIncomingTransfer.SubaddressIndex
        };
    }

    public static XmrOutgoingTransfer Convert(this Proto.Models.XmrOutgoingTransfer xmrOutgoingTransfer)
    {
        return new XmrOutgoingTransfer
        {
            AccountIndex = xmrOutgoingTransfer.AccountIndex,
            Amount = ulong.Parse(xmrOutgoingTransfer.Amount),
            SubaddressIndices = xmrOutgoingTransfer.SubaddressIndices,
            Destinations = xmrOutgoingTransfer.Destinations.Select(y => y.Convert()).ToList()
        };
    }

    public static XmrDestination Convert(this Proto.Models.XmrDestination xmrDestination)
    {
        return new XmrDestination
        {
            Amount = ulong.Parse(xmrDestination.Amount),
            Address = xmrDestination.Address
        };
    }

    public static XmrTx Convert(this Proto.Models.XmrTx xmrTx)
    {
        return new XmrTx
        {
            Fee = ulong.Parse(xmrTx.Fee),
            Hash = xmrTx.Hash,
            Height = xmrTx.Height,
            Timestamp = xmrTx.Timestamp.ToDateTime(),
            IsConfirmed = xmrTx.IsConfirmed,
            IsLocked = xmrTx.IsLocked,
            Metadata = xmrTx.Metadata,
            IncomingTransfers = xmrTx.IncomingTransfers.Select(y => y.Convert()).ToList(),
            OutgoingTransfer = xmrTx.OutgoingTransfer?.Convert()
        };
    }

    public static AddressBalanceInfo Convert(this Proto.Models.AddressBalanceInfo addressBalanceInfo)
    {
        return new AddressBalanceInfo
        {
            Address = addressBalanceInfo.Address,
            IsAddressUnused = addressBalanceInfo.IsAddressUnused,
            Balance = checked((ulong)addressBalanceInfo.Balance),
            NumConfirmations = addressBalanceInfo.NumConfirmations
        };
    }

    public static OfferInfo Convert(this Proto.Models.OfferInfo offerInfo)
    {
        return new OfferInfo
        {
            Amount = offerInfo.Amount,
            MinAmount = offerInfo.MinAmount,
            ArbitratorSigner = offerInfo.ArbitratorSigner,
            OwnerNodeAddress = offerInfo.OwnerNodeAddress,
            IsActivated = offerInfo.IsActivated,
            PaymentAccountId = offerInfo.PaymentAccountId,
            BaseCurrencyCode = offerInfo.BaseCurrencyCode,
            CounterCurrencyCode = offerInfo.CounterCurrencyCode,
            BuyerSecurityDepositPercent = offerInfo.BuyerSecurityDepositPct,
            Date = offerInfo.Date.ToDateTime(),
            Direction = Enum.Parse<OfferDirection>(offerInfo.Direction),
            ExtraInfo = offerInfo.ExtraInfo,
            CounterCurrencyMinVolume = decimal.Parse(offerInfo.MinVolume, CultureInfo.InvariantCulture),
            CounterCurrencyVolume = decimal.Parse(offerInfo.Volume, CultureInfo.InvariantCulture),
            Id = offerInfo.Id,
            IsMyOffer = offerInfo.IsMyOffer,
            IsPrivateOffer = offerInfo.IsPrivateOffer,
            MakerFeePercent = offerInfo.MakerFeePct,
            MarketPriceMarginPercent = offerInfo.MarketPriceMarginPct,
            Challenge = offerInfo.Challenge,
            PaymentMethodId = Enum.Parse<PaymentMethodId>(offerInfo.PaymentMethodId),
            PaymentMethodShortName = offerInfo.PaymentMethodShortName,
            PenaltyFeePercent = offerInfo.PenaltyFeePct,
            Price = decimal.Parse(offerInfo.Price, CultureInfo.InvariantCulture),
            ProtocolVersion = offerInfo.ProtocolVersion,
            PubKeyRing = offerInfo.PubKeyRing,
            SellerSecurityDepositPercent = offerInfo.SellerSecurityDepositPct,
            SplitOutputTxFee = offerInfo.SplitOutputTxFee,
            SplitOutputTxHash = offerInfo.SplitOutputTxHash,
            State = Enum.Parse<OfferState>(offerInfo.State),
            MakerFeePercent = (decimal)offerInfo.MakerFeePct,
            TakerFeePercent = (decimal)offerInfo.TakerFeePct,
            TriggerPrice = decimal.Parse(offerInfo.TriggerPrice, CultureInfo.InvariantCulture),
            UseMarketBasedPrice = offerInfo.UseMarketBasedPrice,
            VersionNr = offerInfo.VersionNr,
            AcceptedCountriesString = offerInfo.AcceptedCountriesString,
            AcceptedCountryCodes = offerInfo.AcceptedCountryCodes,
            City = offerInfo.City
        };
    }

    public static CryptoCurrency Convert(this Proto.Models.CryptoCurrency cryptoCurrency)
    {
        return new CryptoCurrency
        {
            IsAsset = cryptoCurrency.IsAsset,
        };
    }

    public static TraditionalCurrency Convert(this Proto.Models.TraditionalCurrency traditionalCurrency)
    {
        return new TraditionalCurrency
        {

        };
    }

    public static TradeCurrency Convert(this Proto.Models.TradeCurrency tradeCurrency)
    {
        return new TradeCurrency
        {
            Code = tradeCurrency.Code,
            Name = tradeCurrency.Name,
            CryptoCurrency = tradeCurrency.CryptoCurrency?.Convert(),
            TraditionalCurrency = tradeCurrency.TraditionalCurrency?.Convert()
        };
    }

    public static PaymentMethod Convert(this Proto.Models.PaymentMethod paymentMethod)
    {
        return new PaymentMethod
        {
            Id = Enum.Parse<PaymentMethodId>(paymentMethod.Id),
            SupportedAssetCodes = paymentMethod.SupportedAssetCodes,
            MaxTradePeriod = TimeSpan.FromMilliseconds(paymentMethod.MaxTradePeriod),
            MaxTradeLimit = checked((ulong)paymentMethod.MaxTradeLimit)
        };
    }

    public static AdvancedCashAccountPayload Convert(this Proto.Models.AdvancedCashAccountPayload advancedCashAccountPayload)
    {
        return new AdvancedCashAccountPayload
        {
            AccountNr = advancedCashAccountPayload.AccountNr
        };
    }

    public static AliPayAccountPayload Convert(this Proto.Models.AliPayAccountPayload aliPayAccountPayload)
    {
        return new AliPayAccountPayload
        {
            AccountNr = aliPayAccountPayload.AccountNr
        };
    }

    public static AmazonGiftCardAccountPayload Convert(this Proto.Models.AmazonGiftCardAccountPayload amazonGiftCardAccountPayload)
    {
        return new AmazonGiftCardAccountPayload
        {
            CountryCode = amazonGiftCardAccountPayload.CountryCode,
            EmailOrMobileNr = amazonGiftCardAccountPayload.EmailOrMobileNr
        };
    }

    public static AustraliaPayidPayload Convert(this Proto.Models.AustraliaPayidPayload australiaPayidPayload)
    {
        return new AustraliaPayidPayload
        {
            BankAccountName = australiaPayidPayload.BankAccountName,
            ExtraInfo = australiaPayidPayload.ExtraInfo,
            PayId = australiaPayidPayload.PayId
        };
    }

    public static CapitualAccountPayload Convert(this Proto.Models.CapitualAccountPayload capitualAccountPayload)
    {
        return new CapitualAccountPayload
        {
            AccountNr = capitualAccountPayload.AccountNr
        };
    }

    public static CashAppAccountPayload Convert(this Proto.Models.CashAppAccountPayload cashAppAccountPayload)
    {
        return new CashAppAccountPayload
        {
            EmailOrMobileNrOrCashtag = cashAppAccountPayload.EmailOrMobileNrOrCashtag,
            ExtraInfo = cashAppAccountPayload.ExtraInfo
        };
    }

    public static CashAtAtmAccountPayload Convert(this Proto.Models.CashAtAtmAccountPayload cashAtAtmAccountPayload)
    {
        return new CashAtAtmAccountPayload
        {
            ExtraInfo = cashAtAtmAccountPayload.ExtraInfo
        };
    }

    public static CelPayAccountPayload Convert(this Proto.Models.CelPayAccountPayload celPayAccountPayload)
    {
        return new CelPayAccountPayload
        {
            Email = celPayAccountPayload.Email,
        };
    }

    public static ChaseQuickPayAccountPayload Convert(this Proto.Models.ChaseQuickPayAccountPayload chaseQuickPayAccountPayload)
    {
        return new ChaseQuickPayAccountPayload
        {
            Email = chaseQuickPayAccountPayload.Email,
            HolderName = chaseQuickPayAccountPayload.HolderName
        };
    }

    public static CountryBasedPaymentAccountPayload Convert(this Proto.Models.CountryBasedPaymentAccountPayload countryBasedPaymentAccountPayload)
    {
        var newCountryBasedPaymentAccountPayload = new CountryBasedPaymentAccountPayload
        {
            AcceptedCountryCodes = countryBasedPaymentAccountPayload.AcceptedCountryCodes,
            CountryCode = countryBasedPaymentAccountPayload.CountryCode
        };

        if (countryBasedPaymentAccountPayload.BankAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.BankAccountPayload = new BankAccountPayload
            {
                HolderName = countryBasedPaymentAccountPayload.BankAccountPayload.HolderName,
                BankName = countryBasedPaymentAccountPayload.BankAccountPayload.BankName,
                BankId = countryBasedPaymentAccountPayload.BankAccountPayload.BankId,
                BranchId = countryBasedPaymentAccountPayload.BankAccountPayload.BranchId,
                AccountNr = countryBasedPaymentAccountPayload.BankAccountPayload.AccountNr,
                AccountType = countryBasedPaymentAccountPayload.BankAccountPayload.AccountType,
                HolderTaxId = countryBasedPaymentAccountPayload.BankAccountPayload.HolderTaxId,
                NationalAccountId = countryBasedPaymentAccountPayload.BankAccountPayload.NationalAccountId
            };

            if (countryBasedPaymentAccountPayload.BankAccountPayload.NationalBankAccountPayload is not null)
            {
                newCountryBasedPaymentAccountPayload.BankAccountPayload.NationalBankAccountPayload = new NationalBankAccountPayload
                {

                };
            }
            else if (countryBasedPaymentAccountPayload.BankAccountPayload.SameBankAccontPayload is not null)
            {
                newCountryBasedPaymentAccountPayload.BankAccountPayload.SameBankAccountPayload = new SameBankAccountPayload
                {

                };
            }
            else if (countryBasedPaymentAccountPayload.BankAccountPayload.SpecificBanksAccountPayload is not null)
            {
                newCountryBasedPaymentAccountPayload.BankAccountPayload.SpecificBanksAccountPayload = new SpecificBanksAccountPayload
                {
                    AcceptedBanks = countryBasedPaymentAccountPayload.BankAccountPayload.SpecificBanksAccountPayload.AcceptedBanks
                };
            }
            else if (countryBasedPaymentAccountPayload.BankAccountPayload.AchTransferAccountPayload is not null)
            {
                newCountryBasedPaymentAccountPayload.BankAccountPayload.AchTransferAccountPayload = new AchTransferAccountPayload
                {
                    HolderAddress = countryBasedPaymentAccountPayload.BankAccountPayload.AchTransferAccountPayload.HolderAddress
                };
            }
            else if (countryBasedPaymentAccountPayload.BankAccountPayload.DomesticWireTransferAccountPayload is not null)
            {
                newCountryBasedPaymentAccountPayload.BankAccountPayload.DomesticWireTransferAccountPayload = new DomesticWireTransferAccountPayload
                {
                    HolderAddress = countryBasedPaymentAccountPayload.BankAccountPayload.DomesticWireTransferAccountPayload.HolderAddress
                };
            }
        }
        else if (countryBasedPaymentAccountPayload.CashDepositAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.CashDepositAccountPayload = new CashDepositAccountPayload
            {
                HolderName = countryBasedPaymentAccountPayload.CashDepositAccountPayload.HolderName,
                BankName = countryBasedPaymentAccountPayload.CashDepositAccountPayload.BankName,
                BankId = countryBasedPaymentAccountPayload.CashDepositAccountPayload.BankId,
                BranchId = countryBasedPaymentAccountPayload.CashDepositAccountPayload.BranchId,
                AccountNr = countryBasedPaymentAccountPayload.CashDepositAccountPayload.AccountNr,
                AccountType = countryBasedPaymentAccountPayload.CashDepositAccountPayload.AccountType,
                HolderTaxId = countryBasedPaymentAccountPayload.CashDepositAccountPayload.HolderTaxId,
                NationalAccountId = countryBasedPaymentAccountPayload.CashDepositAccountPayload.NationalAccountId,
                HolderEmail = countryBasedPaymentAccountPayload.CashDepositAccountPayload.HolderEmail,
                Requirements = countryBasedPaymentAccountPayload.CashDepositAccountPayload.Requirements
            };
        }
        else if (countryBasedPaymentAccountPayload.SepaAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.SepaAccountPayload = new SepaAccountPayload
            {
                Bic = countryBasedPaymentAccountPayload.SepaAccountPayload.Bic,
                HolderName = countryBasedPaymentAccountPayload.SepaAccountPayload.HolderName,
                Iban = countryBasedPaymentAccountPayload.SepaAccountPayload.Iban
            };
        }
        else if (countryBasedPaymentAccountPayload.WesternUnionAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.WesternUnionAccountPayload = new WesternUnionAccountPayload
            {
                City = countryBasedPaymentAccountPayload.WesternUnionAccountPayload.City,
                Email = countryBasedPaymentAccountPayload.WesternUnionAccountPayload.Email,
                HolderName = countryBasedPaymentAccountPayload.WesternUnionAccountPayload.HolderName,
                State = countryBasedPaymentAccountPayload.WesternUnionAccountPayload.State
            };
        }
        else if (countryBasedPaymentAccountPayload.SepaInstantAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.SepaInstantAccountPayload = new SepaInstantAccountPayload
            {
                Bic = countryBasedPaymentAccountPayload.SepaInstantAccountPayload.Bic,
                HolderName = countryBasedPaymentAccountPayload.SepaInstantAccountPayload.HolderName,
                Iban = countryBasedPaymentAccountPayload.SepaInstantAccountPayload.Iban
            };
        }
        else if (countryBasedPaymentAccountPayload.F2FAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.F2FAccountPayload = new F2FAccountPayload
            {
                City = countryBasedPaymentAccountPayload.F2FAccountPayload.City,
                Contact = countryBasedPaymentAccountPayload.F2FAccountPayload.Contact,
                ExtraInfo = countryBasedPaymentAccountPayload.F2FAccountPayload.ExtraInfo
            };
        }
        else if (countryBasedPaymentAccountPayload.UpiAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.UpiAccountPayload = new UpiAccountPayload
            {
                VirtualPaymentAddress = countryBasedPaymentAccountPayload.UpiAccountPayload.VirtualPaymentAddress
            };
        }
        else if (countryBasedPaymentAccountPayload.PaytmAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.PaytmAccountPayload = new PaytmAccountPayload
            {
                EmailOrMobileNr = countryBasedPaymentAccountPayload.PaytmAccountPayload.EmailOrMobileNr
            };
        }
        else if (countryBasedPaymentAccountPayload.IfscBasedAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.IfscBasedAccountPayload = new IfscBasedAccountPayload
            {
                AccountNr = countryBasedPaymentAccountPayload.IfscBasedAccountPayload.AccountNr,
                HolderName = countryBasedPaymentAccountPayload.IfscBasedAccountPayload.HolderName,
                Ifsc = countryBasedPaymentAccountPayload.IfscBasedAccountPayload.Ifsc,
                Payload = countryBasedPaymentAccountPayload.IfscBasedAccountPayload.Payload
            };
        }
        else if (countryBasedPaymentAccountPayload.NequiAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.NequiAccountPayload = new NequiAccountPayload
            {
                MobileNr = countryBasedPaymentAccountPayload.NequiAccountPayload.MobileNr
            };
        }
        else if (countryBasedPaymentAccountPayload.BizumAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.BizumAccountPayload = new BizumAccountPayload
            {
                MobileNr = countryBasedPaymentAccountPayload.BizumAccountPayload.MobileNr
            };
        }
        else if (countryBasedPaymentAccountPayload.PixAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.PixAccountPayload = new PixAccountPayload
            {
                PixKey = countryBasedPaymentAccountPayload.PixAccountPayload.PixKey,
                HolderName = countryBasedPaymentAccountPayload.PixAccountPayload.HolderName,
            };
        }
        else if (countryBasedPaymentAccountPayload.SatispayAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.SatispayAccountPayload = new SatispayAccountPayload
            {
                HolderName = countryBasedPaymentAccountPayload.SatispayAccountPayload.HolderName,
                MobileNr = countryBasedPaymentAccountPayload.SatispayAccountPayload.MobileNr
            };
        }
        else if (countryBasedPaymentAccountPayload.StrikeAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.StrikeAccountPayload = new StrikeAccountPayload
            {
                HolderName = countryBasedPaymentAccountPayload.StrikeAccountPayload.HolderName
            };
        }
        else if (countryBasedPaymentAccountPayload.TikkieAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.TikkieAccountPayload = new TikkieAccountPayload
            {
                Iban = countryBasedPaymentAccountPayload.TikkieAccountPayload.Iban
            };
        }
        else if (countryBasedPaymentAccountPayload.TransferwiseUsdAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.TransferwiseUsdAccountPayload = new TransferwiseUsdAccountPayload
            {
                HolderAddress = countryBasedPaymentAccountPayload.TransferwiseUsdAccountPayload.HolderAddress,
                Email = countryBasedPaymentAccountPayload.TransferwiseUsdAccountPayload.Email,
                HolderName = countryBasedPaymentAccountPayload.TransferwiseUsdAccountPayload.HolderName
            };
        }
        else if (countryBasedPaymentAccountPayload.SwiftAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.SwiftAccountPayload = countryBasedPaymentAccountPayload.SwiftAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.MpesaAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.MpesaAccountPayload = countryBasedPaymentAccountPayload.MpesaAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.MercadoPagoAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.MercadoPagoAccountPayload = countryBasedPaymentAccountPayload.MercadoPagoAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.GcashAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.GcashAccountPayload = countryBasedPaymentAccountPayload.GcashAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.MomoAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.MomoAccountPayload = countryBasedPaymentAccountPayload.MomoAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.SpeiAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.SpeiAccountPayload = countryBasedPaymentAccountPayload.SpeiAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.BlikAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.BlikAccountPayload = countryBasedPaymentAccountPayload.BlikAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.VippsMobilePayAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.VippsMobilePayAccountPayload = countryBasedPaymentAccountPayload.VippsMobilePayAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.SbpAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.SbpAccountPayload = countryBasedPaymentAccountPayload.SbpAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.MirAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.MirAccountPayload = countryBasedPaymentAccountPayload.MirAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.YooMoneyAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.YooMoneyAccountPayload = countryBasedPaymentAccountPayload.YooMoneyAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.UkraineCardAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.UkraineCardAccountPayload = countryBasedPaymentAccountPayload.UkraineCardAccountPayload.Convert();
        }
        else if (countryBasedPaymentAccountPayload.KaspiAccountPayload is not null)
        {
            newCountryBasedPaymentAccountPayload.KaspiAccountPayload = countryBasedPaymentAccountPayload.KaspiAccountPayload.Convert();
        }

        return newCountryBasedPaymentAccountPayload;
    }

    public static CryptoCurrencyAccountPayload Convert(this Proto.Models.CryptoCurrencyAccountPayload cryptoCurrencyAccountPayload)
    {
        return new CryptoCurrencyAccountPayload
        {
            Address = cryptoCurrencyAccountPayload.Address
        };
    }

    public static HalCashAccountPayload Convert(this Proto.Models.HalCashAccountPayload halCashAccountPayload)
    {
        return new HalCashAccountPayload
        {
            MobileNr = halCashAccountPayload.MobileNr
        };
    }

    public static InstantCryptoCurrencyAccountPayload Convert(this Proto.Models.InstantCryptoCurrencyAccountPayload cryptoCurrencyAccountPayload)
    {
        return new InstantCryptoCurrencyAccountPayload
        {
            Address = cryptoCurrencyAccountPayload.Address
        };
    }

    public static WeChatPayAccountPayload Convert(this Proto.Models.WeChatPayAccountPayload weChatPayAccountPayload)
    {
        return new WeChatPayAccountPayload
        {
            AccountNr = weChatPayAccountPayload.AccountNr
        };
    }

    public static FasterPaymentsAccountPayload Convert(this Proto.Models.FasterPaymentsAccountPayload fasterPaymentsAccountPayload)
    {
        return new FasterPaymentsAccountPayload
        {
            AccountNr = fasterPaymentsAccountPayload.AccountNr,
            HolderName = fasterPaymentsAccountPayload.HolderName,
            SortCode = fasterPaymentsAccountPayload.SortCode
        };
    }

    public static InteracETransferAccountPayload Convert(this Proto.Models.InteracETransferAccountPayload interacETransferAccountPayload)
    {
        return new InteracETransferAccountPayload
        {
            Answer = interacETransferAccountPayload.Answer,
            EmailOrMobileNr = interacETransferAccountPayload.EmailOrMobileNr,
            HolderName = interacETransferAccountPayload.HolderName,
            Question = interacETransferAccountPayload.Question
        };
    }

    public static JapanBankAccountPayload Convert(this Proto.Models.JapanBankAccountPayload japanBankAccountPayload)
    {
        return new JapanBankAccountPayload
        {
            BankName = japanBankAccountPayload.BankName,
            BankAccountName = japanBankAccountPayload.BankAccountName,
            BankAccountNumber = japanBankAccountPayload.BankAccountNumber,
            BankAccountType = japanBankAccountPayload.BankAccountType,
            BankBranchCode = japanBankAccountPayload.BankBranchCode,
            BankBranchName = japanBankAccountPayload.BankBranchName,
            BankCode = japanBankAccountPayload.BankCode
        };
    }

    public static MoneseAccountPayload Convert(this Proto.Models.MoneseAccountPayload moneseAccountPayload)
    {
        return new MoneseAccountPayload
        {
            HolderName = moneseAccountPayload.HolderName,
            MobileNr = moneseAccountPayload.MobileNr
        };
    }

    public static MoneyBeamAccountPayload Convert(this Proto.Models.MoneyBeamAccountPayload moneyBeamAccountPayload)
    {
        return new MoneyBeamAccountPayload
        {
            AccountId = moneyBeamAccountPayload.AccountId,
            HolderName = moneyBeamAccountPayload.HolderName
        };
    }

    public static MoneyGramAccountPayload Convert(this Proto.Models.MoneyGramAccountPayload moneyGramAccountPayload)
    {
        return new MoneyGramAccountPayload
        {
            CountryCode = moneyGramAccountPayload.CountryCode,
            Email = moneyGramAccountPayload.Email,
            HolderName = moneyGramAccountPayload.HolderName,
            State = moneyGramAccountPayload.State
        };
    }

    public static PaxumAccountPayload Convert(this Proto.Models.PaxumAccountPayload paxumAccountPayload)
    {
        return new PaxumAccountPayload
        {
            Email = paxumAccountPayload.Email
        };
    }

    public static PayByMailAccountPayload Convert(this Proto.Models.PayByMailAccountPayload payByMailAccountPayload)
    {
        return new PayByMailAccountPayload
        {
            PostalAddress = payByMailAccountPayload.PostalAddress,
            Contact = payByMailAccountPayload.Contact,
            ExtraInfo = payByMailAccountPayload.ExtraInfo
        };
    }

    public static PayPalAccountPayload Convert(this Proto.Models.PayPalAccountPayload payPalAccountPayload)
    {
        return new PayPalAccountPayload
        {
            EmailOrMobileNrOrUsername = payPalAccountPayload.EmailOrMobileNrOrUsername,
            ExtraInfo = payPalAccountPayload.ExtraInfo
        };
    }

    public static PaysafeAccountPayload Convert(this Proto.Models.PaysafeAccountPayload paysafeAccountPayload)
    {
        return new PaysafeAccountPayload
        {
            Email = paysafeAccountPayload.Email
        };
    }

    public static PayseraAccountPayload Convert(this Proto.Models.PayseraAccountPayload payseraAccountPayload)
    {
        return new PayseraAccountPayload
        {
            Email = payseraAccountPayload.Email
        };
    }

    public static PerfectMoneyAccountPayload Convert(this Proto.Models.PerfectMoneyAccountPayload perfectMoneyAccountPayload)
    {
        return new PerfectMoneyAccountPayload
        {
            AccountNr = perfectMoneyAccountPayload.AccountNr
        };
    }

    public static PopmoneyAccountPayload Convert(this Proto.Models.PopmoneyAccountPayload popmoneyAccountPayload)
    {
        return new PopmoneyAccountPayload
        {
            AccountId = popmoneyAccountPayload.AccountId,
            HolderName = popmoneyAccountPayload.HolderName
        };
    }

    public static PromptPayAccountPayload Convert(this Proto.Models.PromptPayAccountPayload promptPayAccountPayload)
    {
        return new PromptPayAccountPayload
        {
            PromptPayId = promptPayAccountPayload.PromptPayId
        };
    }

    public static RevolutAccountPayload Convert(this Proto.Models.RevolutAccountPayload revolutAccountPayload)
    {
        return new RevolutAccountPayload
        {
            Username = revolutAccountPayload.Username
        };
    }

    public static SwiftAccountPayload Convert(this Proto.Models.SwiftAccountPayload swiftAccountPayload)
    {
        return new SwiftAccountPayload
        {
            BankAddress = swiftAccountPayload.BankAddress,
            BeneficiaryAccountNr = swiftAccountPayload.BeneficiaryAccountNr,
            BeneficiaryAddress = swiftAccountPayload.BeneficiaryAddress,
            IntermediaryAddress = swiftAccountPayload.IntermediaryAddress,
            BankBranch = swiftAccountPayload.BankBranch,
            BankCountryCode = swiftAccountPayload.BankCountryCode,
            BankName = swiftAccountPayload.BankName,
            BankSwiftCode = swiftAccountPayload.BankSwiftCode,
            BeneficiaryCity = swiftAccountPayload.BeneficiaryCity,
            BeneficiaryName = swiftAccountPayload.BeneficiaryName,
            BeneficiaryPhone = swiftAccountPayload.BeneficiaryPhone,
            IntermediaryBranch = swiftAccountPayload.IntermediaryBranch,
            IntermediaryCountryCode = swiftAccountPayload.IntermediaryCountryCode,
            IntermediaryName = swiftAccountPayload.IntermediaryName,
            IntermediarySwiftCode = swiftAccountPayload.IntermediarySwiftCode,
            SpecialInstructions = swiftAccountPayload.SpecialInstructions
        };
    }

    public static SwishAccountPayload Convert(this Proto.Models.SwishAccountPayload swishAccountPayload)
    {
        return new SwishAccountPayload
        {
            HolderName = swishAccountPayload.HolderName,
            MobileNr = swishAccountPayload.MobileNr
        };
    }

    public static TransferwiseAccountPayload Convert(this Proto.Models.TransferwiseAccountPayload transferwiseAccountPayload)
    {
        return new TransferwiseAccountPayload
        {
            Email = transferwiseAccountPayload.Email,
            HolderName = transferwiseAccountPayload.HolderName
        };
    }

    public static UpholdAccountPayload Convert(this Proto.Models.UpholdAccountPayload upholdAccountPayload)
    {
        return new UpholdAccountPayload
        {
            AccountId = upholdAccountPayload.AccountId,
            AccountOwner = upholdAccountPayload.AccountOwner
        };
    }

    public static USPostalMoneyOrderAccountPayload Convert(this Proto.Models.USPostalMoneyOrderAccountPayload uSPostalMoneyOrderAccountPayload)
    {
        return new USPostalMoneyOrderAccountPayload
        {
            PostalAddress = uSPostalMoneyOrderAccountPayload.PostalAddress,
            HolderName = uSPostalMoneyOrderAccountPayload.HolderName
        };
    }

    public static VenmoAccountPayload Convert(this Proto.Models.VenmoAccountPayload venmoAccountPayload)
    {
        return new VenmoAccountPayload
        {
            EmailOrMobileNrOrUsername = venmoAccountPayload.EmailOrMobileNrOrUsername
        };
    }

    public static VerseAccountPayload Convert(this Proto.Models.VerseAccountPayload verseAccountPayload)
    {
        return new VerseAccountPayload
        {
            HolderName = verseAccountPayload.HolderName
        };
    }

    public static ZelleAccountPayload Convert(this Proto.Models.ZelleAccountPayload zelleAccountPayload)
    {
        return new ZelleAccountPayload
        {
            EmailOrMobileNr = zelleAccountPayload.EmailOrMobileNr,
            HolderName = zelleAccountPayload.HolderName
        };
    }

    public static MpesaAccountPayload Convert(this Proto.Models.MpesaAccountPayload mpesaAccountPayload)
    {
        return new MpesaAccountPayload
        {
            MobileNr = mpesaAccountPayload.MobileNr,
            HolderName = mpesaAccountPayload.HolderName
        };
    }

    public static MercadoPagoAccountPayload Convert(this Proto.Models.MercadoPagoAccountPayload mercadoPagoAccountPayload)
    {
        return new MercadoPagoAccountPayload
        {
            EmailOrMobileNr = mercadoPagoAccountPayload.EmailOrMobileNr,
            HolderName = mercadoPagoAccountPayload.HolderName
        };
    }

    public static GcashAccountPayload Convert(this Proto.Models.GcashAccountPayload gcashAccountPayload)
    {
        return new GcashAccountPayload
        {
            MobileNr = gcashAccountPayload.MobileNr,
            HolderName = gcashAccountPayload.HolderName
        };
    }

    public static MomoAccountPayload Convert(this Proto.Models.MomoAccountPayload momoAccountPayload)
    {
        return new MomoAccountPayload
        {
            MobileNr = momoAccountPayload.MobileNr,
            HolderName = momoAccountPayload.HolderName
        };
    }

    public static SpeiAccountPayload Convert(this Proto.Models.SpeiAccountPayload speiAccountPayload)
    {
        return new SpeiAccountPayload
        {
            Clabe = speiAccountPayload.Clabe,
            HolderName = speiAccountPayload.HolderName
        };
    }

    public static BlikAccountPayload Convert(this Proto.Models.BlikAccountPayload blikAccountPayload)
    {
        return new BlikAccountPayload
        {
            ExtraInfo = blikAccountPayload.ExtraInfo,
        };
    }

    public static VippsMobilePayAccountPayload Convert(this Proto.Models.VippsMobilePayAccountPayload vippsMobilePayAccountPayload)
    {
        return new VippsMobilePayAccountPayload
        {
            MobileNr = vippsMobilePayAccountPayload.MobileNr,
            HolderName = vippsMobilePayAccountPayload.HolderName
        };
    }

    public static TwintAccountPayload Convert(this Proto.Models.TwintAccountPayload twintAccountPayload)
    {
        return new TwintAccountPayload
        {
            MobileNr = twintAccountPayload.MobileNr,
            HolderName = twintAccountPayload.HolderName
        };
    }

    public static NipAccountPayload Convert(this Proto.Models.NipAccountPayload nipAccountPayload)
    {
        return new NipAccountPayload
        {
            AccountNr = nipAccountPayload.AccountNr,
            BankName = nipAccountPayload.BankName,
            HolderName = nipAccountPayload.HolderName
        };
    }

    public static PagoMovilAccountPayload Convert(this Proto.Models.PagoMovilAccountPayload pagoMovilAccountPayload)
    {
        return new PagoMovilAccountPayload
        {
            HolderName = pagoMovilAccountPayload.HolderName,
            BankName = pagoMovilAccountPayload.BankName,
            HolderTaxId = pagoMovilAccountPayload.HolderTaxId,
            MobileNr = pagoMovilAccountPayload.MobileNr
        };
    }

    public static QrisAccountPayload Convert(this Proto.Models.QrisAccountPayload qrisAccountPayload)
    {
        return new QrisAccountPayload
        {
            AccountNr = qrisAccountPayload.AccountNr,
            BankName = qrisAccountPayload.BankName,
            HolderName = qrisAccountPayload.HolderName
        };
    }

    public static PaparaAccountPayload Convert(this Proto.Models.PaparaAccountPayload paparaAccountPayload)
    {
        return new PaparaAccountPayload
        {
            AccountNr = paparaAccountPayload.AccountNr,
            BankName = paparaAccountPayload.BankName,
            HolderName = paparaAccountPayload.HolderName
        };
    }

    public static RaastAccountPayload Convert(this Proto.Models.RaastAccountPayload raastAccountPayload)
    {
        return new RaastAccountPayload
        {
            AccountNr = raastAccountPayload.AccountNr,
            BankName = raastAccountPayload.BankName,
            HolderName = raastAccountPayload.HolderName
        };
    }

    public static WeroAccountPayload Convert(this Proto.Models.WeroAccountPayload weroAccountPayload)
    {
        return new WeroAccountPayload
        {
            MobileNr = weroAccountPayload.MobileNr,
            HolderName = weroAccountPayload.HolderName
        };
    }

    public static FpsAccountPayload Convert(this Proto.Models.FpsAccountPayload fpsAccountPayload)
    {
        return new FpsAccountPayload
        {
            AccountNr = fpsAccountPayload.AccountNr,
            BankName = fpsAccountPayload.BankName,
            HolderName = fpsAccountPayload.HolderName
        };
    }

    public static DuitNowAccountPayload Convert(this Proto.Models.DuitNowAccountPayload duitNowAccountPayload)
    {
        return new DuitNowAccountPayload
        {
            AccountNr = duitNowAccountPayload.AccountNr,
            BankName = duitNowAccountPayload.BankName,
            HolderName = duitNowAccountPayload.HolderName
        };
    }

    public static MbWayAccountPayload Convert(this Proto.Models.MbWayAccountPayload mbWayAccountPayload)
    {
        return new MbWayAccountPayload
        {
            MobileNr = mbWayAccountPayload.MobileNr,
            HolderName = mbWayAccountPayload.HolderName
        };
    }

    public static PayPayAccountPayload Convert(this Proto.Models.PayPayAccountPayload payPayAccountPayload)
    {
        return new PayPayAccountPayload
        {
            AccountNr = payPayAccountPayload.AccountNr,
            HolderName = payPayAccountPayload.HolderName
        };
    }

    public static SbpAccountPayload Convert(this Proto.Models.SbpAccountPayload sbpAccountPayload)
    {
        return new SbpAccountPayload
        {
            MobileNr = sbpAccountPayload.MobileNr,
            HolderName = sbpAccountPayload.HolderName
        };
    }

    public static MirAccountPayload Convert(this Proto.Models.MirAccountPayload mirAccountPayload)
    {
        return new MirAccountPayload
        {
            AccountNr = mirAccountPayload.AccountNr,
            HolderName = mirAccountPayload.HolderName
        };
    }

    public static YooMoneyAccountPayload Convert(this Proto.Models.YooMoneyAccountPayload yooMoneyAccountPayload)
    {
        return new YooMoneyAccountPayload
        {
            AccountNr = yooMoneyAccountPayload.AccountNr,
            HolderName = yooMoneyAccountPayload.HolderName
        };
    }

    public static UkraineCardAccountPayload Convert(this Proto.Models.UkraineCardAccountPayload ukraineCardAccountPayload)
    {
        return new UkraineCardAccountPayload
        {
            AccountNr = ukraineCardAccountPayload.AccountNr,
            HolderName = ukraineCardAccountPayload.HolderName
        };
    }

    public static KaspiAccountPayload Convert(this Proto.Models.KaspiAccountPayload kaspiAccountPayload)
    {
        return new KaspiAccountPayload
        {
            AccountNr = kaspiAccountPayload.AccountNr,
            HolderName = kaspiAccountPayload.HolderName
        };
    }

    public static PayNowAccountPayload Convert(this Proto.Models.PayNowAccountPayload payNowAccountPayload)
    {
        return new PayNowAccountPayload
        {
            AccountNr = payNowAccountPayload.AccountNr,
            BankName = payNowAccountPayload.BankName,
            HolderName = payNowAccountPayload.HolderName
        };
    }

    public static PaymentAccountPayload Convert(this Proto.Models.PaymentAccountPayload paymentAccountPayload)
    {
        if (paymentAccountPayload.PaymentMethodId == string.Empty)
        {

        }

        var newPaymentAccountPayload = new PaymentAccountPayload
        {
            Id = paymentAccountPayload.Id,
            MaxTradePeriod = TimeSpan.FromMilliseconds(paymentAccountPayload.MaxTradePeriod),
            PaymentMethodId = Enum.Parse<PaymentMethodId>(paymentAccountPayload.PaymentMethodId),

            //AdvancedCashAccountPayload = paymentAccountPayload.AdvancedCashAccountPayload?.Convert(),
            //AliPayAccountPayload = paymentAccountPayload.AliPayAccountPayload?.Convert(),
            //AmazonGiftCardAccountPayload = paymentAccountPayload.AmazonGiftCardAccountPayload?.Convert(),
            //AustraliaPayidPayload = paymentAccountPayload.AustraliaPayidPayload?.Convert(),
            //CapitualAccountPayload = paymentAccountPayload.CapitualAccountPayload?.Convert(),
            //CashAppAccountPayload = paymentAccountPayload.CashAppAccountPayload?.Convert(),
            //CashAtAtmAccountPayload = paymentAccountPayload.CashAtAtmAccountPayload?.Convert(),
            //CelPayAccountPayload = paymentAccountPayload.CelPayAccountPayload?.Convert(),
            //ChaseQuickPayAccountPayload = paymentAccountPayload.ChaseQuickPayAccountPayload?.Convert(),
            //CountryBasedPaymentAccountPayload = paymentAccountPayload.CountryBasedPaymentAccountPayload?.Convert(),
            //CryptoCurrencyAccountPayload = paymentAccountPayload.CryptoCurrencyAccountPayload?.Convert(),
            //InstantCryptoCurrencyAccountPayload = paymentAccountPayload.InstantCryptoCurrencyAccountPayload?.Convert(),
            //HalCashAccountPayload = paymentAccountPayload.HalCashAccountPayload?.Convert(),
            //WeChatPayAccountPayload = paymentAccountPayload.WeChatPayAccountPayload?.Convert(),
            //FasterPaymentsAccountPayload = paymentAccountPayload.FasterPaymentsAccountPayload?.Convert(),
            //InteracETransferAccountPayload = paymentAccountPayload.InteracETransferAccountPayload?.Convert(),
            //JapanBankAccountPayload = paymentAccountPayload.JapanBankAccountPayload?.Convert(),
            //MoneseAccountPayload = paymentAccountPayload.MoneseAccountPayload?.Convert(),
            //MoneyBeamAccountPayload = paymentAccountPayload.MoneyBeamAccountPayload?.Convert(),
            //MoneyGramAccountPayload = paymentAccountPayload.MoneyGramAccountPayload?.Convert(),
            //PaxumAccountPayload = paymentAccountPayload.PaxumAccountPayload?.Convert(),
            //PayByMailAccountPayload = paymentAccountPayload.PayByMailAccountPayload?.Convert(),
            //PayPalAccountPayload = paymentAccountPayload.PayPalAccountPayload?.Convert(),
            //PaysafeAccountPayload = paymentAccountPayload.PaysafeAccountPayload?.Convert(),
            //PayseraAccountPayload = paymentAccountPayload.PayseraAccountPayload?.Convert(),
            //PerfectMoneyAccountPayload = paymentAccountPayload.PerfectMoneyAccountPayload?.Convert(),
            //PopmoneyAccountPayload = paymentAccountPayload.PopmoneyAccountPayload?.Convert(),
            //PromptPayAccountPayload = paymentAccountPayload.PromptPayAccountPayload?.Convert(),
            //RevolutAccountPayload = paymentAccountPayload.RevolutAccountPayload?.Convert(),
            //// Bugged
            //SwiftAccountPayload = paymentAccountPayload.SwiftAccountPayload?.Convert(),
            //SwishAccountPayload = paymentAccountPayload.SwishAccountPayload?.Convert(),
            //TransferwiseAccountPayload = paymentAccountPayload.TransferwiseAccountPayload?.Convert(),
            //UpholdAccountPayload = paymentAccountPayload.UpholdAccountPayload?.Convert(),
            //USPostalMoneyOrderAccountPayload = paymentAccountPayload.USPostalMoneyOrderAccountPayload?.Convert(),
            //VenmoAccountPayload = paymentAccountPayload.VenmoAccountPayload?.Convert(),
            //VerseAccountPayload = paymentAccountPayload.VerseAccountPayload?.Convert(),
            //ZelleAccountPayload = paymentAccountPayload.ZelleAccountPayload?.Convert(),
            //DuitNowAccountPayload = paymentAccountPayload.DuitNowAccountPayload?.Convert(),
            //FpsAccountPayload = paymentAccountPayload.FpsAccountPayload?.Convert(),
            //MbWayAccountPayload = paymentAccountPayload.MbWayAccountPayload?.Convert(),
            //NipAccountPayload = paymentAccountPayload.NipAccountPayload?.Convert(),
            //PagoMovilAccountPayload = paymentAccountPayload.PagoMovilAccountPayload?.Convert(),
            //PaparaAccountPayload = paymentAccountPayload.PaparaAccountPayload?.Convert(),
            //PayNowAccountPayload = paymentAccountPayload.PayNowAccountPayload?.Convert(),
            //PayPayAccountPayload = paymentAccountPayload.PayPayAccountPayload?.Convert(),
            //QrisAccountPayload = paymentAccountPayload.QrisAccountPayload?.Convert(),
            //RaastAccountPayload = paymentAccountPayload.RaastAccountPayload?.Convert(),
            //TwintAccountPayload = paymentAccountPayload.TwintAccountPayload?.Convert(),
            //WeroAccountPayload = paymentAccountPayload.WeroAccountPayload?.Convert(),
            ExcludeFromJsonData = paymentAccountPayload.ExcludeFromJsonData
        };

        switch (newPaymentAccountPayload.PaymentMethodId)
        {
            case PaymentMethodId.HAL_CASH:
                newPaymentAccountPayload.HalCashAccountPayload = paymentAccountPayload.HalCashAccountPayload?.Convert();
                break;
            case PaymentMethodId.NATIONAL_BANK:
            case PaymentMethodId.SAME_BANK:
            case PaymentMethodId.SPECIFIC_BANKS:
            case PaymentMethodId.ACH_TRANSFER:
            case PaymentMethodId.DOMESTIC_WIRE_TRANSFER:
            case PaymentMethodId.CASH_DEPOSIT:
            case PaymentMethodId.SEPA:
            case PaymentMethodId.WESTERN_UNION:
            case PaymentMethodId.SEPA_INSTANT:
            case PaymentMethodId.F2F:
            case PaymentMethodId.UPI:
            case PaymentMethodId.PAYTM:
            case PaymentMethodId.NEFT:
            case PaymentMethodId.RTGS:
            case PaymentMethodId.IMPS:
            case PaymentMethodId.NEQUI:
            case PaymentMethodId.BIZUM:
            case PaymentMethodId.PIX:
            case PaymentMethodId.SATISPAY:
            case PaymentMethodId.STRIKE:
            case PaymentMethodId.TIKKIE:
            case PaymentMethodId.TRANSFERWISE_USD:
            case PaymentMethodId.MPESA:
            case PaymentMethodId.MERCADO_PAGO:
            case PaymentMethodId.GCASH:
            case PaymentMethodId.MOMO:
            case PaymentMethodId.SPEI:
            case PaymentMethodId.BLIK:
            case PaymentMethodId.VIPPS_MOBILEPAY:
            case PaymentMethodId.SBP:
            case PaymentMethodId.MIR:
            case PaymentMethodId.YOOMONEY:
            case PaymentMethodId.UKRAINE_CARD:
            case PaymentMethodId.KASPI:
                newPaymentAccountPayload.CountryBasedPaymentAccountPayload = paymentAccountPayload.CountryBasedPaymentAccountPayload?.Convert();
                break;
            case PaymentMethodId.SWIFT:
                // Bugged
                newPaymentAccountPayload.SwiftAccountPayload = paymentAccountPayload.SwiftAccountPayload?.Convert();
                break;
            case PaymentMethodId.DUITNOW:
                newPaymentAccountPayload.DuitNowAccountPayload = paymentAccountPayload.DuitNowAccountPayload?.Convert();
                break;
            case PaymentMethodId.FPS:
                newPaymentAccountPayload.FpsAccountPayload = paymentAccountPayload.FpsAccountPayload?.Convert();
                break;
            case PaymentMethodId.MB_WAY:
                newPaymentAccountPayload.MbWayAccountPayload = paymentAccountPayload.MbWayAccountPayload?.Convert();
                break;
            case PaymentMethodId.NIP:
                newPaymentAccountPayload.NipAccountPayload = paymentAccountPayload.NipAccountPayload?.Convert();
                break;
            case PaymentMethodId.PAPARA:
                newPaymentAccountPayload.PaparaAccountPayload = paymentAccountPayload.PaparaAccountPayload?.Convert();
                break;
            case PaymentMethodId.PAYNOW:
                newPaymentAccountPayload.PayNowAccountPayload = paymentAccountPayload.PayNowAccountPayload?.Convert();
                break;
            case PaymentMethodId.PAYPAY:
                newPaymentAccountPayload.PayPayAccountPayload = paymentAccountPayload.PayPayAccountPayload?.Convert();
                break;
            case PaymentMethodId.QRIS:
                newPaymentAccountPayload.QrisAccountPayload = paymentAccountPayload.QrisAccountPayload?.Convert();
                break;
            case PaymentMethodId.RAAST:
                newPaymentAccountPayload.RaastAccountPayload = paymentAccountPayload.RaastAccountPayload?.Convert();
                break;
            case PaymentMethodId.TWINT:
                newPaymentAccountPayload.TwintAccountPayload = paymentAccountPayload.TwintAccountPayload?.Convert();
                break;
            case PaymentMethodId.WERO:
                newPaymentAccountPayload.WeroAccountPayload = paymentAccountPayload.WeroAccountPayload?.Convert();
                break;
            case PaymentMethodId.MONEY_BEAM:
                newPaymentAccountPayload.MoneyBeamAccountPayload = paymentAccountPayload.MoneyBeamAccountPayload?.Convert();
                break;
            case PaymentMethodId.FASTER_PAYMENTS:
                newPaymentAccountPayload.FasterPaymentsAccountPayload = paymentAccountPayload.FasterPaymentsAccountPayload?.Convert();
                break;
            case PaymentMethodId.SWISH:
                newPaymentAccountPayload.SwishAccountPayload = paymentAccountPayload.SwishAccountPayload?.Convert();
                break;
            case PaymentMethodId.ZELLE:
                newPaymentAccountPayload.ZelleAccountPayload = paymentAccountPayload.ZelleAccountPayload?.Convert();
                break;
            case PaymentMethodId.POPMONEY:
                newPaymentAccountPayload.PopmoneyAccountPayload = paymentAccountPayload.PopmoneyAccountPayload?.Convert();
                break;
            case PaymentMethodId.US_POSTAL_MONEY_ORDER:
                newPaymentAccountPayload.USPostalMoneyOrderAccountPayload = paymentAccountPayload.USPostalMoneyOrderAccountPayload?.Convert();
                break;
            case PaymentMethodId.VENMO:
                newPaymentAccountPayload.VenmoAccountPayload = paymentAccountPayload.VenmoAccountPayload?.Convert();
                break;
            case PaymentMethodId.INTERAC_E_TRANSFER:
                newPaymentAccountPayload.InteracETransferAccountPayload = paymentAccountPayload.InteracETransferAccountPayload?.Convert();
                break;
            case PaymentMethodId.PAY_BY_MAIL:
                newPaymentAccountPayload.PayByMailAccountPayload = paymentAccountPayload.PayByMailAccountPayload?.Convert();
                break;
            case PaymentMethodId.CASH_AT_ATM:
                newPaymentAccountPayload.CashAtAtmAccountPayload = paymentAccountPayload.CashAtAtmAccountPayload?.Convert();
                break;
            case PaymentMethodId.MONEY_GRAM:
                newPaymentAccountPayload.MoneyGramAccountPayload = paymentAccountPayload.MoneyGramAccountPayload?.Convert();
                break;
            case PaymentMethodId.AMAZON_GIFT_CARD:
                newPaymentAccountPayload.AmazonGiftCardAccountPayload = paymentAccountPayload.AmazonGiftCardAccountPayload?.Convert();
                break;
            case PaymentMethodId.UPHOLD:
                newPaymentAccountPayload.UpholdAccountPayload = paymentAccountPayload.UpholdAccountPayload?.Convert();
                break;
            case PaymentMethodId.REVOLUT:
                newPaymentAccountPayload.RevolutAccountPayload = paymentAccountPayload.RevolutAccountPayload?.Convert();
                break;
            case PaymentMethodId.PERFECT_MONEY:
                newPaymentAccountPayload.PerfectMoneyAccountPayload = paymentAccountPayload.PerfectMoneyAccountPayload?.Convert();
                break;
            case PaymentMethodId.ADVANCED_CASH:
                newPaymentAccountPayload.AdvancedCashAccountPayload = paymentAccountPayload.AdvancedCashAccountPayload?.Convert();
                break;
            case PaymentMethodId.TRANSFERWISE:
                newPaymentAccountPayload.TransferwiseAccountPayload = paymentAccountPayload.TransferwiseAccountPayload?.Convert();
                break;
            case PaymentMethodId.PAYSERA:
                newPaymentAccountPayload.PayseraAccountPayload = paymentAccountPayload.PayseraAccountPayload?.Convert();
                break;
            case PaymentMethodId.PAXUM:
                newPaymentAccountPayload.PaxumAccountPayload = paymentAccountPayload.PaxumAccountPayload?.Convert();
                break;
            case PaymentMethodId.CAPITUAL:
                newPaymentAccountPayload.CapitualAccountPayload = paymentAccountPayload.CapitualAccountPayload?.Convert();
                break;
            case PaymentMethodId.CELPAY:
                newPaymentAccountPayload.CelPayAccountPayload = paymentAccountPayload.CelPayAccountPayload?.Convert();
                break;
            case PaymentMethodId.MONESE:
                newPaymentAccountPayload.MoneseAccountPayload = paymentAccountPayload.MoneseAccountPayload?.Convert();
                break;
            case PaymentMethodId.VERSE:
                newPaymentAccountPayload.VerseAccountPayload = paymentAccountPayload.VerseAccountPayload?.Convert();
                break;
            case PaymentMethodId.PAYPAL:
                newPaymentAccountPayload.PayPalAccountPayload = paymentAccountPayload.PayPalAccountPayload?.Convert();
                break;
            case PaymentMethodId.CASH_APP:
                newPaymentAccountPayload.CashAppAccountPayload = paymentAccountPayload.CashAppAccountPayload?.Convert();
                break;
            case PaymentMethodId.PAYSAFE:
                newPaymentAccountPayload.PaysafeAccountPayload = paymentAccountPayload.PaysafeAccountPayload?.Convert();
                break;
            case PaymentMethodId.JAPAN_BANK:
                newPaymentAccountPayload.JapanBankAccountPayload = paymentAccountPayload.JapanBankAccountPayload?.Convert();
                break;
            case PaymentMethodId.AUSTRALIA_PAYID:
                newPaymentAccountPayload.AustraliaPayidPayload = paymentAccountPayload.AustraliaPayidPayload?.Convert();
                break;
            case PaymentMethodId.ALI_PAY:
                newPaymentAccountPayload.AliPayAccountPayload = paymentAccountPayload.AliPayAccountPayload?.Convert();
                break;
            case PaymentMethodId.WECHAT_PAY:
                newPaymentAccountPayload.WeChatPayAccountPayload = paymentAccountPayload.WeChatPayAccountPayload?.Convert();
                break;
            case PaymentMethodId.PROMPT_PAY:
                newPaymentAccountPayload.PromptPayAccountPayload = paymentAccountPayload.PromptPayAccountPayload?.Convert();
                break;
            case PaymentMethodId.BLOCK_CHAINS:
                newPaymentAccountPayload.CryptoCurrencyAccountPayload = paymentAccountPayload.CryptoCurrencyAccountPayload?.Convert();
                break;
            case PaymentMethodId.BLOCK_CHAINS_INSTANT:
                newPaymentAccountPayload.InstantCryptoCurrencyAccountPayload = paymentAccountPayload.InstantCryptoCurrencyAccountPayload?.Convert();
                break;
            default:
                throw new Exception("Not a valid PaymentMethodId.");
        }

        return newPaymentAccountPayload;
    }

    public static PaymentAccount Convert(this Proto.Models.PaymentAccount paymentAccount)
    {
        return new PaymentAccount
        {
            AccountName = paymentAccount.AccountName,
            CreatedAt = paymentAccount.CreationDate.ToDateTime(),
            Id = paymentAccount.Id,
            SelectedTradeCurrency = paymentAccount.SelectedTradeCurrency.Convert(),
            TradeCurrencies = paymentAccount.TradeCurrencies.Select(x => x.Convert()).ToList(),
            PaymentMethod = paymentAccount.PaymentMethod.Convert(),
            PaymentAccountPayload = paymentAccount.PaymentAccountPayload.Convert()
        };
    }

    public static ContractInfo Convert(this Proto.Models.ContractInfo contractInfo)
    {
        return new ContractInfo
        {
            ArbitratorNodeAddress = contractInfo.ArbitratorNodeAddress,
            BuyerNodeAddress = contractInfo.BuyerNodeAddress,
            IsBuyerMakerAndSellerTaker = contractInfo.IsBuyerMakerAndSellerTaker,
            MakerAccountId = contractInfo.MakerAccountId,
            MakerPaymentAccountPayload = contractInfo.MakerPaymentAccountPayload?.Convert(),
            TakerPaymentAccountPayload = contractInfo.TakerPaymentAccountPayload?.Convert(),
            MakerPayoutAddressString = contractInfo.MakerPayoutAddressString,
            SellerNodeAddress = contractInfo.SellerNodeAddress,
            TakerAccountId = contractInfo.TakerAccountId,
            TakerPayoutAddressString = contractInfo.TakerPayoutAddressString,
            LockTime = contractInfo.LockTime
        };
    }

    public static TradeInfo Convert(this Proto.Models.TradeInfo tradeInfo)
    {
        return new TradeInfo
        {
            Amount = tradeInfo.Amount,
            ArbitratorNodeAddress = tradeInfo.ArbitratorNodeAddress,
            BuyerPayoutAmount = tradeInfo.BuyerPayoutAmount,
            ContractAsJson = tradeInfo.ContractAsJson,
            SellerPayoutAmount = tradeInfo.SellerPayoutAmount,
            TradePeerNodeAddress = tradeInfo.TradePeerNodeAddress,
            BuyerDepositTxFee = tradeInfo.BuyerDepositTxFee,
            BuyerPayoutTxFee = tradeInfo.BuyerPayoutTxFee,
            BuyerSecurityDeposit = tradeInfo.BuyerSecurityDeposit,
            Date = tradeInfo.Date.ToDateTime(),
            MaxDuration = TimeSpan.FromMilliseconds(tradeInfo.MaxDurationMs),
            DeadlineTime = tradeInfo.DeadlineTime.ToDateTime(),
            IsCompleted = tradeInfo.IsCompleted,
            IsDepositsConfirmed = tradeInfo.IsDepositsConfirmed,
            IsDepositsFinalized = tradeInfo.IsDepositsFinalized,
            IsDepositsPublished = tradeInfo.IsDepositsPublished,
            IsDepositsUnlocked = tradeInfo.IsDepositsUnlocked,
            IsPaymentReceived = tradeInfo.IsPaymentReceived,
            IsPaymentSent = tradeInfo.IsPaymentSent,
            IsPayoutConfirmed = tradeInfo.IsPayoutConfirmed,
            IsPayoutFinalized = tradeInfo.IsPayoutFinalized,
            IsPayoutPublished = tradeInfo.IsPayoutPublished,
            IsPayoutUnlocked = tradeInfo.IsPayoutUnlocked,
            MakerDepositTxId = tradeInfo.MakerDepositTxId,
            MakerFee = tradeInfo.MakerFee,
            PayoutTxId = tradeInfo.PayoutTxId,
            DisputeState = Enum.Parse<TradeDisputeState>(tradeInfo.DisputeState),
            PayoutState = Enum.Parse<PayoutState>(tradeInfo.PayoutState),
            PeriodState = Enum.Parse<PeriodState>(tradeInfo.PeriodState),
            Phase = Enum.Parse<Phase>(tradeInfo.Phase),
            State = Enum.Parse<TradeState>(tradeInfo.State),
            Role = tradeInfo.Role,
            Price = decimal.Parse(tradeInfo.Price, CultureInfo.InvariantCulture),
            SellerDepositTxFee = tradeInfo.SellerDepositTxFee,
            SellerPayoutTxFee = tradeInfo.SellerPayoutTxFee,
            SellerSecurityDeposit = tradeInfo.SellerSecurityDeposit,
            ShortId = tradeInfo.ShortId,
            StartTime = tradeInfo.StartTime.ToDateTime(),
            TakerDepositTxId = tradeInfo.TakerDepositTxId,
            TakerFee = tradeInfo.TakerFee,
            TradeId = tradeInfo.TradeId,
            TradeVolume = decimal.Parse(tradeInfo.TradeVolume, CultureInfo.InvariantCulture),
            Contract = tradeInfo.Contract.Convert(),
            Offer = tradeInfo.Offer.Convert()
        };
    }

    public static Attachment Convert(this Proto.Models.Attachment attachment)
    {
        return new Attachment
        {
            Bytes = attachment.Bytes,
            FileName = attachment.FileName
        };
    }

    public static NodeAddress Convert(this Proto.Models.NodeAddress nodeAddress)
    {
        return new NodeAddress
        {
            HostName = nodeAddress.HostName,
            Port = nodeAddress.Port
        };
    }

    public static NotificationMessage Convert(this Proto.Models.NotificationMessage notificationMessage)
    {
        return new NotificationMessage
        {
            Id = notificationMessage.Id,
            ChatMessage = notificationMessage.ChatMessage?.Convert(),
            Trade = notificationMessage.Trade?.Convert(),
            Message = notificationMessage.Message,
            Timestamp = notificationMessage.Timestamp.ToDateTime(),
            Title = notificationMessage.Title,
            Type = Enum.Parse<NotificationType>(notificationMessage.Type.ToString())
        };
    }

    public static ChatMessage Convert(this Proto.Models.ChatMessage chatMessage)
    {
        return new ChatMessage
        {
            AckError = chatMessage.AckError,
            HasArrived = chatMessage.Arrived,
            IsAcknowledged = chatMessage.Acknowledged,
            SenderNodeAddress = chatMessage.SenderNodeAddress.Convert(),
            Attachments = chatMessage.Attachments.Select(x => x.Convert()).ToList(),
            Date = chatMessage.Date.ToDateTime(),
            IsSystemMessage = chatMessage.IsSystemMessage,
            IsStoredInMailbox = chatMessage.StoredInMailbox,
            Message = chatMessage.Message,
            SendMessageError = chatMessage.SendMessageError,
            SenderIsTrader = chatMessage.SenderIsTrader,
            TradeId = chatMessage.TradeId,
            TraderId = chatMessage.TraderId,
            Type = chatMessage.Type,
            Uid = chatMessage.Uid,
            WasDisplayed = chatMessage.WasDisplayed
        };
    }

    public static UrlConnection Convert(this Proto.Models.UrlConnection urlConnection)
    {
        return new UrlConnection
        {
            AuthenticationStatus = urlConnection.AuthenticationStatus,
            OnlineStatus = urlConnection.OnlineStatus,
            Url = urlConnection.Url,
            Password = urlConnection.Password,
            Priority = urlConnection.Priority,
            Username = urlConnection.Username
        };
    }

    public static PubKeyRing Convert(this Proto.Models.PubKeyRing pubKeyRing)
    {
        return new PubKeyRing
        {
            EncryptionPubKeyBytes = pubKeyRing.EncryptionPubKeyBytes,
            SignaturePubKeyBytes = pubKeyRing.SignaturePubKeyBytes
        };
    }

    public static DisputeResult Convert(this Proto.Models.DisputeResult disputeResult)
    {
        return new DisputeResult
        {
            ArbitratorPubKey = disputeResult.ArbitratorPubKey,
            ArbitratorSignature = disputeResult.ArbitratorSignature,
            BuyerPayoutAmountBeforeCost = disputeResult.BuyerPayoutAmountBeforeCost,
            SellerPayoutAmountBeforeCost = disputeResult.SellerPayoutAmountBeforeCost,
            ChatMessage = disputeResult.ChatMessage.Convert(),
            CloseDate = disputeResult.CloseDate.ToDateTime(),
            IdVerification = disputeResult.IdVerification,
            IsLoserPublisher = disputeResult.IsLoserPublisher,
            ReasonOrdinal = disputeResult.ReasonOrdinal,
            ScreenCast = disputeResult.ScreenCast,
            SubtractFeeFrom = disputeResult.SubtractFeeFrom,
            SummaryNotes = disputeResult.SummaryNotes,
            TamperProofEvidence = disputeResult.TamperProofEvidence,
            TradeId = disputeResult.TradeId,
            TraderId = disputeResult.TraderId,
            Winner = disputeResult.Winner
        };
    }

    public static OfferDirection Convert(this Proto.Models.Enums.OfferDirection offerDirection)
    {
        return offerDirection switch
        {
            Proto.Models.Enums.OfferDirection.BUY => OfferDirection.BUY,
            Proto.Models.Enums.OfferDirection.SELL => OfferDirection.SELL,
            _ => throw new NotImplementedException($"OfferDirection \"{offerDirection}\" is not valid."),
        };
    }

    public static OfferPayload Convert(this Proto.Models.OfferPayload offerPayload)
    {
        return new OfferPayload
        {
            AcceptedBankIds = offerPayload.AcceptedBankIds,
            AcceptedCountryCodes = offerPayload.AcceptedCountryCodes,
            Amount = offerPayload.Amount,
            ArbitratorSignature = offerPayload.ArbitratorSignature,
            ArbitratorSigner = offerPayload.ArbitratorSigner.Convert(),
            BlockHeightAtOfferCreation = offerPayload.BlockHeightAtOfferCreation,
            MakerPaymentAccountId = offerPayload.MakerPaymentAccountId,
            MinAmount = offerPayload.MinAmount,
            OwnerNodeAddress = offerPayload.OwnerNodeAddress.Convert(),
            UseAutoClose = offerPayload.UseAutoClose,
            UseReOpenAfterAutoClose = offerPayload.UseReOpenAfterAutoClose,
            BankId = offerPayload.BankId,
            BaseCurrencyCode = offerPayload.BaseCurrencyCode,
            BuyerSecurityDepositPercent = offerPayload.BuyerSecurityDepositPct,
            ChallengeHash = offerPayload.ChallengeHash,
            CounterCurrencyCode = offerPayload.CounterCurrencyCode,
            CountryCode = offerPayload.CountryCode,
            Date = offerPayload.Date.ToDateTime(),
            Direction = offerPayload.Direction,
            ExtraData = offerPayload.ExtraData,
            ExtraInfo = offerPayload.ExtraInfo,
            Id = offerPayload.Id,
            IsPrivateOffer = offerPayload.IsPrivateOffer,
            LowerClosePrice = offerPayload.LowerClosePrice,
            MakerFeePercent = offerPayload.MakerFeePct,
            MarketPriceMarginPercent = offerPayload.MarketPriceMarginPct,
            MaxTradeLimit = offerPayload.MaxTradeLimit,
            MaxTradePeriod = offerPayload.MaxTradePeriod,
            PaymentMethodId = offerPayload.PaymentMethodId,
            PenaltyFeePercent = offerPayload.PenaltyFeePct,
            Price = offerPayload.Price,
            ProtocolVersion = offerPayload.ProtocolVersion,
            PubKeyRing = offerPayload.PubKeyRing.Convert(),
            ReserveTxKeyImages = offerPayload.ReserveTxKeyImages,
            SellerSecurityDepositPercent = offerPayload.SellerSecurityDepositPct,
            TakerFeePercent = offerPayload.TakerFeePct,
            UpperClosePrice = offerPayload.UpperClosePrice,
            UseMarketBasedPrice = offerPayload.UseMarketBasedPrice,
            VersionNr = offerPayload.VersionNr
        };
    }

    public static Contract Convert(this Proto.Models.Contract contract)
    {
        return new Contract
        {
            IsBuyerMakerAndSellerTaker = contract.IsBuyerMakerAndSellerTaker,
            ArbitratorNodeAddress = contract.ArbitratorNodeAddress.Convert(),
            BuyerNodeAddress = contract.BuyerNodeAddress.Convert(),
            MakerAccountId = contract.MakerAccountId,
            MakerPaymentAccountPayloadHash = contract.MakerPaymentAccountPayloadHash,
            MakerPayoutAddressString = contract.MakerPayoutAddressString,
            SellerNodeAddress = contract.SellerNodeAddress.Convert(),
            TakerAccountId = contract.TakerAccountId,
            TakerPaymentAccountPayloadHash = contract.TakerPaymentAccountPayloadHash,
            TakerPayoutAddressString = contract.TakerPayoutAddressString,
            TradeAmount = contract.TradeAmount,
            MakerDepositTxHash = contract.MakerDepositTxHash,
            MakerPaymentMethodId = contract.MakerPaymentMethodId,
            MakerPubKeyRing = contract.MakerPubKeyRing.Convert(),
            OfferPayload = contract.OfferPayload.Convert(),
            TakerDepositTxHash = contract.TakerDepositTxHash,
            TakerPaymentMethodId = contract.TakerPaymentMethodId,
            TakerPubKeyRing = contract.TakerPubKeyRing.Convert(),
            TradePrice = contract.TradePrice
        };
    }

    public static Dispute Convert(this Proto.Models.Dispute dispute)
    {
        return new Dispute
        {
            AgentPubKeyRing = dispute.AgentPubKeyRing.Convert(),
            ContractAsJson = dispute.ContractAsJson,
            DonationAddressOfDelayedPayoutTx = dispute.DonationAddressOfDelayedPayoutTx,
            MakerPaymentAccountPayload = dispute.MakerPaymentAccountPayload?.Convert(),
            TakerPaymentAccountPayload = dispute.TakerPaymentAccountPayload?.Convert(),
            ChatMessages = dispute.ChatMessage.Select(x => x.Convert()).ToList(),
            Contract = dispute.Contract.Convert(),
            ContractHash = dispute.ContractHash,
            DelayedPayoutTxId = dispute.DelayedPayoutTxId,
            DisputeOpenerIsBuyer = dispute.DisputeOpenerIsBuyer,
            DisputeOpenerIsMaker = dispute.DisputeOpenerIsMaker,
            DisputePayoutTxId = dispute.DisputePayoutTxId,
            ExtraData = dispute.ExtraData,
            Id = dispute.Id,
            IsClosed = dispute.IsClosed,
            IsOpener = dispute.IsOpener,
            IsSupportTicket = dispute.IsSupportTicket,
            MakerContractSignature = dispute.MakerContractSignature,
            MediatorsDisputeResult = dispute.MediatorsDisputeResult,
            OpeningDate = dispute.OpeningDate.ToDateTime(),
            PayoutTxId = dispute.PayoutTxId,
            PayoutTxSerialized = dispute.PayoutTxSerialized,
            DisputeResult = dispute.DisputeResult.Convert(),
            State = dispute.State,
            SupportType = dispute.SupportType,
            TakerContractSignature = dispute.TakerContractSignature,
            TradeDate = dispute.TradeDate.ToDateTime(),
            TradeId = dispute.TradeId,
            TradePeriodEnd = dispute.TradePeriodEnd.ToDateTime(),
            TraderId = dispute.TraderId,
            TraderPubKeyRing = dispute.TraderPubKeyRing.Convert()
        };
    }
}
