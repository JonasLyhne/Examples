using System.Collections.Generic;
using System.Threading.Tasks;
using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces.Extensions;

namespace Co2Operation.GraphQL.DataAccess.Repositories.Interfaces
{
    public interface ICarRepository : IRepository<Car>, IGetListByUserId<Car>
    {
        
    }
}