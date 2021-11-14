namespace ef_issue_034.Models;

public class Subsidiary : BaseEntity
{
    public Guid SubsidiaryId { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public virtual IReadOnlyList<BusinessSubsidiary> BuinessSubsidiaries => _buinessSubsidiaries.ToList();
    private IList<BusinessSubsidiary> _buinessSubsidiaries = new List<BusinessSubsidiary>();

    protected Subsidiary() { }

    public Subsidiary(string name, string description) : this()
    {
        Name = name;
        Description = description;
    }

}

public class SubsidiaryConfiguration : BaseEntityConfiguration<Subsidiary>
{

    private readonly DatabaseColumn DefaultDatabaseColumnSettings;

    public SubsidiaryConfiguration(DatabaseColumn databaseColumn)
    {
        DefaultDatabaseColumnSettings = databaseColumn;
    }

    public override void Configure(EntityTypeBuilder<Subsidiary> builder)
    {

        Configure(builder, x => x.SubsidiaryId, nameof(Subsidiary));
        base.Configure(builder);

        builder.HasMany(x => x.BuinessSubsidiaries)
            .WithOne(x => x.Subsidiary)
            .HasPrincipalKey(x => x.SubsidiaryId)
            .HasForeignKey(x => x.SubsidiaryId);

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .UseCollation(DefaultDatabaseColumnSettings.Collation);

        builder.Property(x => x.Description)
            .HasMaxLength(512)
            .UseCollation(DefaultDatabaseColumnSettings.Collation);

    }

}