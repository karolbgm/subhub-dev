using Subhub.Contracts.Dtos;

namespace Subhub.Contracts.Responses;

public record GetSubByIdResponse(SubscriptionDto SubscriptionDto);

//represents a response to a request for retrieving a subscription by its ID.
//he SubscriptionDto represents a Data Transfer Object (DTO) containing information about a subscription.