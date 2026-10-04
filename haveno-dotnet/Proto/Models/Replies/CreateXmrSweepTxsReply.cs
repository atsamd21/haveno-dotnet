using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "CreateXmrSweepTxsReply")]
internal class CreateXmrSweepTxsReply
{
    [ProtoMember(1)]
    public List<XmrTx> Txs { get; set; } = [];
}
