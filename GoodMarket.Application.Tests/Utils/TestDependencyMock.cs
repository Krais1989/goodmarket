using GoodMarket.Application;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Application.Tests
{
    /// <summary>
    /// Настройка зависимостей для тестов
    /// Не должны работать с внешними источниками данных
    /// </summary>
    public static class TestDependencyMock
    {
        public static IServiceCollection Create()
        {
            return new ServiceCollection().ConfigureTest();
        }

        public static IServiceCollection ConfigureTest(this IServiceCollection services)
        {
            /* Test factories */
            //services.AddSingleton<TestEntityFactory<Account>>();
            //services.AddSingleton<TestEntityFactory<Product>>();

            services.AddDbContext<TestGoodMarketDb>(opt=> {
                opt.UseInMemoryDatabase(databaseName: "db_test");
            });

            services.AddIdentity<User, Role>(opt => { })
                .AddUserManager<AccountManager>()
                .AddRoleManager<AccountRoleManager>()
                .AddSignInManager<AccountSignManager>()
                .AddEntityFrameworkStores<TestGoodMarketDb>()
                .AddDefaultTokenProviders();

            //services.AddIdentityCore<Account>(opt => { })
            //    .AddRoles<Role>()
            //    .AddUserManager<AccountManager>()
            //    .AddRoleManager<AccountRoleManager>()
            //    .AddEntityFrameworkStores<TestGoodMarketDb>()
            //    .AddDefaultTokenProviders();

            services.AddScoped<UserManager<User>, AccountManager>();

            services.AddMediatR(typeof(BaseGetQueryHandler<>).Assembly);
            return services;
        }

    }
}
