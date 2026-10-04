namespace Haveno.Tests;

public class AppSettings
{
    public required string MoneroDaemonExecutablePath { get; set; }
    public required string MoneroRpcExecutablePath { get; set; }
    public required string HavenoDaemonExecutablePath { get; set; }
    public required string HavenoSeedExecutablePath { get; set; }
}