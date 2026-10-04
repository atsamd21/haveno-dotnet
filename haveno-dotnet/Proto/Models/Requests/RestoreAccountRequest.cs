using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "RestoreAccountRequest")]
internal class RestoreAccountRequest
{
    [ProtoMember(1)]
    public byte[] ZipBytes { get; set; } = [];
    [ProtoMember(2)]
    public ulong Offset { get; set; }
    [ProtoMember(3)]
    public ulong TotalLength { get; set; }
    [ProtoMember(4)]
    public bool HasMore { get; set; }
}
