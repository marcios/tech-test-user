using Microsoft.Extensions.DependencyInjection;
using Users.Application.Services;
using Users.Domain.Interfaces.Services;

namespace Users.Application
{
    public static class UserApplicationModule
    {
        public static void AddUserApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISchoolHistoryService, SchoolHistoryService>();
            services.AddScoped<IScholarityService, ScholarityService>();
        }
    }
}