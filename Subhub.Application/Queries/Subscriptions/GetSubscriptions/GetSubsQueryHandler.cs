using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Subhub.Contracts.Responses;
using Subhub.Infrastructure;

namespace Subhub.Application.Queries.Subscriptions.GetSubscriptions;

//IRequestHandler interface. This interface is provided by MediatR and specifies that the class can handle requests of type GetSubsQuery and return responses of type GetSubsResponse.
public class GetSubsQueryHandler : IRequestHandler<GetSubsQuery, GetSubsResponse>
{
    private readonly SubscriptionsDbContext _subscriptionsDbContext;
//constructor below is used for dependency injection to provide the SubscriptionsDbContext instance to the GetSubsQueryHandler class.
    public GetSubsQueryHandler(SubscriptionsDbContext subscriptionsDbContext)
    {
        _subscriptionsDbContext = subscriptionsDbContext;
    }
//Handle method - which is required by the IRequestHandler interface. This method is called when a GetSubsQuery request is sent, and it is responsible for handling the request and returning a GetSubsResponse.
    public async Task<GetSubsResponse> Handle(GetSubsQuery request, CancellationToken cancellationToken)
    {
        var subscriptions = await _subscriptionsDbContext.Subscriptions.ToListAsync(cancellationToken);
       
       return subscriptions.Adapt<GetSubsResponse>();
    }
    

}

//GetSubsQueryHandler class is responsible for handling requests to retrieve subscriptions from the database. It uses Entity Framework Core to query the database, Mapster to adapt the query result into a response object, and MediatR to handle the communication between different parts of the application.

