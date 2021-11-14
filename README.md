# ef-issue-034

Issue resolved to this command: ModelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);

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
