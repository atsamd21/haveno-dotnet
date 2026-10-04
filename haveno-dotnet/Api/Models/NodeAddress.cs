namespace Haveno.Api.Models;

public class NodeAddress
{
    public string HostName { get; set; } = string.Empty;   
    public int Port { get; set; }

    // ?
    public override string ToString()
    {
        return $"{HostName}:{Port}";
    }
}
