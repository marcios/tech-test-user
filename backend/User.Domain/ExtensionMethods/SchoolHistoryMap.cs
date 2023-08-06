using Users.Domain.Dtos;
using Users.Domain.Entities;

namespace Users.Domain.ExtensionMethods
{
    public static class SchoolHistoryMap
    {
        public static SchoolHistoryDto ToDto(this SchoolHistory schoolHistory)
        {
            return new SchoolHistoryDto
            {
                Id = schoolHistory.Id,
                FileBase64 = schoolHistory.FileBase64,
                Format = schoolHistory.Format,
                Name = schoolHistory.Name
            };
        }
    }
}
