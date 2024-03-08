using MediatR;

namespace Subhub.Application.Commands.Subscriptions.DeleteSubscription;

public record DeleteSubCommand(int Id) : IRequest<Unit>;

