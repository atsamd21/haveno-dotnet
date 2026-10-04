namespace Haveno.Api.Models;

public class Attachment
{
    public string FileName { get; set; } = string.Empty;
    public byte[] Bytes { get; set; } = [];
}
