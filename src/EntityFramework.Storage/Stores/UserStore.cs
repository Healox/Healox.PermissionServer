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

public class UserStore : IUserStore
{
    /// <summary>
    /// The DbContext.
    /// </summary>
    protected readonly IPermissionServerDbContext PermissionServerContext;

    /// <summary>
    /// The logger.
    /// </summary>
    protected readonly ILogger<UserStore> Logger;

    public UserStore(IPermissionServerDbContext permissionServerContext, ILogger<UserStore> logger)
    {
        PermissionServerContext = permissionServerContext ?? throw new ArgumentNullException(nameof(permissionServerContext));
        Logger = logger;
    }

    public virtual async Task<User> GetUserAsync(string userId)
    {
        IQueryable<Entities.User> baseQuery = PermissionServerContext.Users.Where(x => x.Id == Guid.Parse(userId));

        var user = (await baseQuery.ToArrayAsync()).SingleOrDefault(x => x.Id == Guid.Parse(userId));

        if (user == default(Entities.User)) return default!;
        
        await baseQuery.Include(u => u.UserRoles
            .Select(ur => ur.Role)
            .SelectMany(r => r.RolePermissions)
            .Select(rp => rp.Permission))
            .LoadAsync();

        await baseQuery.Include(u => u.UserRoles
            .Select(ur => ur.Role)
            .SelectMany(r => r.ChildRoles)
            .SelectMany(cr => cr.RolePermissions)
            .Select(rp => rp.Permission))
            .LoadAsync();

        var model = user.ToModel();

        Logger.LogDebug("{userId} found in database: {userIdFound}", userId, model != null);

        return model!;
    }

    //public virtual async Task<bool> HasPermissionAsync(string userId, string permissionName)
    //{
    //    throw new NotImplementedException();
    //}

    //public virtual async Task<bool> IsInRoleAsync(string userId, string roleName)
    //{
    //    throw new NotImplementedException();
    //}
}
