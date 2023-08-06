using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Infra.Data.Context.Configuration;

namespace Users.Infra.Data.Context
{
    public class UserDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<SchoolHistory> schoolHistories { get; set; }
        public DbSet<Scholarity> Scholarities { get; set; }
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ScholarityConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolHistoryConfiguration());
        }
    }
}
