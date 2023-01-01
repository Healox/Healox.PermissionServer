using Healox.PermissionServer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Stores
{
    public interface IIdentityRole
    {
        ///// <summary>
        ///// Finds an identity role by id
        ///// </summary>
        ///// <param name="id">The identity role id</param>
        ///// <returns>The identity role</returns>
        //Task<IdentityRole?> GetIdentityRoleByIdAsync(string id);

        /// <summary>
        /// Finds an identity role by name
        /// </summary>
        /// <param name="name">The identity role name</param>
        /// <returns>The identity role</returns>
        Task<IdentityRole?> GetIdentityRoleByNameAsync(string name);

        ///// <summary>
        ///// Finds identity roles by role name
        ///// </summary>
        ///// <param name="name">The role name</param>
        ///// <returns>The identity roles</returns>
        //Task<IEnumerable<IdentityRole?>> GetIdentityRolesByRoleNameAsync(string name);

        ///// <summary>
        ///// Finds identity roles by role id
        ///// </summary>
        ///// <param name="id">The role id</param>
        ///// <returns>The identity roles</returns>
        //Task<IEnumerable<IdentityRole?>> GetIdentityRolesByRoleIdAsync(string name);
    }
}
