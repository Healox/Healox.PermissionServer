// Copyright (c) Brock Allen, Dominick Baier, Michele Leroux Bustamante. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Healox.PermissionServer.Client;
using Healox.PermissionServer.Local;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Helper class to configure DI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the policy server client.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static PermissionServerBuilder AddPolicyServerClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Policy>(configuration);
            services.AddTransient<IPermissionServerClient, PermissionServerClient>();
            services.AddScoped(provider => provider.GetRequiredService<IOptionsSnapshot<Policy>>().Value);

            return new PermissionServerBuilder(services);
        }
    }
}