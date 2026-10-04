using Haveno.Api.Models;
using Haveno.Api.Models.Converters;
using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using Haveno.Proto.Models.Requests;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IXmrNodeService
{
    Task AddConnectionAsync(UrlConnection urlConnection, CancellationToken cancellationToken = default);
    Task RemoveConnectionAsync(string url, CancellationToken cancellationToken = default);
    Task<UrlConnection> GetConnectionAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<UrlConnection>> GetConnectionsAsync(CancellationToken cancellationToken = default);
    Task SetConnectionAsync(string url, string username, string password, int priority, CancellationToken cancellationToken = default);
    Task<UrlConnection> CheckConnectionAsync(CancellationToken cancellationToken = default);
    Task<UrlConnection> GetBestConnectionAsync(CancellationToken cancellationToken = default);
    Task SetAutoSwitchAsync(bool autoSwitch, CancellationToken cancellationToken = default);
    Task<bool> GetAutoSwitchAsync(CancellationToken cancellationToken = default);
}

public sealed class XmrNodeService : IXmrNodeService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoXmrConnectionsClient _havenoXmrConnectionsClient;

    public XmrNodeService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoXmrConnectionsClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoXmrConnectionsClient>();
    }

    public async Task AddConnectionAsync(UrlConnection urlConnection, CancellationToken cancellationToken = default)
    {
        await _havenoXmrConnectionsClient.AddConnectionAsync(new AddConnectionRequest
        {
            Connection = urlConnection.Convert()
        }, 
        cancellationToken);
    }

    public async Task<UrlConnection> CheckConnectionAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoXmrConnectionsClient.CheckConnectionAsync(
            new CheckConnectionRequest(), 
            cancellationToken);

        return response.Connection.Convert();
    }

    public async Task<bool> GetAutoSwitchAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoXmrConnectionsClient.GetAutoSwitchAsync(
            new GetAutoSwitchRequest(), 
            cancellationToken);

        return response.AutoSwitch;
    }

    public async Task<UrlConnection> GetBestConnectionAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoXmrConnectionsClient.GetBestConnectionAsync(
            new GetBestConnectionRequest(), 
            cancellationToken);

        return response.Connection.Convert();
    }

    public async Task<UrlConnection> GetConnectionAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoXmrConnectionsClient.GetConnectionAsync(
            new GetConnectionRequest(),
            cancellationToken);

        return response.Connection.Convert();
    }

    public async Task<IEnumerable<UrlConnection>> GetConnectionsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoXmrConnectionsClient.GetConnectionsAsync(
            new GetConnectionsRequest(),
            cancellationToken);

        return response.Connections.Select(x => x.Convert());
    }

    public async Task RemoveConnectionAsync(string url, CancellationToken cancellationToken = default)
    {
        await _havenoXmrConnectionsClient.RemoveConnectionAsync(new RemoveConnectionRequest
        {
            Url = url
        },
        cancellationToken);
    }

    public async Task SetAutoSwitchAsync(bool autoSwitch, CancellationToken cancellationToken = default)
    {
        await _havenoXmrConnectionsClient.SetAutoSwitchAsync(new SetAutoSwitchRequest
        {
            AutoSwitch = autoSwitch
        },
        cancellationToken);
    }

    public async Task SetConnectionAsync(string url, string username, string password, int priority, CancellationToken cancellationToken = default)
    {
        await _havenoXmrConnectionsClient.SetConnectionAsync(new SetConnectionRequest
        {
            Url = url,
            Connection = new Proto.Models.UrlConnection
            {
                Username = username,
                Password = password,
                Url = url,
                Priority = priority
            }
        },
        cancellationToken);
    }
}