using System;
using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using HotChocolate.Types;

namespace Co2Operation.GraphQL.Schema.Types
{
    public class TripType : ObjectType<Trip>
    {
        protected override void Configure(IObjectTypeDescriptor<Trip> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.UserId)
                .Type<IntType>();

            descriptor.Field(t => t.StartTime)
                .Type<DateTimeType>();
            
            descriptor.Field(t => t.EndTime)
                .Type<DateTimeType>();
            
            descriptor.Field(t => t.TransportMethodId)
                .Type<IntType>();
            
            descriptor.Field(t => t.Distance)
                .Type<DecimalType>();
            
            descriptor.Field(t => t.TotalCo2)
                .Type<DecimalType>();

            descriptor.Field(t => t.TransportMethod)
                .Type<TransportMethodsType>()
                .Name("transportMethod")
                .Resolver(context =>
                {
                    var transportMethodId = context.Parent<Trip>().TransportMethodId;
                    if (transportMethodId != null)
                        return context
                            .Service<ITransportMethodsRepository>()
                            .Get((int)transportMethodId);
                    return null;
                });
           
            descriptor.Field(t => t.User)  // We won't query this fields on TripType so ignore it.
                .Ignore();
        }
    }
}