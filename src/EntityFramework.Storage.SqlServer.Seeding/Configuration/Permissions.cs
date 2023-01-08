using Healox.PermissionServer.EntityFramework.Storage.Entities;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding.Configuration;

public class Permissions
{
    public static readonly IEnumerable<Permission> Seeds = new[]
    {
        new Permission()
        {
            Id = Guid.Empty,
            Name= "DoAnything",
            Description="Permission holder can do anything."
        }
    };
}
