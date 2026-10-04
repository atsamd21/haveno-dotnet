using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.Wallets")]
internal interface IHavenoWalletClient
{
    [OperationContract(Name = "GetBalances")]
    Task<GetBalancesReply> GetBalancesAsync(GetBalancesRequest getBalancesRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetXmrSeed")]
    Task<GetXmrSeedReply> GetXmrSeedAsync(GetXmrSeedRequest getXmrSeedRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetXmrPrimaryAddress")]
    Task<GetXmrPrimaryAddressReply> GetXmrPrimaryAddressAsync(GetXmrPrimaryAddressRequest getXmrPrimaryAddressRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetXmrNewSubaddress")]
    Task<GetXmrNewSubaddressReply> GetXmrNewSubaddressAsync(GetXmrNewSubaddressRequest getXmrNewSubaddress, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetXmrTxs")]
    Task<GetXmrTxsReply> GetXmrTxsAsync(GetXmrTxsRequest getXmrTxsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CreateXmrTx")]
    Task<CreateXmrTxReply> CreateXmrTxAsync(CreateXmrTxRequest createXmrTxRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CreateXmrSweepTxs")]
    Task<CreateXmrSweepTxsReply> CreateXmrSweepTxsAsync(CreateXmrSweepTxsRequest createXmrSweepTxsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "RelayXmrTxs")]
    Task<RelayXmrTxsReply> RelayXmrTxsAsync(RelayXmrTxsRequest relayXmrTxsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetAddressBalance")]
    Task<GetAddressBalanceReply> GetAddressBalanceAsync(GetAddressBalanceRequest getAddressBalanceRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetFundingAddresses")]
    Task<GetFundingAddressesReply> GetFundingAddressesAsync(GetFundingAddressesRequest getFundingAddressesRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "SetWalletPassword")]
    Task<SetWalletPasswordReply> SetWalletPasswordAsync(SetWalletPasswordRequest setWalletPasswordRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "RemoveWalletPassword")]
    Task<RemoveWalletPasswordReply> RemoveWalletPasswordAsync(RemoveWalletPasswordRequest removeWalletPasswordRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "LockWallet")]
    Task<LockWalletReply> LockWalletAsync(LockWalletRequest lockWalletRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "UnlockWallet")]
    Task<UnlockWalletReply> UnlockWalletAsync(UnlockWalletRequest unlockWalletRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetHeight")]
    Task<GetWalletHeightReply> GetHeightAsync(GetWalletHeightRequest getWalletHeightRequest, CancellationToken cancellationToken = default);
}
