using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminService.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TopTests.API.HUB;
using TopTests.API.StartupExtensions;

namespace TopTests.API
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
            services.AddControllers();
            services
                .AddDataAccessServices(Configuration.GetConnectionString("DefaultConnection"))
                .AddMappingServices()
                .AddServices()
                .AddRepositories()
                .AddJwtAuthentication();

            services.AddCors(options =>
                options.AddPolicy("CorsPolicy",
                    builder =>
                        builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:3000")
                        .AllowCredentials()));
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();
            //app.UseCors(options =>
            //  options
            //  .AllowAnyOrigin()
            //  .AllowAnyMethod()
            //  .AllowAnyHeader()
            //  .WithExposedHeaders("Content-Disposition")
            //  );
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();
            //app.Map("/signalr", map =>
            //{
            //    map.UseCors(CorsOptions);

            //    map.Provider(new OAuthBearerAuthenticationOptions()
            //    {
            //        Provider = new QueryStringOAuthBearerProvider()
            //    });

            //    var hubConfiguration = new HubConfiguration
            //    {
            //        Resolver = GlobalHost.DependencyResolver,
            //    };
            //    map.RunSignalR(hubConfiguration);
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<TimerHub>("/timer", options =>
                {
                    options.Transports =
                        HttpTransportType.WebSockets;
                });
            });
        }
    }
}
