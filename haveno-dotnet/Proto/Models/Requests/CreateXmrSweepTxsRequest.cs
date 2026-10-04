using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "CreateXmrSweepTxsRequest")]
internal class CreateXmrSweepTxsRequest
{
    [ProtoMember(1)]
    public string Address { get; set; } = string.Empty;
}