using Co2Operation.GraphQL.DataAccess.Models;
using HotChocolate.Types;

namespace Co2Operation.GraphQL.Schema.Types
{
    public class CarbonHistoryType : ObjectType<CarbonHistroy>
    {
        protected override void Configure(IObjectTypeDescriptor<CarbonHistroy> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(c => c.UserId)
                .Type<NonNullType<IntType>>();

            descriptor.Field(c => c.Day)
                .Type<DateType>();

            descriptor.Field(c => c.TotalFootPrint)
                .Type<DecimalType>();

            descriptor.Field(c => c.User).Ignore(); // We won't query users on carbon history, so ignore this field.
        }
    }
}