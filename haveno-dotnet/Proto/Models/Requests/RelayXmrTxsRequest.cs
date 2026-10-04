using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "RelayXmrTxsRequest")]
internal class RelayXmrTxsRequest
{
    [ProtoMember(1)]
    public List<string> Metadatas { get; set; } = [];
}