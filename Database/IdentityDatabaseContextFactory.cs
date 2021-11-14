namespace ef_issue_034.Database;

public class IdentityDatabaseContextFactory : IDesignTimeDbContextFactory<IdentityDatabaseContext>
{

    private const string DefaultDatabaseContextConnectionName = "DefaultConnectionString";
    private const string DefaultAppSettingsJsonFilename = "appsettings.json";

    public string ConnectionString { get; private set; }

    private IConfiguration Configuration { get; }

    public IdentityDatabaseContextFactory() : this(new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile(DefaultAppSettingsJsonFilename).Build()) { }

    public IdentityDatabaseContextFactory(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        Configuration = configuration;
        ConnectionString = Configuration.GetConnectionString(DefaultDatabaseContextConnectionName);
    }

    public IdentityDatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IdentityDatabaseContext>();

        optionsBuilder.EnableServiceProviderCaching(true);
        optionsBuilder.EnableSensitiveDataLogging(true);
        optionsBuilder.EnableDetailedErrors(true);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Trace);
        optionsBuilder.UseNpgsql(ConnectionString, x =>
        {
            x.UseAdminDatabase("postgres");
        });

        return new IdentityDatabaseContext(optionsBuilder.Options);

    }
}

