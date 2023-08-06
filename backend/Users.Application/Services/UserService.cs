using Users.Domain.Dtos;
using Users.Domain.ExtensionMethods;
using Users.Domain.Interfaces.Repositories;
using Users.Domain.Interfaces.Services;

namespace Users.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await this._userRepository.GetAllAsync();
            return users.Select(user => user.ToDto()).ToList();
        }
    }
}
