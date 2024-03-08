namespace Subhub.Contracts.Requests.Subscriptions;

//represents a request to create a new subscription.
public record CreateSubRequest(string Name, string Category, string Type, int Cost, DateTime PaymentDate, int Period, bool IsActive);

//client-side will use these request objects (CreateSubRequest or UpdateSubRequest) to gather the necessary data from the form fields.
// Then, it will send an HTTP POST or PUT request to the appropriate server endpoint