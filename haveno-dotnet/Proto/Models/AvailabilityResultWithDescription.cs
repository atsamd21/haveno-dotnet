using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "AvailabilityResultWithDescription")]
internal class AvailabilityResultWithDescription
{
    [ProtoMember(1)]
    public AvailabilityResult AvailabilityResult { get; set; }
    [ProtoMember(2)]
    public string Description { get; set; } = string.Empty;
}
