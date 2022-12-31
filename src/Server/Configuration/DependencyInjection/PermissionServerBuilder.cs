// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using System;

namespace Healox.PermissionServer.Configuration.DependencyInjection
{
    /// <summary>
    /// IdentityServer helper class for DI configuration
    /// </summary>
    public class PermissionServerBuilder : IPermissionServerBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionServerBuilder"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <exception cref="System.ArgumentNullException">services</exception>
        public PermissionServerBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        public IServiceCollection Services { get; }
    }
}