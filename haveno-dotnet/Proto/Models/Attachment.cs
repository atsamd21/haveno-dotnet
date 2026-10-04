using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "Attachment")]
internal class Attachment
{
    [ProtoMember(1)]
    public string FileName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public byte[] Bytes { get; set; } = [];
}
