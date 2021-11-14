using ef_issue_034.Models;

namespace ef_issue_034.Database;

public class IdentityDatabaseContext : DbContext
{
    public DbSet<Business> Businesses { get; set; }
    public DbSet<BusinessSubsidiary> BuinessSubsidiaries { get; set; }
    public DbSet<Subsidiary> Subsidiaries { get; set; }

    public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options) : base(options)
    {
        Businesses = Set<Business>();
        BuinessSubsidiaries = Set<BusinessSubsidiary>();
        Subsidiaries = Set<Subsidiary>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var default_database_column_settings = new DatabaseColumn { Collation = "und-x-icu" };
        modelBuilder.UseDefaultColumnCollation(default_database_column_settings.Collation);
        // modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property); // note (2021-11-14|kibble):  this will cause relational issues with EF-Core when creating enteries into the BusinessSubsidary table
        modelBuilder.HasPostgresExtension("uuid-ossp");
        base.OnModelCreating(modelBuilder);

        var DatabaseContextModelBuilder = modelBuilder.UseCollation(default_database_column_settings.Collation);

        DatabaseContextModelBuilder
                .ApplyConfiguration(new BusinessConfiguration(default_database_column_settings))
                .ApplyConfiguration(new BuinessSubsidiaryConfiguration(default_database_column_settings))
                .ApplyConfiguration(new SubsidiaryConfiguration(default_database_column_settings));

    }

}
