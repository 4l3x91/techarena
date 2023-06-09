using DAL.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        //Database.EnsureCreated(); //Behövs inte om jag kör update-database
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserInterest> UserInterests { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<UserEvent> UserEvents { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(azureConnectionString); //When using Azure Db version
        //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HouseholdDb;Trusted_Connection=True;"); //When using local Db version
        //optionsBuilder.UseInMemoryDatabase("inMemory"); //When using inMemory
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
