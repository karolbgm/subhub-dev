namespace Subhub.Contracts.Requests.Subscriptions;

//represents a request to update a subscription.
public record UpdateSubRequest(string Name, string Category, string Type, int Cost, DateTime PaymentDate, int Period, bool IsActive);

