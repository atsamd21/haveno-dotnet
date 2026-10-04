using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "XmrBalanceInfo")]
internal class XmrBalanceInfo
{
    [ProtoMember(1)]
    public long Balance { get; set; }
    [ProtoMember(2)]
    public long AvailableBalance { get; set; }
    [ProtoMember(3)]
    public long PendingBalance { get; set; }
    [ProtoMember(4)]
    public long ReservedOfferBalance { get; set; }
    [ProtoMember(5)]
    public long ReservedTradeBalance { get; set; }
}
