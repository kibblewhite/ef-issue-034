namespace ef_issue_034.Models;

public abstract class BaseEntity
{
    public static readonly bool IsUnitTest = AppDomain.CurrentDomain.GetAssemblies().Any(x => x?.FullName?.ToLowerInvariant().StartsWith("microsoft.testplatform") is true);
}

public interface IBaseEntityTypeConfiguration<TEntityType> : IEntityTypeConfiguration<TEntityType> where TEntityType : BaseEntity
{
    void Configure(EntityTypeBuilder<TEntityType> builder, Expression<Func<TEntityType, object?>>? primaryKeyExpression, string tableName);
}

public abstract class BaseEntityConfiguration<TEntityType> : IBaseEntityTypeConfiguration<TEntityType> where TEntityType : BaseEntity
{

    public Expression<Func<TEntityType, object?>>? PrimaryKeyExpression { get; private set; }

    public virtual void Configure(EntityTypeBuilder<TEntityType> builder, Expression<Func<TEntityType, object?>>? primaryKeyExpression, string tableName)
    {
        // todo (kibble|2021-11-03): System should check that the incoming expression type is that of System.Guid
        // string property_type_name = PropertyHelper<TEntityType>.GetPropertyTypeName(primaryKeyExpression);
        PrimaryKeyExpression = primaryKeyExpression;
        if (string.IsNullOrWhiteSpace(tableName) is false) { builder.ToTable(tableName); }
    }

    public virtual void Configure(EntityTypeBuilder<TEntityType> builder)
    {
        if (PrimaryKeyExpression is not null)
        {
            builder.HasKey(PrimaryKeyExpression);
            builder.HasIndex(PrimaryKeyExpression).IsUnique();
            builder.Property(PrimaryKeyExpression).IsRequired();
            // builder.Property(PrimaryKeyExpression).ValueGeneratedOnAdd();
            // builder.Property(PrimaryKeyExpression).HasColumnType("uuid");
            // builder.Property(PrimaryKeyExpression).HasDefaultValueSql("uuid_generate_v4()");
        }
    }

    void IBaseEntityTypeConfiguration<TEntityType>.Configure(EntityTypeBuilder<TEntityType> builder, Expression<Func<TEntityType, object?>>? primaryKeyExpression, string tableName) => Configure(builder, primaryKeyExpression, tableName);

    void IEntityTypeConfiguration<TEntityType>.Configure(EntityTypeBuilder<TEntityType> builder) => Configure(builder);
}