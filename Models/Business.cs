namespace ef_issue_034.Models;

public class Business : BaseEntity
{
    public Guid BusinessId { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public virtual IReadOnlyList<BusinessSubsidiary> BusinessSubsidiaries => _businessSubsidiaries.ToList();
    private IList<BusinessSubsidiary> _businessSubsidiaries = new List<BusinessSubsidiary>();

    protected Business() { }

    public Business(string name, string description) : this()
    {
        Name = name;
        Description = description;
    }

}

public sealed class BusinessConfiguration : BaseEntityConfiguration<Business>
{

    private readonly DatabaseColumn DefaultDatabaseColumnSettings;

    public BusinessConfiguration(DatabaseColumn defaultDatabaseColumnSettings)
    {
        DefaultDatabaseColumnSettings = defaultDatabaseColumnSettings;
    }

    public override void Configure(EntityTypeBuilder<Business> builder)
    {

        Configure(builder, x => x.BusinessId, nameof(Business));
        base.Configure(builder);

        builder.HasMany(x => x.BusinessSubsidiaries)
            .WithOne(x => x.Business)
            .HasForeignKey(x => x.BusinessId)
            .HasPrincipalKey(x => x.BusinessId);

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .UseCollation(DefaultDatabaseColumnSettings.Collation);

        builder.Property(x => x.Description)
            .HasMaxLength(512)
            .UseCollation(DefaultDatabaseColumnSettings.Collation);

    }

}
