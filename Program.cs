using ef_issue_034.Database;

Console.WriteLine("Hello, World!");

var database_context_factory = new IdentityDatabaseContextFactory();
using var ctx = database_context_factory.CreateDbContext(Array.Empty<string>());

bool can_connect = ctx.Database.CanConnect();
if (can_connect is false) { ctx.Database.EnsureCreated(); }
ctx.DropPostgresPublicSchema(database_context_factory.ConnectionString);

ctx.Database.Migrate();
ctx.Seed();
Console.WriteLine("Database Seeded!");
