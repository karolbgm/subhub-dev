using Mapster;
using Subhub.Contracts.Responses;
using Subhub.Domain.Entities;

namespace Subhub.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Subscription>, GetSubsResponse>.NewConfig()
            .Map(dest => dest.SubscriptionsDtos, src => src);

        TypeAdapterConfig<Subscription, GetSubByIdResponse>.NewConfig()
            .Map(dest => dest.SubscriptionDto, src => src);
    }
}

//MappingConfig class configures mappings between different types of objects using the Mapster library. It defines mappings between Subscription objects and response objects (GetSubsResponse, GetSubByIdResponse) used in the application. This helps ensure that data can be effectively transferred and transformed between different parts of the application.