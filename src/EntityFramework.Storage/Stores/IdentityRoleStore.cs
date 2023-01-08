using Healox.PermissionServer.Domain.Model;
using Healox.PermissionServer.Domain.Stores;
using Healox.PermissionServer.EntityFramework.Storage.Interfaces;
using Healox.PermissionServer.EntityFramework.Storage.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Stores;

public class IdentityRoleStore : IIdentityRoleStore
{
    /// <summary>
    /// The DbContext.
    /// </summary>
    protected readonly IPermissionServerDbContext PermissionServerContext;

    /// <summary>
    /// The logger.
    /// </summary>
    protected readonly ILogger<IdentityRoleStore> Logger;

    public IdentityRoleStore(IPermissionServerDbContext permissionServerContext, ILogger<IdentityRoleStore> logger)
    {
        PermissionServerContext = permissionServerContext ?? throw new ArgumentNullException(nameof(permissionServerContext));
        Logger = logger;
    }

    public virtual async Task<IdentityRole> GetIdentityRoleAsync(string identityRoleName)
    {
        IQueryable<Entities.IdentityRole> baseQuery = PermissionServerContext.IdentityRoles.Where(x => x.Name == identityRoleName);

        var identityRole = (await baseQuery.ToArrayAsync()).SingleOrDefault(x => x.Name == identityRoleName);

        if (identityRole == default(Entities.IdentityRole)) return default!;

        await baseQuery.Include(ir => ir.Role!.RolePermissions
            .Select(rp => rp.Permission))
            .LoadAsync();

        await baseQuery.Include(ir => ir.Role!.ChildRoles
            .SelectMany(cr => cr.RolePermissions)
            .Select(rp => rp.Permission))
            .LoadAsync();

        var model = identityRole.ToModel();

        Logger.LogDebug("{identityRoleName} found in database: {identityRoleNameFound}", identityRoleName, model != null);

        return model!;
    }

    //public Task<IEnumerable<Role?>> GetRolesAndPermissionsAsync(string identityRoleName)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> HasPermissionAsync(string permissionName)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> HasPermissionAsync(string permissionName, string identityRoleName)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> IsInRoleAsync(string roleName)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> IsInRoleAsync(string roleName, string identityRoleName)
    //{
    //    throw new NotImplementedException();
    //}
}
