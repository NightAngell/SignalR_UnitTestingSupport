using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleSignalRCoreProject
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Db>(options => options.UseSqlServer(
                 @"Server=(localdb)\mssqllocaldb;
                 Database=SignalRSupportTests;
                 Trusted_Connection=True;
                 ConnectRetryCount=0"
             ));

            services.AddSignalR();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSignalR(options =>
            {
                options.MapHub<ExampleHub>("/exampleHub");
                options.MapHub<ExampleNonGenericHub>("/exampleNonGenericHub");
            });
            app.UseMvc();
        }
    }
}
