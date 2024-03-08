using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Subhub.Contracts.Exceptions;
using Subhub.Contracts.Responses;
using Subhub.Domain.Entities;
using Subhub.Infrastructure;

namespace Subhub.Application.Queries.Subscriptions.GetSubscriptionById;

public class GetSubByIdQueryHandler : IRequestHandler<GetSubByIdQuery, GetSubByIdResponse>
{
    private readonly SubscriptionsDbContext _subscriptionsDbContext;
    public GetSubByIdQueryHandler(SubscriptionsDbContext subscriptionsDbContext)
    {
        _subscriptionsDbContext = subscriptionsDbContext;
    }
    public async Task<GetSubByIdResponse> Handle(GetSubByIdQuery request, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionsDbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (subscription is null)
        {
            throw new NotFoundException($"{nameof(Subscription)} with {nameof(Subscription.Id)} : {request.Id}" + $"was not found");
        }
        return subscription.Adapt<GetSubByIdResponse>();
    }


}