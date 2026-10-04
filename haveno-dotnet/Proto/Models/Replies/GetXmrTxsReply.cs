using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetXmrTxsReply")]
internal class GetXmrTxsReply
{
    [ProtoMember(1)]
    public List<XmrTx> Txs { get; set; } = [];
}