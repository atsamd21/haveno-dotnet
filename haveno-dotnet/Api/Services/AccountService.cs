using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IAccountService
{
    Task<bool> AccountExistsAsync(CancellationToken cancellationToken = default);
    Task<bool> IsAccountOpenAsync(CancellationToken cancellationToken = default);
    Task CreateAccountAsync(string password, CancellationToken cancellationToken = default);
    Task OpenAccountAsync(string password, CancellationToken cancellationToken = default);
    Task<bool> IsAppInitializedAsync(CancellationToken cancellationToken = default);
    Task ChangePasswordAsync(string oldPassword, string newPassword, CancellationToken cancellationToken = default);
    Task CloseAccountAsync(CancellationToken cancellationToken = default);
    Task DeleteAccountAsync(CancellationToken cancellationToken = default);
    Task<byte[]> BackupAccountAsync(CancellationToken cancellationToken = default);
    Task<Stream> BackupAccountAsStreamAsync(CancellationToken cancellationToken = default);
    Task RestoreAccountAsync(byte[] zipBytes, CancellationToken cancellationToken = default);
    Task RestoreAccountAsync(Stream zipStream, CancellationToken cancellationToken = default);
}

public sealed class AccountService : IAccountService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoAccountClient _havenoAccountClient;

    public AccountService(GrpcChannelSingleton grpcChannelService)
    {
        _grpcChannelSingleton = grpcChannelService;
        _havenoAccountClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoAccountClient>();
    }

    public async Task<bool> AccountExistsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoAccountClient.AccountExistsAsync(
            new Proto.Models.Requests.AccountExistsRequest(),
            cancellationToken);

        return response.AccountExists;
    }

    public async Task<bool> IsAccountOpenAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoAccountClient.IsAccountOpenAsync(
            new Proto.Models.Requests.IsAccountOpenRequest(),
            cancellationToken);

        return response.IsAccountOpen;
    }

    public async Task CreateAccountAsync(string password, CancellationToken cancellationToken = default)
    {
        await _havenoAccountClient.CreateAccountAsync(
            new Proto.Models.Requests.CreateAccountRequest
            {
                Password = password
            },
            cancellationToken);
    }

    public async Task OpenAccountAsync(string password, CancellationToken cancellationToken = default)
    {
        await _havenoAccountClient.OpenAccountAsync(
            new Proto.Models.Requests.OpenAccountRequest
            {
                Password = password
            },
            cancellationToken);
    }

    public async Task<bool> IsAppInitializedAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoAccountClient.IsAppInitializedAsync(
            new Proto.Models.Requests.IsAppInitializedRequest(),
            cancellationToken);

        return response.IsAppInitialized;
    }

    public async Task ChangePasswordAsync(string oldPassword, string newPassword, CancellationToken cancellationToken = default)
    {
        await _havenoAccountClient.ChangePasswordAsync(
            new Proto.Models.Requests.ChangePasswordRequest
            {
                OldPassword = oldPassword,
                NewPassword = newPassword
            },
            cancellationToken);
    }

    public async Task CloseAccountAsync(CancellationToken cancellationToken = default)
    {
        await _havenoAccountClient.CloseAccountAsync(
            new Proto.Models.Requests.CloseAccountRequest(), 
            cancellationToken);
    }

    public async Task DeleteAccountAsync(CancellationToken cancellationToken = default)
    {
        await _havenoAccountClient.DeleteAccountAsync(
            new Proto.Models.Requests.DeleteAccountRequest(),
            cancellationToken);
    }

    public async Task<byte[]> BackupAccountAsync(CancellationToken cancellationToken = default)
    {
        var stream  = _havenoAccountClient.BackupAccountAsync(
            new Proto.Models.Requests.BackupAccountRequest(), 
            cancellationToken);

        MemoryStream memoryStream = new();

        await foreach (var response in stream)
        {
            memoryStream.Write(response.ZipBytes);
        }

        return memoryStream.ToArray();
    }

    //
    public async Task RestoreAccountAsync(byte[] zipBytes, CancellationToken cancellationToken = default)
    {
        await _havenoAccountClient.RestoreAccountAsync(
            new Proto.Models.Requests.RestoreAccountRequest
            {
                Offset = 0,
                HasMore = false,
                ZipBytes = zipBytes,
                TotalLength = (ulong)zipBytes.Length
            }, 
            cancellationToken);
    }

    public async Task<Stream> BackupAccountAsStreamAsync(CancellationToken cancellationToken = default)
    {
        var stream = _havenoAccountClient.BackupAccountAsync(
            new Proto.Models.Requests.BackupAccountRequest(), 
            cancellationToken);

        MemoryStream memoryStream = new();

        await foreach (var response in stream)
        {
            memoryStream.Write(response.ZipBytes);
        }

        memoryStream.Position = 0;

        return memoryStream;
    }

    public async Task RestoreAccountAsync(Stream zipStream, CancellationToken cancellationToken = default)
    {
        byte[] bytes = new byte[4 * 1024 * 1024 - 4096];

        ulong totalBytesRead = 0;
        int bytesRead;
        while ((bytesRead = await zipStream.ReadAsync(bytes, cancellationToken)) != 0)
        {
            byte[] trimmedBytes = bytes.AsSpan(0, bytesRead).ToArray();

            await _havenoAccountClient.RestoreAccountAsync(
                new Proto.Models.Requests.RestoreAccountRequest
                {
                    Offset = totalBytesRead,
                    HasMore = zipStream.Position != zipStream.Length,
                    ZipBytes = trimmedBytes,
                    TotalLength = (ulong)zipStream.Length
                },
                cancellationToken);

            totalBytesRead += (ulong)bytesRead;
        }
    }
}
