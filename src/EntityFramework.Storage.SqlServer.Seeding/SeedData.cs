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

            if (!context.Roles.Any())
            {
                Console.WriteLine("Roles being populated");
                foreach (var role in Roles.Seeds)
                {
                    context.Roles.Add(role);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Roles already populated");
            }

            if (!context.Permissions.Any())
            {
                Console.WriteLine("Permissions being populated");
                foreach (var permission in Permissions.Seeds)
                {
                    context.Permissions.Add(permission);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Permissions already populated");
            }

            if (!context.RolePermissions.Any())
            {
                Console.WriteLine("RolePermissions being populated");
                foreach (var rolePermission in RolePermissions.Seeds)
                {
                    context.RolePermissions.Add(rolePermission);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("RolePermissions already populated");
            }

            if (!context.Users.Any())
            {
                Console.WriteLine("Users being populated");
                foreach (var user in Users.Seeds)
                {
                    context.Users.Add(user);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Users already populated");
            }

            if (!context.UserRoles.Any())
            {
                Console.WriteLine("UserRoles being populated");
                foreach (var userRole in UserRoles.Seeds)
                {
                    context.UserRoles.Add(userRole);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("UserRoles already populated");
            }

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

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }
    }
}
