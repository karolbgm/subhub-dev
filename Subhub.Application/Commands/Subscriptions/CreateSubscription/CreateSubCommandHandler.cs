using MediatR;
using Subhub.Domain.Entities;
using Subhub.Infrastructure;
namespace Subhub.Application.Commands.Subscriptions.CreateSubscription;

public class CreateSubCommandHandler : IRequestHandler<CreateSubCommand, int>
{
    private readonly SubscriptionsDbContext _subscriptionsDbContext;
    public CreateSubCommandHandler(SubscriptionsDbContext subscriptionsDbContext)
    {
        _subscriptionsDbContext = subscriptionsDbContext;
    }

    public async Task<int> Handle(CreateSubCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            Name = request.Name,
            Category = request.Category,
            Type = request.Type,
            Cost = request.Cost,
            PaymentDate = request.PaymentDate,
            Period = request.Period,
            IsActive = request.IsActive,
            CreateDate = DateTime.Now.ToUniversalTime()
        };
        
        await _subscriptionsDbContext.Subscriptions.AddAsync(subscription, cancellationToken);
        await _subscriptionsDbContext.SaveChangesAsync(cancellationToken);
        
        return subscription.Id;
    }
}
