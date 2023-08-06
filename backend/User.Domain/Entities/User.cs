namespace Users.Domain.Entities
{
    public class User
    {
        internal User() { }
        public User(string name, string lastName, string email,DateTime birthDate)
        {
            
            this.Name= name;    
            this.LastName= lastName;
            this.BirthDate = birthDate;
            this.Email= email;

            this.Validate();
        }

        private void Validate()
        {
            
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int? ScholarityId { get; private set; }
        public int? SchoolHistoryId { get; private set; }

        public Scholarity Scholarity { get; set; }
        public SchoolHistory SchoolHistory { get; set; }
    }
}
