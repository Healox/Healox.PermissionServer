using Healox.PermissionServer.EntityFramework.Storage.DbContexts;
using Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding.Configuration;
using System.Resources;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<PermissionServerDbContext>())
                {
                    EnsureSeedData(context!);
                }
            }
        }

        private static void EnsureSeedData(PermissionServerDbContext context)
        {
            Console.WriteLine("Seeding database...");

            if (!context.IdentityRoles.Any())
            {
                Console.WriteLine("IdentityRoles being populated");
                foreach (var identityRole in IdentityRoles.Seeds)
                {
                    context.IdentityRoles.Add(identityRole);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("IdentityRoles already populated");
            }

            // The Rest of It

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }
    }
}
