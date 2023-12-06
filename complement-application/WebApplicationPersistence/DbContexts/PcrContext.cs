using Microsoft.EntityFrameworkCore;
using WebApplicationCommon.Enums;
using WebApplicationEntities;

namespace WebApplicationPersistence.DbContexts;

public class PcrContext : DbContext
{
    public DbSet<PcrTest> PcrTests { get; set; }
    public DbSet<User> Users { get; set; }

    public PcrContext(DbContextOptions<PcrContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Entity Framework Fluent API
        // modelBuilder.Entity<PcrTest>().ToTable("PcrTests");
        // datetime() est une fonction Sqlite, si vous changez de moteur de base de donnnées, il faudra adapter cette
        // default value. Par exemple en Oracle on utilisera GETDATE().
        modelBuilder.Entity<PcrTest>().Property(x => x.CreationDate).HasDefaultValueSql("datetime()");
        modelBuilder.Entity<PcrTest>().Property(x => x.AnalysisResult).HasConversion<string>();
        modelBuilder.Entity<PcrTest>().HasData(new PcrTest()
            {
                Id = 1,
                CreationDate = new DateTime(2023, 10, 30, 12, 54, 30),
                SamplingDate = new DateTime(2023, 10, 30, 12, 54, 30),
                ReceptionDate = new DateTime(2023, 11, 1),
                AnalysisDate = new DateTime(2023, 11, 2),
                AnalysisResult = AnalysisResultEnum.Positive,
                SampleNumber = "ABCD1234",
                // Performer = "Ludwig Lebrun",
                PerformerId = 1,
                Comment = "this is my comment 1"
            },
            new PcrTest()
            {
                Id = 2,
                CreationDate = new DateTime(2023, 11, 21, 9, 31, 24),
                SamplingDate = new DateTime(2023, 11, 21, 9, 31, 24),
                ReceptionDate = new DateTime(2023, 11, 23),
                AnalysisDate = new DateTime(2023, 11, 24),
                AnalysisResult = AnalysisResultEnum.Negative,
                SampleNumber = "ZREZ5241",
                // Performer = "Ludwig Leblanc",
                PerformerId = 2,
                Comment = "this is my comment 2"
            });
        
        modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Ludwig",
                LastName = "Lebrun"
            },
            new User()
            {
                Id = 2,
                FirstName = "Ludwig",
                LastName = "Leblanc"
            });
    }
}