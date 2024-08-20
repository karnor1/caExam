
using Microsoft.EntityFrameworkCore;
using CaExam.Interfaces;
using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Repositories.SpecificRepositories;
using static CaExam.Repositories.GenericDbRepo;
using CaExam.Services;
using CaExam.Helpers;

namespace CaExam
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
            builder.Services.AddScoped<IInitialDataGenerator, InitialDataGenerator>();


            builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();

            builder.Services.AddScoped<IPasswordService, PasswordService>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
