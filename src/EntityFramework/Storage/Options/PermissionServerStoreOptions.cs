using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Options
{
    public class PermissionServerStoreOptions
    {
        /// <summary>
        /// Callback to configure the EF DbContext.
        /// </summary>
        /// <value>
        /// The configure database context.
        /// </value>
        public Action<DbContextOptionsBuilder>? PermissionServerDbContext { get; set; }

        /// <summary>
        /// Callback in DI resolve the EF DbContextOptions. If set, ConfigureDbContext will not be used.
        /// </summary>
        /// <value>
        /// The configure database context.
        /// </value>
        public Action<IServiceProvider, DbContextOptionsBuilder>? ResolveDbContextOptions { get; set; }

        /// <summary>
        /// Gets or sets the default schema.
        /// </summary>
        /// <value>
        /// The default schema.
        /// </value>
        public string? DefaultSchema { get; set; } = null;

        /// <summary>
        /// Gets or sets table configurations.
        /// </summary>
        /// <value>
        /// The table resource.
        /// </value>
        public TableConfiguration IdentityRole { get; set; } = new TableConfiguration("IdentityRoles");
        public TableConfiguration Permission { get; set; } = new TableConfiguration("Permissions");
        public TableConfiguration Role { get; set; } = new TableConfiguration("Roles");
        public TableConfiguration RoleMap { get; set; } = new TableConfiguration("RoleMaps");
        public TableConfiguration RolePermission { get; set; } = new TableConfiguration("RolePermissions");
        public TableConfiguration User { get; set; } = new TableConfiguration("Users");
        public TableConfiguration UserRole { get; set; } = new TableConfiguration("UserRoles");
    }
}
