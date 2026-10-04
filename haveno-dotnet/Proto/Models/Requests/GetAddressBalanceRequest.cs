using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetAddressBalanceRequest")]
internal class GetAddressBalanceRequest
{
    [ProtoMember(1)]
    public string Address { get; set; } = string.Empty;
}