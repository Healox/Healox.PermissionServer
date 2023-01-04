using Healox.PermissionServer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Stores;

public interface IIdentityRoleStore
{
    /// <summary>
    /// Get the roles and permissions assigned to current user identity roles
    /// </summary>
    /// <param name="userId">The user Id</param>
    /// <returns>The roles</returns>
    Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync();

    /// <summary>
    /// Get the roles and permissions assigned to a specific identity role
    /// </summary>
    /// <param name="userId">The user Id</param>
    /// <returns>The roles</returns>
    Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync(string identityRoleName);

    /// <summary>
    /// Finds out if the current user belongs to a PermissionServer specific role through its identity roles
    /// </summary>
    /// <param name="roleName">The role name</param>
    /// <returns>true or false</returns>
    Task<bool> IsInRoleAsync(string roleName);

    /// <summary>
    /// Finds out if an identity role is a memeber of a PermissionServer specific role
    /// </summary>
    /// <param name="roleName">The PermissionServer role name</param>
    /// <param name="identityRoleName">The identity role name</param>
    /// <returns>true or false</returns>
    Task<bool> IsInRoleAsync(string roleName, string identityRoleName);

    /// <summary>
    /// Finds out if the current user has a specific permission through its identity role
    /// </summary>
    /// <param name="permissionName">The permission name</param>
    /// <returns>true or false</returns>
    Task<bool> HasPermissionAsync(string permissionName);

    /// <summary>
    /// Finds out if an identity role has a specific permission
    /// </summary>
    /// <param name="permissionName">The permission name</param>
    /// <param name="identityRoleName">The identity role name</param>
    /// <returns>true or false</returns>
    Task<bool> HasPermissionAsync(string permissionName, string identityRoleName);
}
