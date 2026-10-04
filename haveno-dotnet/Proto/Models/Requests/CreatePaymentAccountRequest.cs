using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "CreatePaymentAccountRequest")]
internal class CreatePaymentAccountRequest
{
    [ProtoMember(1)]
    public PaymentAccountForm PaymentAccountForm { get; set; } = new();
    [ProtoMember(2)]
    public string PaymentAccountFormAsJson { get; set; } = string.Empty;
}
