using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Co2Operation.GraphQL.DataAccess.Repositories
{
    public class TransportMethodsRepository : EfRepository<DbContext, TransportMethods>, ITransportMethodsRepository
    {
        private readonly DbContext _context;

        public TransportMethodsRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}