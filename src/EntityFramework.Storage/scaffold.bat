rmdir /S /Q Model

rmdir /S /Q DbContexts

dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=PermissionServerDb;Trusted_Connection=SSPI;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer --output-dir Model --context-dir DbContexts