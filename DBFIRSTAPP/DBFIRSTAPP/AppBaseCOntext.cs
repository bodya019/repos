using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBFIRSTAPP
{
    public class AppBaseCOntext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public AppBaseCOntext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           var config = new ConfigurationBuilder()
                .AddJsonFile("appSetting.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();
            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }

    }
}
