using Healox.PermissionServer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Stores
{
    public interface IPermissionStore
    {
        ///// <summary>
        ///// Finds a permission by id
        ///// </summary>
        ///// <param name="id">The permission id</param>
        ///// <returns>The permission</returns>
        //Task<Permission?> GetPermissionByIdAsync(string id);

        /// <summary>
        /// Finds a permission by name
        /// </summary>
        /// <param name="name">The permission name</param>
        /// <returns>The permission</returns>
        Task<Permission?> GetPermissionByNameAsync(string name);

        ///// <summary>
        ///// Finds permissions related to a role by role id
        ///// </summary>
        ///// <param name="id">The role id</param>
        ///// <param name="withChildRoles">True: gets permissions related to a role and all child roles recursively.<br/>False: gets permissions directly related to a single role by itself without child roles.</param>
        ///// <returns>A list of permissions related to a role</returns>
        //Task<IEnumerable<Permission?>> GetPermissionsByRoleIdAsync(string id, bool withChildRoles = true);

        /// <summary>
        /// Finds permissions related to a role by role name
        /// </summary>
        /// <param name="name">The role name</param>
        /// <param name="withChildRoles">True: gets permissions related to a role with all child roles recursively.<br/>False: gets permissions directly related to a single role by itself without child roles.</param>
        /// <returns>A list of permissions related to a role</returns>
        Task<IEnumerable<Permission?>> GetPermissionsByRoleNameAsync(string name, bool withChildRoles = true);
    }
}
