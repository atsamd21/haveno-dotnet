using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Haveno.Processes;

// TODO macos
[SupportedOSPlatform("windows")]
[SupportedOSPlatform("linux")]
public class ManagedProcess : Process
{
    private IJob? _job;

    //[CLSCompliant(false)]
    //[SupportedOSPlatform("windows")]
    //public static Process Start(string fileName, string userName, SecureString password, string domain)
    //{
    //    ProcessStartInfo startInfo = new ProcessStartInfo(fileName);
    //    startInfo.UserName = userName;
    //    startInfo.Password = password;
    //    startInfo.Domain = domain;
    //    startInfo.UseShellExecute = false;
    //    return Start(startInfo);
    //}

    //[CLSCompliant(false)]
    //[SupportedOSPlatform("windows")]
    //public static Process Start(string fileName, string arguments, string userName, SecureString password, string domain)
    //{
    //    ProcessStartInfo startInfo = new ProcessStartInfo(fileName, arguments);
    //    startInfo.UserName = userName;
    //    startInfo.Password = password;
    //    startInfo.Domain = domain;
    //    startInfo.UseShellExecute = false;
    //    return Start(startInfo);
    //}

    public static new ManagedProcess Start(string fileName)
    {
        return Start(new ProcessStartInfo(fileName));
    }

    public static new ManagedProcess Start(string fileName, string arguments)
    {
        return Start(new ProcessStartInfo(fileName, arguments));
    }

    public static new ManagedProcess Start(string fileName, IEnumerable<string> arguments)
    {
        return Start(new ProcessStartInfo(fileName, arguments));
    }

    public static new ManagedProcess Start(ProcessStartInfo processStartInfo)
    {
        ManagedProcess process = new()
        {
            StartInfo = processStartInfo
        };

        // Or process is already running?
        if (!process.Start())
            throw new Exception($"Could not start process ({processStartInfo.FileName}).");

        return process;
    }

    public new bool Start()
    {
        var startedSuccessfully = base.Start();
        if (startedSuccessfully)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _job = new WindowsJob();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                _job = new LinuxJob();
            }
            else throw new NotSupportedException($"Platform \"{RuntimeInformation.OSArchitecture}\" is not supported.");

            _job.Create(Handle);
        }

        return startedSuccessfully;
    }

    public new void Dispose()
    {
        _job?.Dispose();
        base.Dispose();
    }
}
