using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.Offers")]
internal interface IHavenoOffersClient
{
    [OperationContract(Name = "GetOffer")]
    Task<GetOfferReply> GetOfferAsync(GetOfferRequest getOfferRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetMyOffer")]
    Task<GetMyOfferReply> GetMyOfferAsync(GetMyOfferRequest getMyOfferRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetOffers")]
    Task<GetOffersReply> GetOffersAsync(GetOffersRequest getOffersRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetMyOffers")]
    Task<GetMyOffersReply> GetMyOffersAsync(GetMyOffersRequest getMyOffersRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "PostOffer")]
    Task<PostOfferReply> PostOfferAsync(PostOfferRequest postOfferRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CancelOffer")]
    Task<CancelOfferReply> CancelOfferAsync(CancelOfferRequest cancelOfferRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "EditOffer")]
    Task<EditOfferReply> EditOfferAsync(EditOfferRequest editOfferRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "DeactivateOffer")]
    Task<DeactivateOfferReply> DeactivateOfferAsync(DeactivateOfferRequest deactivateOfferRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "ActivateOffer")]
    Task<ActivateOfferReply> ActivateOfferAsync(ActivateOfferRequest activateOfferRequest, CancellationToken cancellationToken = default);
}
