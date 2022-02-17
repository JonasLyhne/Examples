using Co2Operation.GraphQL.DataAccess.Models;
using HotChocolate.Types;

namespace Co2Operation.GraphQL.Schema.Types
{
    public class TransportMethodsType : ObjectType<TransportMethods>
    {
        protected override void Configure(IObjectTypeDescriptor<TransportMethods> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Name)
                .Type<StringType>();

            descriptor.Field(t => t.AverageCo2)
                .Type<DecimalType>();
            
            descriptor.Field(t => t.Trip).Ignore(); // We won't query Trips on TransportMethods, so ignore this field.
        }
    }
}