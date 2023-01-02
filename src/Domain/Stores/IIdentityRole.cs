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
        /// <summary>
        /// Finds the role assigned to an identity role
        /// </summary>
        /// <param name="identityRoleName">The identity role name</param>
        /// <returns>The role</returns>
        Task<Role?> GetRoleAsync(string identityRoleName);
    }
}
