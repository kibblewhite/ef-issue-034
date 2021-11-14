# ef-issue-034
ef-issue-034 / Resolved to this command: ModelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);

When defining the property access mode, this will result in a failure with relational tables.
By removing this option, it has fixed the database seeding issue.
