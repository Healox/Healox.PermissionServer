using Healox.PermissionServer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Stores
{
    public interface IRoleStore
    {
        ///// <summary>
        ///// Finds a role by id
        ///// </summary>
        ///// <param name="id">The role id</param>
        ///// <returns>The role</returns>
        //Task<Role?> GetRoleByIdAsync(string id);

        /// <summary>
        /// Finds a role by name
        /// </summary>
        /// <param name="name">The role name</param>
        /// <returns>The role</returns>
        Task<Role?> GetRoleByNameAsync(string name);

        /// <summary>
        /// Finds a role by identity role name
        /// </summary>
        /// <param name="name">The identity role name</param>
        /// <returns>The role</returns>
        Task<Role?> GetRoleByIdentityRoleNameAsync(string name);

        ///// <summary>
        ///// Finds a role and all child roles by id
        ///// </summary>
        ///// <param name="id">The role id</param>
        ///// <returns>A list of roles consisting of the role at the top and all child roles afterwards</returns>
        //Task<IEnumerable<Role?>> GetRoleAndChildRolesByIdAsync(string id);

        /// <summary>
        /// Finds a role and all child roles by name
        /// </summary>
        /// <param name="name">The role name</param>
        /// <returns>A list of roles consisting of the role at the top and all child roles afterwards</returns>
        Task<IEnumerable<Role?>> GetRoleAndChildRolesByNameAsync(string name);

        /// <summary>
        /// Finds a role and all child roles by identity role name
        /// </summary>
        /// <param name="name">The identity role name</param>
        /// <returns>A list of roles consisting of the role at the top and all child roles afterwards</returns>
        Task<IEnumerable<Role?>> GetRoleAndChildRolesByIdentityRoleNameAsync(string name);
    }
}
