using Subhub.Contracts.Dtos;
namespace Subhub.Contracts.Responses;

public record GetSubsResponse(List<SubscriptionDto> SubscriptionsDtos);
