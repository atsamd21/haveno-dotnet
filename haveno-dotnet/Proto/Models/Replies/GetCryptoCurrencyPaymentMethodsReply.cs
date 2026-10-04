using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetCryptoCurrencyPaymentMethodsReply")]
internal class GetCryptoCurrencyPaymentMethodsReply
{
    [ProtoMember(1)]
    public List<PaymentMethod> PaymentMethods { get; set; } = [];
}
