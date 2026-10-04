using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "CreateXmrTxReply")]
internal class CreateXmrTxReply
{
    [ProtoMember(1)]
    public XmrTx Tx { get; set; } = new();
}