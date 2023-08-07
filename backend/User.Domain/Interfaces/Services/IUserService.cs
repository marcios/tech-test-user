using Users.Domain.Dtos;

namespace Users.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();

        Task<ResultDto<UserDto>> AddUser(UserDto userDto);
        Task<ResultDto<UserDto>> UpdateUser(UserDto userDto);
        Task<ResultDto<bool>> RemoveUserAsync(int userId);
    }
}
