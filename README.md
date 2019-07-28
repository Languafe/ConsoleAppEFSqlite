ConsoleApp with EF Core Sqlite
==============================

# TL;DR:

Install the .NET Core SDK (built using version 2.2.401)

Run the app with the dotnet cli. 

```bash
dotnet run
```

This app should work on Windows, Linux and MacOS.

# Add a migration
Add an automatic property to the Thing class and follow it up with the following command:

```bash
dotnet ef migrations add "new migration"
```

The next time you run it, the new property should be created in the database table.

The call to dbContext.Database.Migrate() in Main applies any pending migrations to the database.
