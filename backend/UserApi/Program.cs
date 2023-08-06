using Users.Application;
using Users.Infra.Data;

namespace UserApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors();


            //Add Inje��es
            builder.Services.AddUserInfraDataModule(builder.Configuration);
            builder.Services.AddUserApplicationModule();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(cors => cors
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyMethod()
            );

            app.MapControllers();

            app.Run();
        }
    }
}