using Users.Domain.Dtos;
using Users.Domain.Entities;

namespace Users.Domain.ExtensionMethods
{
    public static class UserMaps
    {
        public static UserDto ToDto(this User user)
        {
            var dto = new UserDto
            {

                Id = user.Id,
                BirthDate = string.Format("{0:yyyy-MM-dd}", user.BirthDate),
                Email = user.Email,
                LastName = user.LastName,
                Name = user.Name,
                Scholarity = user.Scholarity != null ? user.Scholarity?.Description : string.Empty,
                ScholarityId = user.ScholarityId,
                SchoolHistoryId = user.SchoolHistoryId,


            };

            if (user.SchoolHistory != null)
            {
                dto.SchoolHistoryName = user.SchoolHistory.Name;
                dto.SchoolHistoryFormat = user.SchoolHistory.Format;

            }

            return dto;
        }
    }
}
