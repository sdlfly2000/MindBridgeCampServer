using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql;
using Microsoft.EntityFrameworkCore;
using Common.Core.LogService;
using MindBridgeCampServer.Middlewares;
using Core;

namespace MindBridgeCampServer
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

            services.AddLogging();

            services.AddMemoryCache();

            services.AddDbContext<MindBridgeCampDbContext>(
                options => options.UseMySql(
                    Configuration.GetConnectionString("MindBridgeCampDatabase"),
                    b => b.MigrationsAssembly("Infrastructure.Data.Sql")));

            DIModule.RegisterDomain(services, new List<string>
              {
                  "MindBridgeCampServer",
                  "Application.Services",
                  "Domain.Services",
                  "Infrastructure.Data.Sql",
                  "Infrastructure.Data.CacheAgent",
                  "Infrastructure.File"
              });

            RegisterCache.Register(services, new List<string>
            {
                "Domain.Services"
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.Map("/ChatMessage", (builder) =>
            {
                builder.UseMiddleware<IWebsocketMiddleware>();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            LogService.SetProvider(app.ApplicationServices);
        }
    }
}
