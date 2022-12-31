using Healox.PermissionServer.EntityFramework.Storage.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("PermissionServerDb");

            // Add services to the container.
            builder.Services.AddPermissionServerDbContext(options => {
                options.PermissionServerDbContext = b =>
                    b.UseSqlServer(connectionString, dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            //app.MapGet("/", () => "Hello World!");

            //app.Run();
        }
    }
}