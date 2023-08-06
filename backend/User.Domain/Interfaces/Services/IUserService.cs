using Users.Domain.Dtos;

namespace Users.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
    }
}
