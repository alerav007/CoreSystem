// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using CoreSystem.Models;

namespace CoreSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
