using ProtoBuf;

namespace Haveno.Proto.Models.Requests;


[ProtoContract(Name = "WithdrawFundsRequest")]
internal class WithdrawFundsRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Address { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Memo { get; set; } = string.Empty;
}
