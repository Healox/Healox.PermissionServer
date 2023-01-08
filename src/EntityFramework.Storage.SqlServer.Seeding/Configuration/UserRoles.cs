using Healox.PermissionServer.EntityFramework.Storage.Entities;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding.Configuration;

public class UserRoles
{
    public static readonly IEnumerable<UserRole> Seeds = new[]
    {
        new UserRole()
        {
            Id= Guid.Empty,
            RoleId = Guid.Empty,
            UserId = Guid.Empty
        }
    };
}
