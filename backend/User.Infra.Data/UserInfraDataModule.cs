using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Domain.Interfaces.Repositories;
using Users.Infra.Data.Context;
using Users.Infra.Data.Repositories;

namespace Users.Infra.Data
{
    public static class UserInfraDataModule
    {
        public static void AddUserInfraDataModule(this IServiceCollection service, IConfiguration  configuration)
        {
            service.AddDbContext<UserDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("default")));

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IScholarityRepository, ScholarityRepository>();
            
        }
    }
}