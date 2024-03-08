using FluentValidation;
using Subhub.Domain.Entities;
namespace Subhub.Application.Queries.Subscriptions.GetSubscriptionById;

public class GetSubByIdQueryValidator : AbstractValidator<GetSubByIdQuery>
{
    public GetSubByIdQueryValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage($"{nameof(Subscription.Id)} can't be empty");
    }
}
