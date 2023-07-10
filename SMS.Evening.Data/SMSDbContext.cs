using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMS.Evening.Data.Models.DataModels;

namespace SMS.Evening.Data
{
    public class SMSDbContext : IdentityDbContext
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}