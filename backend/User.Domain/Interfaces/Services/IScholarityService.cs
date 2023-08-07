using Users.Domain.Entities;

namespace Users.Domain.Interfaces.Services
{
    public interface IScholarityService
    {
        Task<IEnumerable<Scholarity>> GetAllAsync();
    }
}
