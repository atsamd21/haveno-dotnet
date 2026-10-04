using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "StartCheckingConnectionRequest")]
internal class StartCheckingConnectionRequest
{
    [ProtoMember(1)]
    public int RefreshPeriod { get; set; }
}
