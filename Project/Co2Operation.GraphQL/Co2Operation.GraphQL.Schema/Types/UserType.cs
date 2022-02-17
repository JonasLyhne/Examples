using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using HotChocolate.Types;

namespace Co2Operation.GraphQL.Schema.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(u => u.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(u => u.TotalFootPrint)
                .Type<DecimalType>();

            descriptor.Field(u => u.Car)
                .Type<ListType<CarType>>()
                .Name("cars")
                .Resolver(context => context
                    .Service<ICarRepository>()
                    .GetListByUserId(context.Parent<User>().Id));

            descriptor.Field(u => u.Trip)
                .Type<ListType<TripType>>()
                .Name("trips")
                .Resolver(context => context
                    .Service<ITripRepository>()
                    .GetListByUserId(context.Parent<User>().Id));

            descriptor.Field(u => u.CarbonHistroy)
                .Type<ListType<CarbonHistoryType>>()
                .Resolver(context => context
                    .Service<ICarbonHistoryRepository>()
                    .GetListByUserId(context.Parent<User>().Id));
            
            descriptor.Field(u => u.LoginInfo).Ignore();

        }
    }
}