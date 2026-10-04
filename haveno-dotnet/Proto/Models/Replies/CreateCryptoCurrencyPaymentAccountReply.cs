using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "CreateCryptoCurrencyPaymentAccountReply")]
internal class CreateCryptoCurrencyPaymentAccountReply
{
    [ProtoMember(1)]
    public PaymentAccount PaymentAccount { get; set; } = new();
}
