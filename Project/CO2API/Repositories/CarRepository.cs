using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CO2API.Interfaces;

namespace CO2API.Repositories
{
    public class CarRepository : EfRepository<DbContext, Car>
    {
        private readonly DbContext _context;

        public CarRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}