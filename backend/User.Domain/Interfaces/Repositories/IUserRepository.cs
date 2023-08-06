using Users.Domain.Entities;

namespace Users.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
