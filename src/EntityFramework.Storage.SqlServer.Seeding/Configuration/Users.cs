using Healox.PermissionServer.EntityFramework.Storage.Entities;

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Seeding.Configuration;

public class Users
{
    public static readonly IEnumerable<User> Seeds = new[]
    {
        new User()
        {
            Id = Guid.Empty,
            Notes = "Admin user."
        }
    };
}
