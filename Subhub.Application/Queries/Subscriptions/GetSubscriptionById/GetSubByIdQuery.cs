using MediatR;
using Subhub.Contracts.Responses;

namespace Subhub.Application.Queries.Subscriptions.GetSubscriptionById;

public record GetSubByIdQuery(int Id) : IRequest<GetSubByIdResponse>;
 //GetSubByIdQuery represents a query request to retrieve a subscription by its ID, and it utilizes MediatR to implement the mediator pattern for handling communication between different parts of the application.