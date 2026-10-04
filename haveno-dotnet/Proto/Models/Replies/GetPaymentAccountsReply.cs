using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetPaymentAccountsReply")]
internal class GetPaymentAccountsReply
{
    [ProtoMember(1)]
    public List<PaymentAccount> PaymentAccounts { get; set; } = [];
}
