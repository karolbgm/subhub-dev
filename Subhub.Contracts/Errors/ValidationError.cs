namespace Subhub.Contracts.Errors;

public class ValidationError
{
    public string Property { get; set; }
    public string ErrorMessage { get; set; }

}
//encapsulated error, so when I used swagger, I could see the Property and error displayed