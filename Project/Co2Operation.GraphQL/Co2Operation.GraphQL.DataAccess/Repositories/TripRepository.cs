using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Co2Operation.GraphQL.DataAccess.Repositories
{
    public class TripRepository : EfRepository<DbContext, Trip>, ITripRepository
    {
        private readonly DbContext context;

        public TripRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IList<Trip>> GetListByUserId(int userId)
        {
            return await this.context.Set<Trip>().Where(t => t.UserId == userId).ToListAsync();
        }
    }
}