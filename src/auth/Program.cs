using Auth.Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace Auth
{
    public class Program
    {
        static readonly string? _connectionString = Environment.GetEnvironmentVariable("AUTH_CONNECTION");
        public static void Main(string[] args)
        {
            if (_connectionString is null)
            {
                Console.WriteLine("DB CONNECTION FAIL");
                return;
            }
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AuthContext>(options => options.UseNpgsql(_connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}