using Users.Domain.Dtos;
using Users.Domain.Entities;
using Users.Domain.ValueObjects;

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
                Email = user.Email.Address,
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

        public static User ToEntity(this UserDto user)
        {
            var birthDate = user.BirthDate.ToDateTime();

            if (!birthDate.HasValue)
                birthDate = DateTime.Today;

            var userEntity = new User( user.Id,  user.Name, user.LastName, new Email(user.Email), birthDate.Value);

            if(!string.IsNullOrWhiteSpace(user.SchoolHistoryName))
            {
                userEntity.AddSchoolHistory(user.SchoolHistoryName, user.SchoolHistoryFormat, user.SchoolHistoryFile, user.SchoolHistoryId);
            }

           return userEntity;
        }
    }
}
