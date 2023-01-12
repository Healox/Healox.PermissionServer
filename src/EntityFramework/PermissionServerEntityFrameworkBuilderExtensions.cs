
using Healox.PermissionServer.EntityFramework.Services;
using Healox.PermissionServer.EntityFramework.Storage.Configuration;
using Healox.PermissionServer.EntityFramework.Storage.DbContexts;
using Healox.PermissionServer.EntityFramework.Storage.Interfaces;
using Healox.PermissionServer.EntityFramework.Storage.Options;
using Healox.PermissionServer.EntityFramework.Storage.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods to add EF database support to PermissionServer.
/// </summary>
public static class PermissionServerEntityFrameworkBuilderExtensions
{
    /// <summary>
    /// Configures EF implementation of IPermissionServerStore and ICorsPolicyService with PermissionServer.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="storeOptionsAction">The store options action.</param>
    /// <returns></returns>
    public static IPermissionServerBuilder AddPermissionServerStore(
        this IPermissionServerBuilder builder,
        Action<PermissionServerStoreOptions>? storeOptionsAction = null)
    {
        return builder.AddPermissionServerStore<PermissionServerDbContext>(storeOptionsAction);
    }

    /// <summary>
    /// Configures EF implementation of IPermissionServerStore and ICorsPolicyService with PermissionServer.
    /// </summary>
    /// <typeparam name="TContext">The IPermissionServerDbContext to use.</typeparam>
    /// <param name="builder">The builder.</param>
    /// <param name="storeOptionsAction">The store options action.</param>
    /// <returns></returns>
    public static IPermissionServerBuilder AddPermissionServerStore<TContext>(
        this IPermissionServerBuilder builder,
        Action<PermissionServerStoreOptions>? storeOptionsAction = null)
        where TContext : DbContext, IPermissionServerDbContext
    {
        builder.Services.AddPermissionServerDbContext<TContext>(storeOptionsAction);

        builder.AddPolicyStore<PolicyStore>();

        builder.AddCorsPolicyService<CorsPolicyService>();

        return builder;
    }
}
