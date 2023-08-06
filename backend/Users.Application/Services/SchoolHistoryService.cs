using Users.Domain.Dtos;
using Users.Domain.ExtensionMethods;
using Users.Domain.Interfaces.Repositories;
using Users.Domain.Interfaces.Services;

namespace Users.Application.Services
{
    public class SchoolHistoryService : ISchoolHistoryService
    {
        private readonly IUserRepository _userRepository;
        public SchoolHistoryService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<ResultDto<SchoolHistoryDto>> GetByAsync(int userid, int schoolHistoryId)
        {
            var result = new ResultDto<SchoolHistoryDto>();

            var user = await this._userRepository.GetByIdAsync(userid);


            if(user==null)
                result.Errors.Add("Usuário não encontrado");


            if (user.SchoolHistory != null && user.SchoolHistory.Id == schoolHistoryId)
            {
                result.Data = user.SchoolHistory.ToDto();
            }
            else
            {
                result.Errors.Add("Não existe histórico informado para este usuário");
            }

            return result;



        }
    }
}
