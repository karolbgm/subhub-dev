using MediatR;
namespace Subhub.Application.Commands.Subscriptions.CreateSubscription;

public record CreateSubCommand(string Name, string Category, string Type, int Cost, DateTime PaymentDate, int Period, bool IsActive) : IRequest<int>;
