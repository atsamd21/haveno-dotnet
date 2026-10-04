using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "BtcBalanceInfo")]
internal class BtcBalanceInfo
{
    [ProtoMember(1)]
    public long AvailableBalance { get; set; }
    [ProtoMember(2)]
    public long ReservedBalance { get; set; }
    [ProtoMember(3)]
    public long TotalAvailableBalance { get; set; }
    [ProtoMember(4)]
    public long LockedBalance { get; set; }
}
