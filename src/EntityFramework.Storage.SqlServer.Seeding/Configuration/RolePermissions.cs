using Healox.PermissionServer.EntityFramework.Storage.Entities;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding.Configuration;

public class RolePermissions
{
    public static readonly IEnumerable<RolePermission> Seeds = new[]
    {
        new RolePermission()
        {
            Id= Guid.Empty,
            RoleId = Guid.Empty,
            PermissionId = Guid.Empty
        }
    };
}
