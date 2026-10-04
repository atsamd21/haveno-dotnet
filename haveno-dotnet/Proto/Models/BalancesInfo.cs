using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "BalancesInfo")]
internal class BalancesInfo
{
    [ProtoMember(1)]
    public BtcBalanceInfo Btc { get; set; } = new();
    [ProtoMember(2)]
    public XmrBalanceInfo Xmr { get; set; } = new();
}
