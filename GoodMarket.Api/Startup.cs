using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using GoodMarket.Persistence;
using GoodMarket.Application;
using GoodMarket.Application;
using GoodMarket.Domain;
using GoodMarket.Api.Middlewares;

namespace GoodMarket.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostEnv { get; set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostEnv = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /* БД */
            services.AddDbContext<GoodMarketDb>(opt =>
            {
                if (HostEnv.IsDevelopment())
                {
                    opt.UseInMemoryDatabase(databaseName: "db_dbmarket");
                }

                if (HostEnv.IsProduction())
                {
                    opt.UseNpgsql(Configuration.GetConnectionString("PostgreSql"), (dbcontext) => { });
                }
            });
          
            /* MediatR */
            services.AddMediatR(typeof(BaseGetQueryHandler<>).Assembly);

            /* Swagger */
            services.AddSwaggerGen((opt) =>
            {
                opt.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title = "My Api", Version = "v1" });
            });

            /* JWT */
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => {
                    opt.RequireHttpsMetadata = true;
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtSettings.ISSUER,

                        ValidateAudience = true,
                        ValidAudience = JwtSettings.AUDIENCE,

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = JwtSettings.GetSymmetricSecurityKey(),
                    };
                });

            /* Контроллеры */
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logfac)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            /* Миграция */
            //var db = app.ApplicationServices.GetService<GoodMarketDb>();
            //if (!db.Database.EnsureCreated())
            //    db.Database.Migrate();

            /* Обработки исключений */
            var logger = logfac.CreateLogger<Startup>();
            app.UseCustomExceptionHandler(logger);
            
            app.UseCors(builder=> {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            /* Swagger */
            app.UseSwagger();
            app.UseSwaggerUI(opt => {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "GoodMarket API v1");
                //opt.RoutePrefix = string.Empty;
            });
            
            /* MVC */
            app.UseAuthentication();
            app.UseMvc();

        }
    }
}
