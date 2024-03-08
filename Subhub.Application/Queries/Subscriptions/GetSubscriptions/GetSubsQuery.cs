using MediatR;
using Subhub.Contracts.Responses;
namespace Subhub.Application.Queries.Subscriptions.GetSubscriptions;

public record GetSubsQuery() : IRequest<GetSubsResponse>;