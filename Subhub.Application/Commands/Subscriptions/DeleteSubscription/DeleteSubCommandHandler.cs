using MediatR;
using Microsoft.EntityFrameworkCore;
using Subhub.Domain.Entities;
using Subhub.Contracts.Exceptions;
using Subhub.Infrastructure;

namespace Subhub.Application.Commands.Subscriptions.DeleteSubscription;

public class DeleteSubCommandHandler : IRequestHandler<DeleteSubCommand, Unit>
{
    private readonly SubscriptionsDbContext _subscriptionsDbContext;

    public DeleteSubCommandHandler(SubscriptionsDbContext subscriptionsDbContext)
    {
        _subscriptionsDbContext = subscriptionsDbContext;
    }

    public async Task<Unit> Handle(DeleteSubCommand request, CancellationToken cancellationToken)
    {
        var subscriptionToDelete = await _subscriptionsDbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (subscriptionToDelete is null)
        {
            throw new NotFoundException($"{nameof(Subscription)} with {nameof(Subscription.Id)} : {request.Id}" + $"was not found");
        }

        _subscriptionsDbContext.Subscriptions.Remove(subscriptionToDelete);
        await _subscriptionsDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
