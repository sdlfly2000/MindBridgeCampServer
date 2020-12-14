using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MindBridgeCampServer
{
    using Common.Core.DependencyInjection;
    using Infrastructure.Data.Sql;
    using Microsoft.EntityFrameworkCore;

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

            services.AddMemoryCache();

            services.AddDbContext<MindBridgeCampDbContext>(
                options => options.UseMySql(
                    Configuration.GetConnectionString("MindBridgeCampDatabase"),
                    b => b.MigrationsAssembly("Infrastructure.Data.Sql")));

            DIModule.RegisterDomain(services, new List<string>
              {
                  "Application.Services",
                  "Domain.Services",
                  "Infrastructure.Data.Sql",
                  "Infrastructure.Data.CacheAgent"
              });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
