using Healox.PermissionServer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Stores
{
    public interface IUserStore
    {
        /// <summary>
        /// Get the roles and permissions assigned to a user
        /// </summary>
        /// <param name="userId">The user Id</param>
        /// <returns>The roles</returns>
        Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync(string userId);

        /// <summary>
        /// Finds out if a user has a specific role
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <returns>true or false</returns>
        Task<bool> IsInRoleAsync(string userId);

        /// <summary>
        /// Finds out if a user has a specific permission
        /// </summary>
        /// <param name="permissionName">The permission name</param>
        /// <returns>true or false</returns>
        Task<bool> HasPermissionAsync(string userId);
    }
}
