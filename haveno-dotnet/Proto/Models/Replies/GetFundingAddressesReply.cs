using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetFundingAddressesReply")]
internal class GetFundingAddressesReply
{
    [ProtoMember(1)]
    public List<AddressBalanceInfo> AddressBalanceInfo { get; set; } = [];
}
