using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "PubKeyRing")]
internal class PubKeyRing
{
    [ProtoMember(1)]
    public byte[] SignaturePubKeyBytes { get; set; } = [];
    [ProtoMember(2)]
    public byte[] EncryptionPubKeyBytes { get; set; } = [];
}
