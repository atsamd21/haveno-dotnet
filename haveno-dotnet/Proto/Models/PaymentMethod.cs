using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "PaymentMethod")]
internal class PaymentMethod
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
    [ProtoMember(2)]
    public long MaxTradePeriod { get; set; }
    [ProtoMember(3)]
    public long MaxTradeLimit { get; set; }
    [ProtoMember(4)]
    public List<string> SupportedAssetCodes { get; set; } = [];
}
