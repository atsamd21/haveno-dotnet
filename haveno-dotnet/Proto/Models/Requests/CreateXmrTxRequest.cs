using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "CreateXmrTxRequest")]
internal class CreateXmrTxRequest
{
    [ProtoMember(1)]
    public List<XmrDestination> Destinations { get; set; } = [];
}
