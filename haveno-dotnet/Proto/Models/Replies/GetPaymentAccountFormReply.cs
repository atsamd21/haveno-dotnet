using ProtoBuf;


namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetPaymentAccountFormReply")]
internal class GetPaymentAccountFormReply
{
    [ProtoMember(1)]
    public PaymentAccountForm PaymentAccountForm { get; set; } = new();
}
