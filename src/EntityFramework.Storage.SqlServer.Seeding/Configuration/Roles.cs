using Healox.PermissionServer.EntityFramework.Storage.Entities;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding.Configuration;

public class Roles
{
    public static readonly IEnumerable<Role> Seeds = new[]
    {
        new Role()
        {
            Id= Guid.Empty,
            ParentRoleId = null,
            Name= "Admin",
            Description="PermissionServer admin role.",
        }
    };
}
