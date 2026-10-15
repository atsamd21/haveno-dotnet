namespace Haveno.Api.Models.Converters;

internal static class ToProto
{
    public static Proto.Models.Region Convert(this Region region)
    {
        return new Proto.Models.Region
        {
            Code = region.Code,
            Name = region.Name
        };
    }

    public static Proto.Models.Country Convert(this Country country)
    {
        return new Proto.Models.Country
        {
            Code = country.Code,
            Name = country.Name,
            Region = country.Region.Convert()
        };
    }

    public static Proto.Models.PaymentAccountFormField Convert(this PaymentAccountFormField paymentAccountFormField)
    {
        return new Proto.Models.PaymentAccountFormField
        {
            Id = paymentAccountFormField.Id,
            Label = paymentAccountFormField.Label,
            MaxLength = paymentAccountFormField.MaxLength,
            MinLength = paymentAccountFormField.MinLength,
            Value = paymentAccountFormField.Value,
            Type = paymentAccountFormField.Type,
            RequiredForCountries = paymentAccountFormField.RequiredForCountries,
            Component = paymentAccountFormField.Component,
            SupportedCountries = paymentAccountFormField.SupportedCountries.Select(y => y.Convert()).ToList(),
            SupportedCurrencies = paymentAccountFormField.SupportedCurrencies.Select(y => new Proto.Models.TradeCurrency
            {
                Code = y.Code,
                CryptoCurrency = y.CryptoCurrency is null ? null : new Proto.Models.CryptoCurrency
                {
                    IsAsset = y.CryptoCurrency.IsAsset
                },
                Name = y.Name,
                TraditionalCurrency = y.TraditionalCurrency is null ? null : new Proto.Models.TraditionalCurrency
                {

                }
            }).ToList(),
            SupportedSepaEuroCountries = paymentAccountFormField.SupportedSepaEuroCountries.Select(y => y.Convert()).ToList(),
            SupportedSepaNonEuroCountries = paymentAccountFormField.SupportedSepaNonEuroCountries.Select(y => y.Convert()).ToList(),
            SupportedValues = paymentAccountFormField.SupportedValues,
            RequiredIfAnyFieldHasValue = paymentAccountFormField.RequiredIfAnyFieldHasValue,
            Required = paymentAccountFormField.Required
        };
    }

    public static Proto.Models.PaymentAccountForm Convert(this PaymentAccountForm paymentAccountForm)
    {
        return new Proto.Models.PaymentAccountForm
        {
            Id = paymentAccountForm.Id,
            Fields = paymentAccountForm.Fields.Select(paymentAccountFormField => paymentAccountFormField.Convert()).ToList()
        };
    }

    public static Proto.Models.UrlConnection Convert(this UrlConnection urlConnection)
    {
        return new Proto.Models.UrlConnection
        {
            AuthenticationStatus = urlConnection.AuthenticationStatus,
            OnlineStatus = urlConnection.OnlineStatus,  
            Url = urlConnection.Url,
            Password = urlConnection.Password,
            Priority = urlConnection.Priority,
            Username = urlConnection.Username
        };
    }

    public static Proto.Models.Attachment Convert(this Attachment attachment)
    {
        return new Proto.Models.Attachment
        {
            Bytes = attachment.Bytes,
            FileName = attachment.FileName
        };
    }

    public static Proto.Models.NodeAddress Convert(this NodeAddress nodeAddress)
    {
        return new Proto.Models.NodeAddress
        {
            HostName = nodeAddress.HostName,
            Port = nodeAddress.Port
        };
    }

    public static Proto.Models.ChatMessage Convert(this ChatMessage chatMessage)
    {
        return new Proto.Models.ChatMessage
        {
            AckError = chatMessage.AckError,
            Arrived = chatMessage.HasArrived,
            Acknowledged = chatMessage.IsAcknowledged,
            SenderNodeAddress = chatMessage.SenderNodeAddress.Convert(),
            Attachments = chatMessage.Attachments.Select(x => x.Convert()).ToList(),
            Date = chatMessage.Date.Ticks,
            IsSystemMessage = chatMessage.IsSystemMessage,
            StoredInMailbox = chatMessage.IsStoredInMailbox,
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

    public static Proto.Models.NotificationMessage Convert(this NotificationMessage notificationMessage)
    {
        return new Proto.Models.NotificationMessage
        {
            Id = notificationMessage.Id,
            Message = notificationMessage.Message,
            ChatMessage = notificationMessage.ChatMessage?.Convert(),
            // TODO - only used when sending test messages
            //Trade = notificationMessage.Trade?.Convert(),
            Timestamp = notificationMessage.Timestamp.Ticks,
            Title = notificationMessage.Title,
            Type = Enum.Parse<Proto.Models.Enums.NotificationType>(notificationMessage.Type.ToString())
        };
    }
}
