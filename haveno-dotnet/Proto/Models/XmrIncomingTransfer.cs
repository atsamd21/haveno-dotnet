using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "XmrIncomingTransfer")]
internal class XmrIncomingTransfer
{
    [ProtoMember(1)]
    public string Amount { get; set; } = string.Empty;
    [ProtoMember(2)]
    public int AccountIndex { get; set; }
    [ProtoMember(3)]
    public int SubaddressIndex { get; set; }
    [ProtoMember(4)]
    public string Address { get; set; } = string.Empty;
    [ProtoMember(5)]
    public ulong NumSuggestedConfirmations { get; set; }
}
