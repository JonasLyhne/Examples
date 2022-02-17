using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Co2Operation.GraphQL.DataAccess.Repositories
{
    public class CarRepository : EfRepository<DbContext, Car>, ICarRepository
    {
        private readonly DbContext context;

        public CarRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IList<Car>> GetListByUserId(int userId)
        {
            return await context.Set<Car>().Where(c => c.UserId == userId).ToListAsync();
        }
    }
}