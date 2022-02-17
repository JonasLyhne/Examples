using System.Collections.Generic;
using System.Threading.Tasks;

namespace Co2Operation.GraphQL.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Generic Repository interface to generate EntityModel Repositories with generic Entity methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}