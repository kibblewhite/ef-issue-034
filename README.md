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


## Open up a terminal and enter to following:



To build application:

 ```bash

dotnet build -c Debug

 ```



To run application:

```bash

dotnet run -c Debug

```