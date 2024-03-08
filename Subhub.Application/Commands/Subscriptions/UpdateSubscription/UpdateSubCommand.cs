using MediatR;
namespace Subhub.Application.Commands.Subscriptions.UpdateSubscription;

public record UpdateSubCommand(int Id, string Name, string Category, string Type, int Cost, DateTime PaymentDate, int Period, bool IsActive) : IRequest<Unit>;

