using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "CryptoCurrency")]
internal class CryptoCurrency
{
    [ProtoMember(1)]
    public bool IsAsset { get; set; }
}
