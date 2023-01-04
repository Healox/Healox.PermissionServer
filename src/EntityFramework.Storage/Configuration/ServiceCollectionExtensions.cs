using Healox.PermissionServer.EntityFramework.Storage.DbContexts;
using Healox.PermissionServer.EntityFramework.Storage.Interfaces;
using Healox.PermissionServer.EntityFramework.Storage.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Configuration;

/// <summary>
/// Extension methods to add EF database support to PermissionServer.
/// </summary>
public static class PermissionServerEntityFrameworkBuilderExtensions
{
    /// <summary>
    /// Add PermissionServer DbContext to the DI system.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="storeOptionsAction">The store options action.</param>
    /// <returns></returns>
    public static IServiceCollection AddPermissionServerDbContext(this IServiceCollection services,
        Action<PermissionServerStoreOptions>? storeOptionsAction = null)
    {
        return services.AddPermissionServerDbContext<PermissionServerDbContext>(storeOptionsAction);
    }

    /// <summary>
    /// Add PermissionServer DbContext to the DI system.
    /// </summary>
    /// <typeparam name="TContext">The IPermissionServerDbContext to use.</typeparam>
    /// <param name="services"></param>
    /// <param name="storeOptionsAction">The store options action.</param>
    /// <returns></returns>
    public static IServiceCollection AddPermissionServerDbContext<TContext>(this IServiceCollection services,
    Action<PermissionServerStoreOptions>? storeOptionsAction = null)
    where TContext : DbContext, IPermissionServerDbContext
    {
        var options = new PermissionServerStoreOptions();
        services.AddSingleton(options);
        storeOptionsAction?.Invoke(options);

        if (options.ResolveDbContextOptions != null)
        {
            services.AddDbContext<TContext>(options.ResolveDbContextOptions);
        }
        else
        {
            services.AddDbContext<TContext>(dbCtxBuilder =>
            {
                options.PermissionServerDbContext?.Invoke(dbCtxBuilder);
            });
        }
        services.AddScoped<IPermissionServerDbContext, TContext>();

        return services;
    }
}
