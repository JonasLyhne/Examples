using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Co2Operation.GraphQL.DataAccess.Repositories
{
    public class CarbonHistoryRepository : EfRepository<DbContext, CarbonHistroy>, ICarbonHistoryRepository
    {
        private readonly DbContext context;

        public CarbonHistoryRepository(DbContext context) : base(context)
        {
            this.context = context;
        }
        
        public async Task<IList<CarbonHistroy>> GetListByUserId(int userId)
        {
            return await context.Set<CarbonHistroy>().Where(c => c.UserId == userId).ToListAsync();
        }
    }
}