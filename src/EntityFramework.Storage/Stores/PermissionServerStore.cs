using Healox.PermissionServer.Domain.Model;
using Healox.PermissionServer.Domain.Stores;
using Healox.PermissionServer.EntityFramework.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Stores;

public class PermissionServerStore : IPermissionServerStore
{
    /// <summary>
    /// The DbContext.
    /// </summary>
    protected readonly IPermissionServerDbContext PermissionServerContext;

    public PermissionServerStore(IPermissionServerDbContext permissionServerContext)
    {
        PermissionServerContext = permissionServerContext ?? throw new ArgumentNullException(nameof(permissionServerContext));
    }

    //public Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync()
    //{
    //    throw new NotImplementedException();
    //}

    public virtual async Task<IEnumerable<Role>> GetRolesAndPermissionsAsync(string userId, IEnumerable<string> identityRoleNames)
    {
        var roles = new List<Role>();

        var user = await new UserStore(PermissionServerContext).GetUserAsync(userId);

        foreach ( var role in user.Roles )
        {
            roles.Add(role);
        }

        foreach (var identityRoleName in identityRoleNames)
        {
            var identityRole = await new IdentityRoleStore(PermissionServerContext).GetIdentityRoleAsync(identityRoleName);

            roles.Add(identityRole.Role);
        }

        return roles;
    }

    //public Task<bool> HasPermissionAsync(string permissionName)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> HasPermissionAsync(string permissionName, string userId)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> IsInRoleAsync(string roleName)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> IsInRoleAsync(string roleName, string userId)
    //{
    //    throw new NotImplementedException();
    //}
}
