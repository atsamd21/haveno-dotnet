namespace Haveno.Api.Models;

public class AddressBalanceInfo
{
    public string Address { get; set; } = string.Empty;
    public ulong Balance { get; set; }
    public long NumConfirmations { get; set; }
    public bool IsAddressUnused { get; set; }
}
