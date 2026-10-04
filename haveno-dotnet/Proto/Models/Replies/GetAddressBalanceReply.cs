using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetAddressBalanceReply")]
internal class GetAddressBalanceReply
{
    [ProtoMember(1)]
    public AddressBalanceInfo AddressBalanceInfo { get; set; } = new();
}