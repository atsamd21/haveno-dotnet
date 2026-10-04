using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "DeletePaymentAccountRequest")]
internal class DeletePaymentAccountRequest
{
    [ProtoMember(1)]
    public string PaymentAccountId { get; set; } = string.Empty;
}
