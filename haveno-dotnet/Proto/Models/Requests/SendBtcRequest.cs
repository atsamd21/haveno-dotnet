using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "SendBtcRequest")]
internal class SendBtcRequest
{
    [ProtoMember(1)]
    public string Address { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Amount { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string TxFeeRate { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string Memo { get; set; } = string.Empty;
}
