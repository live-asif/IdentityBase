// Copyright (c) Russlan Akiev. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityBase.Extensions
{
    using IdentityBase.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder InitializeStores(
            this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                IStoreInitializer initializer = serviceScope.ServiceProvider
                    .GetService<IStoreInitializer>();

                if (initializer != null)
                {
                    initializer.InitializeStores();
                }
            }

            return app;
        }

        public static IApplicationBuilder CleanupStores(
            this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                IStoreInitializer initializer = serviceScope.ServiceProvider
                    .GetService<IStoreInitializer>();

                if (initializer != null)
                {
                    initializer.CleanupStores();
                }
            }

            return app;
        }
    }
}
