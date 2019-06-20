using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Authentication;
using GoodMarket.Domain;
using GoodMarket.IdentityApi;
using GoodMarket.Persistence;
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
            services.AddGMMediatoR();
            services.AddDbContext<GoodMarketIdentityDbContext>(b =>
            {
                b.UseInMemoryDatabase("db_test_identity");
            });
            
            services
                .AddIdentityCore<User>(opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                    opt.SignIn.RequireConfirmedEmail = true;

                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                })
                .AddRoles<Role>()
                /* Необходимо переопределить UserStore, иначе, к примеру, падает при попытке получить IdentityUserClaim */
                .AddUserStore<UserStore<User, Role, GoodMarketIdentityDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>>()
                /* Необходимо переопределить RoleStore, иначе, к примеру, падает при попытке получить IdentityUserRole */
                .AddRoleStore<RoleStore<Role, GoodMarketIdentityDbContext, int, UserRole, RoleClaim>>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User,Role>>()
                .AddUserManager<GMUserManager>()
                .AddRoleManager<GMRoleManager>()
                .AddSignInManager<GMSignInManager>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<GoodMarketIdentityDbContext>();

            services.AddGMAuthentication(Configuration);
            services.AddGMSwagger();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
            app.UseGMSwagger();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
