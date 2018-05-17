using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Webjs.Models;
using Microsoft.EntityFrameworkCore;

namespace Webjs
{

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<ModelNewsContext>(options => 
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NewsModel;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddTransient<src.IUpdateNews, src.UpdateNews>();

            services.AddTransient<src.IUpdateDB, src.UpdateDB>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, src.IUpdateNews updateNews, src.IUpdateDB updateDB)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(e =>
            {
                e.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}" );
            });

            app.UseAuthentication();

            updateDB.UpdateDb(updateNews.Update());
        }
    }
}
