using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetPaymentAccountFormAsJsonReply")]
internal class GetPaymentAccountFormAsJsonReply
{
    [ProtoMember(1)]
    public string PaymentAccountFormAsJson { get; set; } = string.Empty;
}
