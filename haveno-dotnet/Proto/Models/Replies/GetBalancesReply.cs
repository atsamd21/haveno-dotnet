using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetBalancesReply")]
internal class GetBalancesReply
{
    [ProtoMember(1)]
    public BalancesInfo Balances { get; set; } = new();
}
