using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Scholarity> GetByIdAsync(int id)
        {
            return await this._context.Scholarities.FindAsync(id);
        }
    }
}
