using MediatR;
using Subhub.Contracts.Requests.Subscriptions;
using Subhub.Application.Queries.Subscriptions.GetSubscriptionById;
using Subhub.Application.Queries.Subscriptions.GetSubscriptions;
using Subhub.Application.Commands.Subscriptions.CreateSubscription;
using Subhub.Application.Commands.Subscriptions.UpdateSubscription;
using Subhub.Application.Commands.Subscriptions.DeleteSubscription;

namespace Subhub.Presentation.Modules;

public static class SubscriptionsModule
{
    public static void AddSubscriptionsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/subscriptions", async (IMediator mediator, CancellationToken ct) =>
        {
            var subscriptions = await mediator.Send(new GetSubsQuery(), ct);
            return Results.Ok(subscriptions);
        }).WithTags("Subscriptions");

        app.MapGet("api/subscriptions/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var subscription = await mediator.Send(new GetSubByIdQuery(id), ct);
            return Results.Ok(subscription);
        }).WithTags("Subscriptions");

        app.MapPost("/api/subscriptions", async (IMediator mediator, CreateSubRequest createSubRequest, CancellationToken ct) =>
        {
            var command = new CreateSubCommand(createSubRequest.Name, createSubRequest.Category, createSubRequest.Type, createSubRequest.Cost, createSubRequest.PaymentDate, createSubRequest.Period, createSubRequest.IsActive);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Subscriptions");

        app.MapPut("/api/subscriptions/{id}", async (IMediator mediator, int id, UpdateSubRequest updateSubRequest, CancellationToken ct) =>
        {
            var command = new UpdateSubCommand(id, updateSubRequest.Name, updateSubRequest.Category, updateSubRequest.Type, updateSubRequest.Cost, updateSubRequest.PaymentDate, updateSubRequest.Period, updateSubRequest.IsActive);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Subscriptions");

         app.MapDelete("api/subscriptions/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var command = new DeleteSubCommand(id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Subscriptions");

    }

}



