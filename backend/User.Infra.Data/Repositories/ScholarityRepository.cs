using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Repositories;
using Users.Infra.Data.Context;

namespace Users.Infra.Data.Repositories
{
    public class ScholarityRepository : IScholarityRepository
    {
        private readonly UserDbContext _context;

        public ScholarityRepository(UserDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Scholarity>> GetAllAsync()
        {
            return await this._context.Scholarities.AsNoTracking().ToListAsync();
        }

        public async Task<Scholarity> GetByIdAsync(int id)
        {
            return await this._context.Scholarities.FindAsync(id);
        }
    }
}
