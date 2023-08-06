using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Repositories;
using Users.Infra.Data.Context;

namespace Users.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

     
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this._context.Users
                .Include(x=>x.Scholarity)
                .Include(x=>x.SchoolHistory)
                .AsNoTracking().ToListAsync();
        }
    }
}
