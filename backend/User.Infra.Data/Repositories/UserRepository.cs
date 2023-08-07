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

        public async Task AddAsync(User user)
        {
            this._context.Users.Add(user);
            await this._context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var user = await this._context.Users
                    .Include(x => x.Scholarity)
                    .Include(x => x.SchoolHistory)
                    .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("Usuário não existe");
            }


            if (user.SchoolHistory != null)
                this._context.Remove(user.SchoolHistory);


            this._context.Remove(user);
            this._context.SaveChanges();


        }

        public async Task<User> FindByEmail(string email)
        {
            return await this._context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Address.Equals(email));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this._context.Users
                .Include(x => x.Scholarity)
                .Include(x => x.SchoolHistory)
                .AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await this._context.Users
                      .Include(x => x.Scholarity)
                      .Include(x => x.SchoolHistory)
                      .FirstOrDefaultAsync(x=>x.Id == id);
        }

  

        public async Task UpdateAsync(User user)
        {
           this._context.Update(user);
           await this._context.SaveChangesAsync();
        }
    }
}
