using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace Haveno.Processes;

public interface IJob : IDisposable
{
    void Create(nint handle);
}

[SupportedOSPlatform("linux")]
public class LinuxJob : IJob
{
    public void Create(nint handle)
    {

    }

    public void Dispose()
    {

    }
}

[SupportedOSPlatform("windows")]
public class WindowsJob : IJob
{
    private nint _extendedInfoPtr = nint.Zero;
    private nint _jobHandle = nint.Zero;

    [DllImport("kernel32.dll")]
    private static extern nint CreateJobObject(nint lpJobAttributes, string? lpName);

    [DllImport("kernel32.dll")]
    private static extern bool SetInformationJobObject(nint hJob, JOBOBJECTINFOCLASS infoClass, nint lpJobObjectInfo, uint cbJobObjectInfoLength);

    [DllImport("kernel32.dll")]
    private static extern bool AssignProcessToJobObject(nint job, nint process);

    [DllImport("kernel32.dll")]
    private static extern bool TerminateJobObject(nint hJob, uint uExitCode);

    [DllImport("kernel32.dll")]
    private static extern uint GetLastError();

    [DllImport("kernel32.dll")]
    private static unsafe extern uint FormatMessage(uint dwFlags, nint lpSource, uint dwMessageId, uint dwLanguageId, byte* lpBuffer, uint nSize, nint va_list);

    private enum JOBOBJECTINFOCLASS : int
    {
        AssociateCompletionPortInformation = 7,
        BasicLimitInformation = 2,
        BasicUIRestrictions = 4,
        EndOfJobTimeInformation = 6,
        ExtendedLimitInformation = 9,
        SecurityLimitInformation = 5,
        GroupInformation = 11
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct JOBOBJECT_BASIC_LIMIT_INFORMATION
    {
        public long PerProcessUserTimeLimit;
        public long PerJobUserTimeLimit;
        public uint LimitFlags;
        public nuint MinimumWorkingSetSize;
        public nuint MaximumWorkingSetSize;
        public uint ActiveProcessLimit;
        public long Affinity;
        public uint PriorityClass;
        public uint SchedulingClass;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct IO_COUNTERS
    {
        public ulong ReadOperationCount;
        public ulong WriteOperationCount;
        public ulong OtherOperationCount;
        public ulong ReadTransferCount;
        public ulong WriteTransferCount;
        public ulong OtherTransferCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
    {
        public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
        public IO_COUNTERS IoInfo;
        public nuint ProcessMemoryLimit;
        public nuint JobMemoryLimit;
        public nuint PeakProcessMemoryUsed;
        public nuint PeakJobMemoryUsed;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct SECURITY_ATTRIBUTES
    {
        public uint NLength;
        public nint LpSecurityDescriptor;
        public bool BInheritHandle;
    }

    private unsafe string GetLastErrorString()
    {
        byte* buffer = (byte*)Marshal.AllocHGlobal(4096 * sizeof(byte));

        try
        {
            var errorCode = GetLastError();
            var returnCode = FormatMessage(
                0x00001000, 
                0x00000800, 
                errorCode, 
                0, 
                buffer, 
                4096, 
                0);

            return Encoding.UTF8.GetString(buffer, (int)returnCode);
        }
        finally
        {
            Marshal.FreeHGlobal((nint)buffer);
        }
    }

    public void Create(nint handle)
    {
        _jobHandle = CreateJobObject(nint.Zero, null);
        if (_jobHandle == nint.Zero || _jobHandle == -1)
            throw new Exception($"Could not create Windows job object. Error: {GetLastErrorString()}");

        JOBOBJECT_EXTENDED_LIMIT_INFORMATION extendedInfo = new()
        {
            BasicLimitInformation = new JOBOBJECT_BASIC_LIMIT_INFORMATION
            {
                LimitFlags = 0x2000
            }
        };

        int length = Marshal.SizeOf<JOBOBJECT_EXTENDED_LIMIT_INFORMATION>();
        _extendedInfoPtr = Marshal.AllocHGlobal(length);

        try
        {
            Marshal.StructureToPtr(extendedInfo, _extendedInfoPtr, false);

            if (!SetInformationJobObject(_jobHandle, JOBOBJECTINFOCLASS.ExtendedLimitInformation, _extendedInfoPtr, (uint)length))
            {
                throw new Exception($"Error when calling SetInformationJobObject: {GetLastErrorString()}");
            }

            if (!AssignProcessToJobObject(_jobHandle, handle))
            {
                throw new Exception($"Error when calling AssignProcessToJobObject: {GetLastErrorString()}");
            }
        }
        catch
        {
            Dispose();
            throw;
        }
    }

    public void Dispose()
    {
        if (_extendedInfoPtr != nint.Zero)
            Marshal.FreeHGlobal(_extendedInfoPtr);

        if (!TerminateJobObject(_jobHandle, 0x00))
        {
            Console.WriteLine($"Failed to terminate job with handle {_jobHandle}. Error: {GetLastErrorString()}");
        }

        GC.SuppressFinalize(this);
    }
}
