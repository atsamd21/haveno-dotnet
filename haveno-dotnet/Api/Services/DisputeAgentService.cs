using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IDisputeAgentService
{
    Task RegisterDisputeAgentAsync(string disputeAgentType, string registrationKey, CancellationToken cancellationToken = default);
    Task UnregisterDisputeAgentAsync(string disputeAgentType, CancellationToken cancellationToken = default);
}

public sealed class DisputeAgentService : IDisputeAgentService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoDisputeAgentsClient _havenoDisputeAgentsClient;

    public DisputeAgentService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoDisputeAgentsClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoDisputeAgentsClient>();
    }

    public async Task RegisterDisputeAgentAsync(string disputeAgentType, string registrationKey, CancellationToken cancellationToken = default)
    {
        await _havenoDisputeAgentsClient.RegisterDisputeAgentAsync(
            new Proto.Models.Requests.RegisterDisputeAgentRequest
            {
                DisputeAgentType = disputeAgentType,
                RegistrationKey = registrationKey
            }, 
            cancellationToken);
    }

    public async Task UnregisterDisputeAgentAsync(string disputeAgentType, CancellationToken cancellationToken = default)
    {
        await _havenoDisputeAgentsClient.UnregisterDisputeAgentAsync(
            new Proto.Models.Requests.UnregisterDisputeAgentRequest
            {
                DisputeAgentType = disputeAgentType
            }, 
            cancellationToken);
    }
}
