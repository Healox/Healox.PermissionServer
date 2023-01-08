using Healox.PermissionServer.Domain.Services;
using Healox.PermissionServer.Domain.Stores;
using Healox.PermissionServer.EntityFramework.Storage.Stores;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Builder extension methods for registering additional services 
/// </summary>
public static class PermissionServerBuilderExtensionsAdditional
{
    /// <summary>
    /// Adds a CORS policy service.
    /// </summary>
    /// <typeparam name="T">The type of the concrete scope store class that is registered in DI.</typeparam>
    /// <param name="builder">The builder.</param>
    /// <returns></returns>
    public static IPermissionServerBuilder AddCorsPolicyService<T>(this IPermissionServerBuilder builder)
        where T : class, ICorsPolicyService
    {
        builder.Services.AddTransient<ICorsPolicyService, T>();
        return builder;
    }

    /// <summary>
    /// Adds a resource store.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder">The builder.</param>
    /// <returns></returns>
    public static IPermissionServerBuilder AddPermissionServerStore<T>(this IPermissionServerBuilder builder)
       where T : class, IPermissionServerStore
    {
        builder.Services.AddTransient<IPermissionServerStore, T>();
        builder.Services.AddTransient<IUserStore, UserStore>();
        builder.Services.AddTransient<IIdentityRoleStore, IdentityRoleStore>();

        return builder;
    }
}
