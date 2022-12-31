﻿// Copyright (c) Brock Allen, Dominick Baier, Michele Leroux Bustamante. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Healox.PermissionServer.Client.AspNetCore;

namespace Healox.PermissionServer.Client
{
    /// <summary>
    /// Helper object to build the PolicyServer DI configuration
    /// </summary>
    public class PermissionServerBuilder
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionServerBuilder"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public PermissionServerBuilder(IServiceCollection services)
        {
            Services = services;
        }

        /// <summary>
        /// Adds the authorization policy provider to automatically map permissions to ASP.NET Core authorization policies.
        /// </summary>
        /// <returns></returns>
        public PermissionServerBuilder AddAuthorizationPermissionPolicies()
        {
            Services.AddAuthorization();
            Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            Services.AddTransient<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            Services.AddTransient<IAuthorizationHandler, PermissionHandler>();

            return this;
        }
    }
}