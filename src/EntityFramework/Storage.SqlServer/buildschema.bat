rmdir /S /Q Migrations

dotnet ef migrations add PermissionServer -c PermissionServerDbContext -o Migrations/PermissionServerDb

dotnet ef migrations script -c PermissionServerDbContext -o Migrations/PermissionServerDb.sql
