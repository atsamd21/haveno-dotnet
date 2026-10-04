namespace Haveno.Api.Models.Requests;

public class CreatePaymentAccountRequest
{
    public PaymentAccountForm PaymentAccountForm { get; set; } = new();
    public string PaymentAccountFormAsJson { get; set; } = string.Empty;
}
