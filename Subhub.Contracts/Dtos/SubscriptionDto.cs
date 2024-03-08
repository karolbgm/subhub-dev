namespace Subhub.Contracts.Dtos;

public record SubscriptionDto(int Id, string Name, string Category, string Type, int Cost, DateTime PaymentDate, int Period, bool IsActive, DateTime CreateDate);

//DTO - Data Transfer Object -  represents subscription-related data and contains properties such as ID, name, category, cost, etc., which correspond to attributes of a subscription. The DTO is designed to be immutable, meaning its properties cannot be modified after creation.
//representation of the subscription data that can be easily transferred between parts of the app