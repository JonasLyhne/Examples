using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces.Extensions;

namespace Co2Operation.GraphQL.DataAccess.Repositories.Interfaces
{
    public interface ICarbonHistoryRepository : IRepository<CarbonHistroy>, IGetListByUserId<CarbonHistroy>
    {
        
    }
}