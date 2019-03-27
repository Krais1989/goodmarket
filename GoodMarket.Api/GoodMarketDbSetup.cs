using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Persistence
{
    public static class GoodMarketDbSetup
    {
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<GoodMarketDb>();

                if (!dbContext.Database.EnsureCreated())
                {
                    dbContext.Database.Migrate();
                }
#if DEBUG
                dbContext.Populate();
#endif
            }

            return webHost;
        }
    }
}
