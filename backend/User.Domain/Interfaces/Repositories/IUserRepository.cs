using Users.Domain.Entities;

namespace Users.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> FindByEmail(string email);
        Task AddAsync(User user);  
        Task Delete(int id);
        Task<User> GetByIdAsync(int id);
        Task UpdateAsync(User user);
    }
}
