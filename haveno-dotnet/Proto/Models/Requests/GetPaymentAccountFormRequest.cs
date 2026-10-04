using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetPaymentAccountFormRequest")]
internal class GetPaymentAccountFormRequest
{
    [ProtoMember(1)]
    public string PaymentMethodId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public PaymentAccountPayload PaymentAccountPayload { get; set; } = new();
}
