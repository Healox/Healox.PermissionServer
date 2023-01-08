using Healox.PermissionServer.EntityFramework.Storage.Entities;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding.Configuration;

public class IdentityRoles
{
    public static readonly IEnumerable<IdentityRole> Seeds = new[]
    {
        new IdentityRole()
        {
            Id = Guid.Empty,
            Name= "Admin",
            Description="IdentityServer4 admin role.",
            RoleId= Guid.Empty
        }
    };
}
