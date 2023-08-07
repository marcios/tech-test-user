using Users.Domain.ValueObjects;

namespace Users.Domain.Entities
{
    public class User
    {
        internal User() { }
        public User(int id, string name, string lastName, Email email, DateTime birthDate)
        {
            this.Id = id;

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Nome não pode ser vazio");

            if (birthDate.Date > DateTime.Today.Date)
                throw new ArgumentException($"A data de nascimento não pode ser maior que hoje ({DateTime.Today.ToString("dd-MM-yyyy")})");

            this.Name = name;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Email = email;
        }

        public void IsValid()
        {

        }

        public void AddScholarity(Scholarity scholarity)
        {
            this.ScholarityId = scholarity.Id;
            this.Scholarity = scholarity;
        }

        public void AddSchoolHistory(string schoolHistoryName, string schoolHistoryFormat, string schoolHistoryFile, int? id = null)
        {
            this.SchoolHistory = new SchoolHistory(schoolHistoryName,schoolHistoryFormat, schoolHistoryFile,id);
            
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int? ScholarityId { get; private set; }
        public int? SchoolHistoryId { get; private set; }

        public Scholarity Scholarity { get; private set; }
        public SchoolHistory SchoolHistory { get; private set; }
    }
}
