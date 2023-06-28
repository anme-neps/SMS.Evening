using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMS.Evening.Core.IRepositories;
using SMS.Evening.Core.Repositories;
using SMS.Evening.Data;
using SMS.Evening.Service.IServices;
using SMS.Evening.Service.Services;

namespace SMS.Evening.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //get connection sting
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");
            // add db context
            builder.Services.AddDbContext<SMSDbContext>(options => options.UseSqlServer(connectionString));
            // add identity features
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SMSDbContext>();
            builder.Services.AddTransient<IAccountRepositories, AccountRepositories>();
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IStudentRepositories, StudentRepositories>();
            builder.Services.AddTransient<IStudentService, StudentService>();
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}