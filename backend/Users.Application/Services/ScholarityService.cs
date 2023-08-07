using Users.Domain.Entities;
using Users.Domain.Interfaces.Repositories;
using Users.Domain.Interfaces.Services;

namespace Users.Application.Services
{
    public class ScholarityService : IScholarityService
    {

        private readonly IScholarityRepository _scholarityRepository;
        public ScholarityService(IScholarityRepository scholarityRepository = null)
        {
            this._scholarityRepository = scholarityRepository;
        }
        public async Task<IEnumerable<Scholarity>> GetAllAsync()
        {
            return await this._scholarityRepository.GetAllAsync();
        }
    }
}
