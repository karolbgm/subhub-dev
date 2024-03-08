using FluentValidation;
using FluentValidation.Validators;
using MediatR;
using Subhub.Contracts.Errors;
using Subhub.Contracts.Exceptions;

//behavior for validating data before it's saved to the database.

namespace Subhub.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

        var failures = validationResults.Where(x => !x.IsValid)
        .SelectMany(x => x.Errors)
        .Select(x => new ValidationError
        {
            Property = x.PropertyName,
            ErrorMessage = x.ErrorMessage
        }).ToList();

        if (failures.Any())
        {
            throw new CustomValidationException(failures);        
        }

        var response = await next();
        return response;
    }

}
