namespace Users.Domain.Dtos
{
    public class UserDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string BirthDate { get;  set; }
        public int? ScholarityId { get;  set; }
        public int? SchoolHistoryId { get;  set; }

        public string Scholarity { get; set; }
        public string SchoolHistoryName { get;  set; }
        public string SchoolHistoryFormat { get;  set; }
        public string SchoolHistoryFile { get;  set; }
    }
}
