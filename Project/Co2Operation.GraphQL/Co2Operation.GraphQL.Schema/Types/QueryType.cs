using Co2Operation.GraphQL.Schema.Queries;
using HotChocolate.Types;

namespace Co2Operation.GraphQL.Schema.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetCars(default))
                .Type<NonNullType<ListType<NonNullType<CarType>>>>().Description("Query for getting all cars.");
            
            descriptor.Field(q => q.GetCarById(default, default))
                .Type<NonNullType<CarType>>().Description("Query for getting car by car id");

            descriptor.Field(q => q.GetCarsByUserId(default, default))
                .Type<ListType<CarType>>();

            descriptor.Field(q => q.GetUsers(default))
                .Type<ListType<UserType>>();
            
            descriptor.Field(q => q.GetUserById(default, default))
                .Type<UserType>();
            
            descriptor.Field(q => q.GetTrips(default))
                .Type<ListType<TripType>>();
            
            descriptor.Field(q => q.GetTripsByUserId(default, default))
                .Type<NonNullType<TripType>>();
            
            descriptor.Field(q => q.GetTripById(default, default))
                .Type<NonNullType<TripType>>();
            
            descriptor.Field(q => q.GetCarbonHistories(default))
                .Type<ListType<CarbonHistoryType>>();

            descriptor.Field(q => q.GetCarbonHistoriesByUserId(default, default))
                .Type<NonNullType<CarbonHistoryType>>();
            
            descriptor.Field(q => q.GetTransportMethods(default))
                .Type<ListType<TransportMethodsType>>();
            
            descriptor.Field(q => q.GetTransportMethodById(default, default))
                .Type<TransportMethodsType>();
        }
    }
}