using GoodMarket.ChatHubs.Consumers;
using GoodMarket.ChatHubs.HostedServices;
using GoodMarket.ChatHubs.Hubs;
using GoodMarket.RabbitMQ;
using GoodMarket.SignalR;
using GoodMarket.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoodMarket.ChatHubs
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
            services.AddGMSignalRServices(Configuration);
            services.AddGMRabbitServices(Configuration);
            
            services.AddHostedService<ChatHubRabbitHostedService>();
            services.AddTransient<BaseQueueConsumer, ChatNotifyQueueConsumer>();
            services.AddMvc((opts) =>
            {
            });
            services.AddGMSwagger(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();

            app.UseEndpoints(conf => {
                conf.MapHub<MainChatHub>("/chathub", connOpts => {
                });

                conf.MapDefaultControllerRoute();
            });

            app.UseGMSwagger("GoodMarket ChatHub Statistics");            
            app.UseHttpsRedirection();
            
        }
    }
}