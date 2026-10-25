using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "Alert")]
internal class Alert
{
    [ProtoMember(1)]
    public string Message { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Version { get; set; } = string.Empty;
    [ProtoMember(3)]
    public bool IsUpdateInfo { get; set; }
    [ProtoMember(4)]
    public string SignatureAsBase64 { get; set; } = string.Empty;
    [ProtoMember(5)]
    public byte[] OwnerPubKeyBytes { get; set; } = [];
    [ProtoMember(6)]
    public Dictionary<string, string> ExtraData { get; set; } = [];
    [ProtoMember(7)]
    public bool IsPreReleaseInfo { get; set; }
}
