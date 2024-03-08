using Subhub.Contracts.Errors;

namespace Subhub.Contracts.Exceptions;

//This class inherits from the base .NET Exception class, representing an exception that occurs due to validation errors.

public class CustomValidationException : Exception
{
    //It has a constructor that accepts a list of ValidationError objects, which are the validation errors associated with this exception.
    //The ValidationErrors property provides access to the list of validation errors.

    public CustomValidationException(List<ValidationError> validationErrors)
    {
        ValidationErrors = validationErrors;
    }
    public List<ValidationError> ValidationErrors {get; set;}
}

