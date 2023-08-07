using Users.Domain.Entities;

namespace Users.Domain.Interfaces.Repositories
{
    public interface IScholarityRepository
    {
        Task<Scholarity> GetByIdAsync(int id);
        Task<IEnumerable<Scholarity>> GetAllAsync();
    }
}
