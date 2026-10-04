using Grpc.Net.Client;
using Haveno.Exceptions;

namespace Haveno.Api.Singletons;

/// <summary>
/// Manages a single GrpcChannel. 
/// </summary>
public sealed class GrpcChannelSingleton
{
    public GrpcChannel Channel { get { return field ?? throw new HavenoException("CreateChannel must be called before using Channel."); } private set; }

    public GrpcChannelSingleton()
    {

    }

    /// <summary>
    /// Creates the grpc channel. If called again, the channel will be recreated using the new settings.
    /// </summary>
    /// <param name="host"></param>
    /// <param name="password"></param>
    /// <param name="httpClient"></param>
    public void CreateChannel(string host, string password, HttpClient? httpClient = default)
    {
        httpClient ??= new HttpClient(new SocketsHttpHandler())
        {
            DefaultRequestVersion = new Version(2, 0),
            DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact,
            // This should not be the default
            Timeout = Timeout.InfiniteTimeSpan
        };

        if (!httpClient.DefaultRequestHeaders.TryGetValues("password", out var _))
        {
            httpClient.DefaultRequestHeaders.Add("password", password);
        }

        var channelOptions = new GrpcChannelOptions
        {
            HttpClient = httpClient,
            MaxReceiveMessageSize = null,
            MaxSendMessageSize = null,
            DisposeHttpClient = true
        };

        Channel = GrpcChannel.ForAddress(host, channelOptions);
    }
}
