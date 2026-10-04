using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetTradesRequest")]
internal class GetTradesRequest
{
    [ProtoMember(1)]
    public Category? Category { get; set; }
}
