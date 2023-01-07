using Healox.PermissionServer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Stores;

public interface IUserStore
{
    /// <summary>
    /// Get the roles and permissions assigned to the current user directly
    /// </summary>
    /// <returns>The roles</returns>
    //Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync();

    /// <summary>
    /// Get the User with roles and permissions assigned to a user directly
    /// </summary>
    /// <param name="userId">The user Id</param>
    /// <returns>The user</returns>
    Task<User> GetUserAsync(string userId);

    /// <summary>
    /// Finds out if current user belongs directly to a specific role
    /// </summary>
    /// <param name="roleName">The role name</param>
    /// <returns>true or false</returns>
    //Task<bool> IsInRoleAsync(string roleName);

    /// <summary>
    /// Finds out if a user belongs directly to a specific role
    /// </summary>
    /// <param name="userId">The user identifier</param>
    /// <param name="roleName">The role name</param>
    /// <returns>true or false</returns>
    //Task<bool> IsInRoleAsync(string userId, string roleName);

    /// <summary>
    /// Finds out if current user has a specific permission
    /// </summary>
    /// <param name="permissionName">The permission name</param>
    /// <returns>true or false</returns>
    //Task<bool> HasPermissionAsync(string permissionName);

    /// <summary>
    /// Finds out if a user has a specific permission
    /// </summary>
    /// <param name="userId">The user identifier</param>
    /// <param name="permissionName">The permission name</param>
    /// <returns>true or false</returns>
    //Task<bool> HasPermissionAsync(string userId,string permissionName);
}
