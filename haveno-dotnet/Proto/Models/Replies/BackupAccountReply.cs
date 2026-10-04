using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "BackupAccountReply")]
internal class BackupAccountReply
{
    [ProtoMember(1)]
    public byte[] ZipBytes { get; set; } = [];
}
