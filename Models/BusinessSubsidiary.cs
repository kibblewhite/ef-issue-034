namespace ef_issue_034.Models;

public class BusinessSubsidiary : BaseEntity
{
    public Guid BusinessSubsidiaryId { get; private set; } = Guid.NewGuid();

    public Guid BusinessId { get; private set; }
    public virtual Business? Business { get; private set; }

    public Guid SubsidiaryId { get; private set; }
    public virtual Subsidiary? Subsidiary { get; private set; }

    protected BusinessSubsidiary() { }

    public BusinessSubsidiary(Subsidiary subsidiary, Business business) : this()
    {
        ArgumentNullException.ThrowIfNull(subsidiary, nameof(subsidiary));
        ArgumentNullException.ThrowIfNull(business, nameof(business));
        Subsidiary = subsidiary;
        Business = business;
    }
}


public class BuinessSubsidiaryConfiguration : BaseEntityConfiguration<BusinessSubsidiary>
{

    private readonly DatabaseColumn DefaultDatabaseColumnSettings;

    public BuinessSubsidiaryConfiguration(DatabaseColumn databaseColumn)
    {
        DefaultDatabaseColumnSettings = databaseColumn;
    }

    public override void Configure(EntityTypeBuilder<BusinessSubsidiary> builder)
    {

        Configure(builder, x => x.BusinessSubsidiaryId, nameof(BusinessSubsidiary));
        base.Configure(builder);

        // builder.HasIndex(x => new { x.BusinessId, x.SubsidiaryId }).IsUnique();

        builder.HasOne(x => x.Business)
            .WithMany(x => x.BusinessSubsidiaries)
            .HasPrincipalKey(x => x.BusinessId)
            .HasForeignKey(x => x.BusinessId);

        builder.HasOne(x => x.Subsidiary)
            .WithMany(x => x.BuinessSubsidiaries)
            .HasPrincipalKey(x => x.SubsidiaryId)
            .HasForeignKey(x => x.SubsidiaryId);

    }

}
