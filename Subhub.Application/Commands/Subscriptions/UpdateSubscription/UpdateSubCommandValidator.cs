using FluentValidation;
using Subhub.Domain.Entities;
namespace Subhub.Application.Commands.Subscriptions.UpdateSubscription;

public class UpdateSubCommandValidator : AbstractValidator<UpdateSubCommand>
{
    private readonly List<string> CategoryWords = new List<string> { "Entertainment", "Utilities", "Health & Fitness", "Shopping & Lifestyle", "Business", "Other" };
    private readonly List<string> TypeWords = new List<string> { "Streaming", "Membership", "Service", "Product", "License", "Other" };
    public UpdateSubCommandValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage($"{nameof(Subscription.Id)} can't be empty");

        RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage($"{nameof(Subscription.Name)} can't be empty")
        .MaximumLength(30)
        .WithMessage($"{nameof(Subscription.Name)} can't be longer than 30 characters");

        RuleFor(x => x.Category)
        .NotEmpty()
        .WithMessage($"{nameof(Subscription.Category)} can't be empty")
        .Must(BeInCategoryWords)
        .WithMessage("Please type one of the categories: Entertainment, Utilities, Health & Fitness, Shopping & Lifestyle, Business or Other");

        RuleFor(x => x.Type)
        .NotEmpty()
        .WithMessage($"{nameof(Subscription.Type)} can't be empty")
        .Must(BeInTypeWords)
        .WithMessage("Please type one of the categories: Streaming, Membership, Service, Product, License or Other");

        RuleFor(x => x.Cost)
        .GreaterThanOrEqualTo(0)
        .WithMessage("Please enter a number equal or greater than 0");

        RuleFor(x => x.Period)
        .InclusiveBetween(1, 12)
        .WithMessage("Please enter a number between 1 and 12 (months)");
    }

    private bool BeInCategoryWords(string word)
    {
        return CategoryWords.Contains(word);
    }
    private bool BeInTypeWords(string word)
    {
        return TypeWords.Contains(word);
    }
}