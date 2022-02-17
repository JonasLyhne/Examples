using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces.Extensions;

namespace Co2Operation.GraphQL.DataAccess.Repositories.Interfaces
{
    public interface ITripRepository : IRepository<Trip>, IGetListByUserId<Trip>
    {
        
    }
}