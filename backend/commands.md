dotnet ef migrations add first --context ApplicationDbContext -o ./DAL/Migrations

dotnet ef database update
