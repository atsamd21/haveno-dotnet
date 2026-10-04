using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "XmrTx")]
internal class XmrTx
{
    [ProtoMember(1)]
    public string Hash { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Fee { get; set; } = string.Empty;
    [ProtoMember(3)]
    public bool IsConfirmed { get; set; }
    [ProtoMember(4)]
    public bool IsLocked { get; set; }
    [ProtoMember(5)]
    public ulong Height { get; set; }
    [ProtoMember(6)]
    public ulong Timestamp { get; set; }
    [ProtoMember(7)]
    public List<XmrIncomingTransfer> IncomingTransfers { get; set; } = [];
    [ProtoMember(8)]
    public XmrOutgoingTransfer? OutgoingTransfer { get; set; }
    [ProtoMember(9)]
    public string Metadata { get; set; } = string.Empty;
}
