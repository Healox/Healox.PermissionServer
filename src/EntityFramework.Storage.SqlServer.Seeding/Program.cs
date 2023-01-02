using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("PermissionServerDb");

            builder.Services.AddPermissionServer()
                .AddPermissionServerStore(options => {
                    options.PermissionServerDbContext = b => b.UseSqlServer(connectionString);
                });

            var app = builder.Build();

            SeedData.EnsureSeedData(app.Services);

            //app.MapGet("/", () => "Hello World!");

            //app.Run();
        }
    }
}