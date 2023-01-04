using Healox.PermissionServer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Stores;

public interface IPermissionServerStore
{
    /// <summary>
    /// Get the roles and permissions assigned to current user directly and through his/her identity roles
    /// </summary>
    /// <returns>The roles</returns>
    Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync();

    /// <summary>
    /// Get the roles and permissions assigned to a user directly and through his/her identity roles
    /// </summary>
    /// <param name="userId">The user Id</param>
    /// <returns>The roles</returns>
    Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync(string userId);

    /// <summary>
    /// Finds out if current user belongs to a specific role directly or through his/her identity roles
    /// </summary>
    /// <param name="roleName">The role name</param>
    /// <returns>true or false</returns>
    Task<bool> IsInRoleAsync(string roleName);

    /// <summary>
    /// Finds out if a user belongs to a specific role directly or through his/her identity roles
    /// </summary>
    /// <param name="roleName">The role name</param>
    /// <param name="userId">The user identifier</param>
    /// <returns>true or false</returns>
    Task<bool> IsInRoleAsync(string roleName, string userId);

    /// <summary>
    /// Finds out if current user has a specific permission either directly or through his/her identity roles
    /// </summary>
    /// <param name="permissionName">The permission name</param>
    /// <returns>true or false</returns>
    Task<bool> HasPermissionAsync(string permissionName);

    /// <summary>
    /// Finds out if a user has a specific permission either directly or through his/her identity roles
    /// </summary>
    /// <param name="permissionName">The permission name</param>
    /// <param name="userId">The user identifier</param>
    /// <returns>true or false</returns>
    Task<bool> HasPermissionAsync(string permissionName, string userId);

}
