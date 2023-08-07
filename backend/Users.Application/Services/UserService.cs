using Users.Domain.Dtos;
using Users.Domain.ExtensionMethods;
using Users.Domain.Interfaces.Repositories;
using Users.Domain.Interfaces.Services;

namespace Users.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IScholarityRepository _scholarityRepository;

        public UserService(IUserRepository userRepository, IScholarityRepository scholarityRepository)
        {
            _userRepository = userRepository;
            this._scholarityRepository = scholarityRepository;
        }

        public async Task<ResultDto<UserDto>> AddUser(UserDto userDto)
        {
            var result = new ResultDto<UserDto>();
            try
            {
                var exists = await this._userRepository.FindByEmail(userDto.Email);
                if (exists != null)
                {
                    throw new Exception("Já existe um usuário com o e-mail cadastrado");
                }

                var user = userDto.ToEntity();

                if (userDto.ScholarityId.HasValue && userDto.ScholarityId.Value > 0)
                {
                    user.AddScholarity(await this._scholarityRepository.GetByIdAsync(userDto.ScholarityId.Value));
                }


                await this._userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await this._userRepository.GetAllAsync();
            return users.Select(user => user.ToDto()).ToList();
        }

        public async Task<ResultDto<bool>> RemoveUserAsync(int userId)
        {
            var result = new ResultDto<bool>();
            try
            {
                await this._userRepository.DeleteAsync(userId);

            }
            catch (Exception ex)
            {

                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<ResultDto<UserDto>> UpdateUser(UserDto userDto)
        {
            var result = new ResultDto<UserDto>();
            try
            {
                var userExist = await this._userRepository.GetByIdAsync(userDto.Id);

                if (userExist == null)
                    throw new Exception("Usuário não existe");

                if (userExist.SchoolHistory != null)
                    userDto.SchoolHistoryId = userExist.SchoolHistory.Id;

                var user = userDto.ToEntity();

                await ValidateUserEmail(userDto);

                if (userDto.ScholarityId.HasValue)
                {
                    user.AddScholarity(await this._scholarityRepository.GetByIdAsync(userDto.ScholarityId.Value));
                }


                await this._userRepository.UpdateAsync(user);
            }
            catch (Exception ex)
            {

                result.Errors.Add(ex.Message);
            }


            return result;

        }

        private async Task ValidateUserEmail(UserDto userDto)
        {
            //validar se o e-mail informado pertence a outro usuário
            var userExists = await this._userRepository.FindByEmail(userDto.Email);
            if (userExists != null && userExists.Id != userDto.Id)
            {
                throw new Exception("Não é possível atualizar o e-mail, já existe outro usuário como mesmo e-mail");
            }
        }
    }
}
