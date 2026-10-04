using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetPaymentMethodsReply")]
internal class GetPaymentMethodsReply
{
    [ProtoMember(1)]
    public List<PaymentMethod> PaymentMethods { get; set; } = [];
}
