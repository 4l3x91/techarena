using DAL.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    //password_A12
    private static readonly string azureConnectionString = @"Server=tcp:puppy.database.windows.net,1433;Initial Catalog=HouseholdDb;Persist Security Info=False;User ID=puppy2022;Password=password_A12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        //Database.EnsureCreated(); //Behövs inte om jag kör update-database
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserActivity> UserActivities { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Activity> Activities { get; set; }

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
