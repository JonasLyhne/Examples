using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Co2Operation.GraphQL.DataAccess.Repositories
{
    public class UserRepository : EfRepository<DbContext, User>, IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}