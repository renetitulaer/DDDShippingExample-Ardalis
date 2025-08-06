Create migration:
dotnet ef migrations add InitialCreate --project infrastructure --startup-project consoleApp --context ShippingDbContext --verbose

Remove migration:
dotnet ef migrations remove --project infrastructure --startup-project consoleApp --context ShippingDbContext --verbose

Update database
dotnet ef database update --project Infrastructure --startup-project ConsoleApp --context ShippingDbContext -- ".\sql2022;Database=DDDShippingExample;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Application Name=DDDShippingExample"

Drop database
dotnet ef database drop --project Infrastructure --startup-project ConsoleApp --context ShippingDbContext --force -- ".\sql2022;Database=DDDShippingExample;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Application Name=DDDShippingExample"