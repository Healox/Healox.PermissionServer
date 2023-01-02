using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healox.PermissionServer.Configuration.DependencyInjection;
using Healox.PermissionServer.Configuration.DependencyInjection.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static  class PermissionServerServiceCollectionExtensions
    {
        /// <summary>
        /// Creates a builder.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IPermissionServerBuilder AddPermissionServerBuilder(this IServiceCollection services)
        {
            return new PermissionServerBuilder(services);
        }

        /// <summary>
        /// Adds IdentityServer.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IPermissionServerBuilder AddPermissionServer(this IServiceCollection services)
        {
            var builder = services.AddPermissionServerBuilder();

            //builder
            //    .AddRequiredPlatformServices()
            //    .AddCookieAuthentication()
            //    .AddCoreServices()
            //    .AddDefaultEndpoints()
            //    .AddPluggableServices()
            //    .AddValidators()
            //    .AddResponseGenerators()
            //    .AddDefaultSecretParsers()
            //    .AddDefaultSecretValidators();

            //// provide default in-memory implementation, not suitable for most production scenarios
            //builder.AddInMemoryPersistedGrants();

            return builder;
        }

        /// <summary>
        /// Adds IdentityServer.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns></returns>
        public static IPermissionServerBuilder AddPermissionServer(this IServiceCollection services, Action<PermissionServerOptions> setupAction)
        {
            services.Configure(setupAction);
            return services.AddPermissionServer();
        }

        /// <summary>
        /// Adds the IdentityServer.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IPermissionServerBuilder AddPermissionServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PermissionServerOptions>(configuration);
            return services.AddPermissionServer();
        }
    }
}
