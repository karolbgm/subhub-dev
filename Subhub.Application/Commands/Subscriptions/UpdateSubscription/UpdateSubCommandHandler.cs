using MediatR;
using Microsoft.EntityFrameworkCore;
using Subhub.Infrastructure;
using Subhub.Contracts.Exceptions;
using Subhub.Domain.Entities;
namespace Subhub.Application.Commands.Subscriptions.UpdateSubscription;

public class UpdateSubCommandHandler : IRequestHandler<UpdateSubCommand, Unit>
{
    private readonly SubscriptionsDbContext _subscriptionsDbContext;
    public UpdateSubCommandHandler(SubscriptionsDbContext subscriptionsDbContext)
    {
        _subscriptionsDbContext = subscriptionsDbContext;
    }

    public async Task<Unit> Handle(UpdateSubCommand request, CancellationToken cancellationToken)
    {
        var subscriptionToUpdate = await _subscriptionsDbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (subscriptionToUpdate is null)
        {
            throw new NotFoundException($"{nameof(Subscription)} with {nameof(Subscription.Id)} : {request.Id}" + $"was not found");
        }

        subscriptionToUpdate.Name = request.Name;
        subscriptionToUpdate.Category = request.Category;
        subscriptionToUpdate.Type = request.Type;
        subscriptionToUpdate.Cost = request.Cost;
        subscriptionToUpdate.PaymentDate = request.PaymentDate;
        subscriptionToUpdate.Period = request.Period;
        subscriptionToUpdate.IsActive = request.IsActive;

        _subscriptionsDbContext.Subscriptions.Update(subscriptionToUpdate);
        await _subscriptionsDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
