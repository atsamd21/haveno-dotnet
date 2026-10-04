using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetPaymentAccountFormAsJsonRequest")]
internal class GetPaymentAccountFormAsJsonRequest
{
    [ProtoMember(1)]
    public string PaymentMethodId { get; set; } = string.Empty;
}
