using Microsoft.EntityFrameworkCore;
using Notify.Models.Database;

namespace Notify
{
    public class Program
    {
        static string? _connectionString = 
                      Environment.GetEnvironmentVariable("NOTIFY_CONNECTION");
        public static void Main(string[] args)
        {
            if (_connectionString is null)
            {
                Console.WriteLine("DB CONNECTION FAIL");
                return;
            }
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AuthContext>(
                                                options => options
                                                .UseNpgsql(_connectionString));

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