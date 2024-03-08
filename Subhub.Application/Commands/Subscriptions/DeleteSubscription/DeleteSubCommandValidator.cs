using FluentValidation;
using Subhub.Domain.Entities;
namespace Subhub.Application.Commands.Subscriptions.DeleteSubscription;

public class DeleteSubCommandValidator : AbstractValidator<DeleteSubCommand>
{
    public DeleteSubCommandValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage($"{nameof(Subscription.Id)} can't be empty");
    }
}
//id can't be empty





        