# ef-issue-034

Issue resolved to this command: ModelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);

Trace/Debug message being produced from the application included the following:

- "0 entities were added and 1 entities were removed from navigation"
- "on entity with key"
- "An entity of type"
- "with key"
- "changed to 'Detached'"
- "state due to severed required relationship to its parent entity of type"
- "entity with key"
- "changed state from 'Added' to 'Detached'"



## Outcome:

When defining the property access mode, this will result in a failure with relational tables.

> By removing this option, it has fixed the database seeding issue.


## Notes

To edit project, install 'Visual Studio Community 2022' by visiting:

https://visualstudio.microsoft.com/



Otherwise, an alternative option to edit project files can be done by using vscode-insiders, by navigating to the directory in your bash shell or WSL and running the following:

 ```bash

code-insiders .

 ```

In order to run this project/solution you should have a postgres database running on port 5432 available to your local machine (i.e. localhost)

The database credentials can be found inside the appsettings.json file under the default connection string.


## Build, Run & Clean / Open up a terminal and enter to following:



To build application:

 ```bash

dotnet build -c Debug

 ```

To run application:

```bash

dotnet run -c Debug

```

To clean application:

```bash

dotnet clean

```

## Optional: Rebuilding Migrations

To install or update EF Migration Tool:

```bash

dotnet tool install --global dotnet-ef

```

```bash

dotnet tool update --global dotnet-ef

```

To remove migration:

```bash

dotnet ef migrations remove

```

To create migration (initialisation example):

```bash

dotnet ef migrations add Initialise_Database

```

To update to the newest migration:

```bash

dotnet ef database update

```

To step-through migrations, where 0 is the beginning:

```bash

dotnet ef database update 0

```

### Debug/Trace Messages being produced:

dbug: 2021-11-13 02:24:44.143 CoreEventId.ValueGenerated[10808] (Microsoft.EntityFrameworkCore.ChangeTracking) 
      'IdentityDatabaseContext' generated temporary value 'f45db049-cd50-4256-af82-138a3af707cc' for the property 'BusinessSubsidiaryId.BusinessSubsidiary'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.StartedTracking[10806] (Microsoft.EntityFrameworkCore.ChangeTracking) 
      Context 'IdentityDatabaseContext' started tracking 'BusinessSubsidiary' entity with key '{BusinessSubsidiaryId: f45db049-cd50-4256-af82-138a3af707cc}'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.SaveChangesStarting[10004] (Microsoft.EntityFrameworkCore.Update) 
      SaveChanges starting for 'IdentityDatabaseContext'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.DetectChangesStarting[10800] (Microsoft.EntityFrameworkCore.ChangeTracking) 
      DetectChanges starting for 'IdentityDatabaseContext'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.CollectionChangeDetected[10804] (Microsoft.EntityFrameworkCore.ChangeTracking) 
      0 entities were added and 1 entities were removed from navigation 'Subsidiary.BuinessSubsidiaries' on entity with key '{SubsidiaryId: 64eeec28-eaeb-4960-88c1-1c70f70fef8f}'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.CascadeDeleteOrphan[10003] (Microsoft.EntityFrameworkCore.Update) 
      An entity of type 'BusinessSubsidiary' with key '{BusinessSubsidiaryId: f45db049-cd50-4256-af82-138a3af707cc}' changed to 'Detached' state due to severed required relationship to its parent entity of type 'Subsidiary'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.StateChanged[10807] (Microsoft.EntityFrameworkCore.ChangeTracking) 
      The 'BusinessSubsidiary' entity with key '{BusinessSubsidiaryId: f45db049-cd50-4256-af82-138a3af707cc}' tracked by 'IdentityDatabaseContext' changed state from 'Added' to 'Detached'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.CollectionChangeDetected[10804] (Microsoft.EntityFrameworkCore.ChangeTracking) 
      0 entities were added and 1 entities were removed from navigation 'Business.BusinessSubsidiaries' on entity with key '{BusinessId: d3391de2-5f84-4993-827a-e121d099fee6}'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.DetectChangesCompleted[10801] (Microsoft.EntityFrameworkCore.ChangeTracking) 
      DetectChanges completed for 'IdentityDatabaseContext'.
dbug: 2021-11-13 02:24:44.143 CoreEventId.SaveChangesCompleted[10005] (Microsoft.EntityFrameworkCore.Update) 
      SaveChanges completed for 'IdentityDatabaseContext' with 0 entities written to the database.
