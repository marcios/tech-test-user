using Users.Domain.Dtos;

namespace Users.Domain.Interfaces.Services
{
    public interface ISchoolHistoryService
    {
        Task<ResultDto<SchoolHistoryDto>> GetByAsync(int userid, int schoolHistoryId);
    }
}