using System.Runtime.CompilerServices;
using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.Account")]
internal interface IHavenoAccountClient
{
    [OperationContract(Name = "AccountExists")]
    Task<AccountExistsReply> AccountExistsAsync(AccountExistsRequest accountExistsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "IsAccountOpen")]
    Task<IsAccountOpenReply> IsAccountOpenAsync(IsAccountOpenRequest isAccountOpenRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CreateAccount")]
    Task<CreateAccountReply> CreateAccountAsync(CreateAccountRequest createAccountRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "OpenAccount")]
    Task<OpenAccountReply> OpenAccountAsync(OpenAccountRequest openAccountRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "IsAppInitialized")]
    Task<IsAppInitializedReply> IsAppInitializedAsync(IsAppInitializedRequest isAppInitializedRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "ChangePassword")]
    Task<ChangePasswordReply> ChangePasswordAsync(ChangePasswordRequest changePasswordRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CloseAccount")]
    Task<CloseAccountReply> CloseAccountAsync(CloseAccountRequest closeAccountRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "DeleteAccount")]
    Task<DeleteAccountReply> DeleteAccountAsync(DeleteAccountRequest deleteAccountRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "BackupAccount")]
    IAsyncEnumerable<BackupAccountReply> BackupAccountAsync(BackupAccountRequest backupAccountRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "RestoreAccount")]
    Task<RestoreAccountReply> RestoreAccountAsync(RestoreAccountRequest restoreAccountRequest, CancellationToken cancellationToken = default);
}
