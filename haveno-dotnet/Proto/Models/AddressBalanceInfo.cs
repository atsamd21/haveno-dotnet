using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "AddressBalanceInfo")]
internal class AddressBalanceInfo
{
    [ProtoMember(1)]
    public string Address { get; set; } = string.Empty;
    [ProtoMember(2)]
    public long Balance { get; set; }
    [ProtoMember(3)]
    public long NumConfirmations { get; set; }
    [ProtoMember(4)]
    public bool IsAddressUnused { get; set; }
}
