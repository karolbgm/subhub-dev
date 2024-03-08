namespace Subhub.Contracts.Exceptions;

//to indicate the subscription was not found
public class NotFoundException(string message) : Exception(message);