using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "CreatePaymentAccountReply")]
internal class CreatePaymentAccountReply
{
    [ProtoMember(1)]
    public PaymentAccount PaymentAccount { get; set; } = new();
}
