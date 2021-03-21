using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExampleSignalRCoreProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Db>(options => options.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;
                 Database=SignalRSupportTests;
                 Trusted_Connection=True;
                 ConnectRetryCount=0"));

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ExampleHub>("/exampleHub");
                endpoints.MapHub<ExampleNonGenericHub>("/exampleNonGenericHub");
            });
        }
    }
}
