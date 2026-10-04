using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "XmrOutgoingTransfer")]
internal class XmrOutgoingTransfer
{
    [ProtoMember(1)]
    public string Amount { get; set; } = string.Empty;
    [ProtoMember(2)]
    public int AccountIndex { get; set; }
    [ProtoMember(3)]
    public List<int> SubaddressIndices { get; set; } = [];
    [ProtoMember(4)]
    public List<XmrDestination> Destinations { get; set; } = [];
}
