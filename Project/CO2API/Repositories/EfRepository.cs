using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CO2API.Interfaces;

namespace CO2API.Repositories
{
    public abstract class EfRepository<TContext, TEntity> : IRepository<TEntity> 
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext context;

        public EfRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}