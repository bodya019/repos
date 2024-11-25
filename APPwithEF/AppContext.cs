using Microsoft.EntityFrameworkCore;

namespace APPwithEF;

internal class AppContext : DbContext
{
    public AppContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-GE7ID1L;DataBase=NewDataBase; Trusted_connection=True; TrustServerCertificate=True; ");
    }
}
