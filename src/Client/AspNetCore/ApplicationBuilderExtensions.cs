// Copyright (c) Brock Allen, Dominick Baier, Michele Leroux Bustamante. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Healox.PermissionServer.Client.AspNetCore;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// PolicyServer extensions for IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Add the policy server claims transformation middleware to the pipeline.
        /// This middleware will turn application roles and permissions into claims and add them to the current user
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static IApplicationBuilder UsePolicyServerClaims(this IApplicationBuilder app)
        {
            return app.UseMiddleware<PermissionServerClaimsMiddleware>();
        }
    }
}