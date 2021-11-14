using ef_issue_034.Models;

namespace ef_issue_034.Database;

public static class IdentityDatabaseContextSeed
{

    public static void DropPostgresPublicSchema(this IdentityDatabaseContext ctx, string connectionString)
    {
        // note (2021-11-14|kibble): order is important - this list is joined and seperated by a semicolon character followed by a space > "; "
        List<string> cmds = new()
        {
                "DROP SCHEMA public CASCADE",
                "CREATE SCHEMA public",
                "GRANT ALL ON SCHEMA public TO postgres",
                "CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\" WITH SCHEMA public"
        };
        using var npgsql_connection = new NpgsqlConnection(connectionString);
        npgsql_connection.Open();
        using var npgsql_command = npgsql_connection.CreateCommand();
        npgsql_command.CommandText = string.Join("; ", cmds.Select(x => x));
        npgsql_command.ExecuteNonQuery();
        npgsql_connection.Close();
    }

    public static void Seed(this IdentityDatabaseContext ctx)
    {

        if (ctx.Businesses.Any() is true || ctx.Subsidiaries.Any() is true || ctx.BuinessSubsidiaries.Any() is true) { Console.WriteLine("!!! Entities already present in Database !!!"); return; }

        Console.WriteLine("Begin Transaction");
        using var transaction = ctx.Database.BeginTransaction();

        Business default_business = new("Default", "Default");
        ctx.Add<Business>(default_business);

        Subsidiary default_subsidary = new("Default", "Default");
        ctx.Add<Subsidiary>(default_subsidary);

        //Group default_group = new("Default", "Default");
        //ctx.Add<Group>(default_group);

        ctx.SaveChanges();
        Console.WriteLine("Business & Subsidiary - Created");

        default_business = ctx.Businesses.First(x => x.BusinessId == default_business.BusinessId);
        default_subsidary = ctx.Subsidiaries.First(x => x.SubsidiaryId == default_subsidary.SubsidiaryId);

        BusinessSubsidiary default_business_subsidary = new(default_subsidary, default_business);
        ctx.Add<BusinessSubsidiary>(default_business_subsidary);

        //SubsidiaryGroup default_subsidiary_group = new(default_group, default_subsidary);
        //ctx.Add<SubsidiaryGroup>(default_subsidiary_group);

        ctx.SaveChanges();
        Console.WriteLine("BusinessSubsidiary - Created");

        //Guid group_id = default_group.GroupId;

        transaction.Commit();
        Console.WriteLine("Transaction Committed");

        return;
    }

}

