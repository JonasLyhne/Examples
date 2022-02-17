using System.Collections.Generic;
using System.Threading.Tasks;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Co2Operation.GraphQL.DataAccess.Repositories
{
    /// <summary>
    /// Abstract Entity Framework repository with realisation of th EF methods.
    /// Other Repositories that handle entity models 'must' use this.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract class EfRepository<TContext, T> : IRepository<T>
        where T : class
        where TContext : DbContext
    {
        private readonly TContext context;

        public EfRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<IList<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}