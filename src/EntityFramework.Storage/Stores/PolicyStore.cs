using Healox.PermissionServer.Domain.Model;
using Healox.PermissionServer.Domain.Stores;
using Healox.PermissionServer.EntityFramework.Storage.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Stores;

public class PolicyStore : IPolicyStore
{
    /// <summary>
    /// The UserStore.
    /// </summary>
    protected readonly IUserStore _userStore;

    /// <summary>
    /// The IdenityRoleStore.
    /// </summary>
    protected readonly IIdentityRoleStore _identityRoleStore;


    public PolicyStore(IUserStore userStore, IIdentityRoleStore identityRoleStore)
    {
        _userStore = userStore ?? throw new ArgumentNullException(nameof(userStore));
        _identityRoleStore = identityRoleStore ?? throw new ArgumentNullException(nameof(identityRoleStore));
    }

    //public Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync()
    //{
    //    throw new NotImplementedException();
    //}

    public virtual async Task<IEnumerable<Role>> GetRolesAndPermissionsAsync(string userId, IEnumerable<string> identityRoleNames)
    {
        var roles = new List<Role>();

        // Add roles and permissions directly associated with the user
        var user = await _userStore.GetUserAsync(userId);

        foreach ( var role in user.Roles )
        {
            roles.Add(role);
        }

        // Add roles and permissions indirectly associated with the user through its identity roles
        foreach (var identityRoleName in identityRoleNames)
        {
            var identityRole = await _identityRoleStore.GetIdentityRoleAsync(identityRoleName);

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
