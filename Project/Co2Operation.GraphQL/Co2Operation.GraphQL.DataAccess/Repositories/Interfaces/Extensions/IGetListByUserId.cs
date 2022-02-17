using System.Collections.Generic;
using System.Threading.Tasks;

namespace Co2Operation.GraphQL.DataAccess.Repositories.Interfaces.Extensions
{
    public interface IGetListByUserId<T> where T : class
    {
        Task<IList<T>> GetListByUserId(int userId);
    }
}