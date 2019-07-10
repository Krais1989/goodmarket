using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Application.Mappers;
using GoodMarket.Application.RabbitMq;
using GoodMarket.Authentication;
using GoodMarket.Domain;
using GoodMarket.IdentityApi;
using GoodMarket.Persistence;
using GoodMarket.RabbitMQ;
using GoodMarket.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GoodMarket.IdentityApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GoodMarketIdentityDbContext>(db =>
            {
                db.UseInMemoryDatabase("db_test_identity");
            });

            services.AddDbContext<GoodMarketDbContext>(db =>
            {
                db.UseInMemoryDatabase("db_test");
            });

            /* Конфигурация Identity */
            var confSection = Configuration.GetSection("IdentityOptions");
            services.Configure<IdentityOptions>(confSection);
            var idOpts = confSection.Get<IdentityOptions>();
            services.AddIdentityCore<User>(opt => {
                opt.User = idOpts.User;
                opt.Password = idOpts.Password;
                opt.SignIn = idOpts.SignIn;
                opt.Lockout = idOpts.Lockout;
            })
            .AddRoles<Role>()
            /* Необходимо переопределить UserStore, иначе, к примеру, падает при попытке получить IdentityUserClaim */
            .AddUserStore<UserStore<User, Role, GoodMarketIdentityDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>>()
            /* Необходимо переопределить RoleStore, иначе, к примеру, падает при попытке получить IdentityUserRole */
            .AddRoleStore<RoleStore<Role, GoodMarketIdentityDbContext, int, UserRole, RoleClaim>>()
            .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, Role>>()
            .AddUserManager<GMUserManager>()
            .AddRoleManager<GMRoleManager>()
            .AddSignInManager<GMSignInManager>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<GoodMarketIdentityDbContext>();

            services.AddTransient<AccountRegistrationQueueProducer>();
            services.AddGMRabbit(Configuration);
            services.AddGMMediatoR();
            services.AddGMAuthentication(Configuration);
            services.AddGMSwagger();
            services.AddGMAutoMapping();
            services.AddMvc()
                .AddGMValidators()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGMExceptionHandling();
            app.UseGMExecutionTimeTracking();
            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseGMSwagger("GoodMarket Identity v1");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
