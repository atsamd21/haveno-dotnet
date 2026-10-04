using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.XmrNode")]
internal interface IHavenoXmrNodeClient
{
    [OperationContract(Name = "IsXmrNodeOnline")]
    public IsXmrNodeOnlineReply IsXmrNodeOnline(IsXmrNodeOnlineRequest isXmrNodeOnlineRequest);
    [OperationContract(Name = "GetXmrNodeSettings")]
    public GetXmrNodeSettingsReply GetXmrNodeSettings(GetXmrNodeSettingsRequest getXmrNodeSettingsRequest);
    [OperationContract(Name = "StartXmrNodeSettings")]
    public StartXmrNodeReply StartXmrNodeSettings(StartXmrNodeRequest startXmrNodeRequest);
    [OperationContract(Name = "StopXmrNodeSettings")]
    public StopXmrNodeReply StopXmrNodeSettings(StopXmrNodeRequest stopXmrNodeRequest);
}
