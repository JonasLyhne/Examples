using Co2Operation.GraphQL.DataAccess.Models;
using HotChocolate.Types;

namespace Co2Operation.GraphQL.Schema.Types
{
    public class CarType : ObjectType<Car>
    {
        protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
            
            descriptor.Field(c => c.AverageCo2)
                .Type<NonNullType<IntType>>();
            
            descriptor.Field(c => c.Model)
                .Type<StringType>();
            
            descriptor.Field(c => c.UserId)
                .Type<NonNullType<IntType>>();

            descriptor.Field(c => c.User).Ignore();
        }
    }
}