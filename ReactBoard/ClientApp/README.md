## Adding Migrations
dotnet ef migrations add <MigrationName> --startup-project ../ReactBoard

e.g. dotnet ef migrations add InitialCreate --startup-project ../ReactBoard

## Updating the database
dotnet ef database update --startup-project ../ReactBoard