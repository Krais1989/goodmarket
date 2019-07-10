using GoodMarket.RabbitMQ;
using GoodMarket.SignalR;
using GoodMarket.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddGMSignalR(Configuration);
            services.AddGMRabbit(Configuration);
            services.AddHostedService<ChatNotifyHostedService>();
            services.AddTransient<BaseQueueConsumer, ChatNotifyQueueConsumer>();
            services.AddMvc((opts) =>
            {
            });
            services.AddGMSwagger(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSignalR(signalR => {
                signalR.MapHub<MainChatHub>("/chathub", connOpts => {
                });
            });
            app.UseGMSwagger("GoodMarket ChatHub Statistics");            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}