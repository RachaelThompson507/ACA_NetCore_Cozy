using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Cozy.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cozy.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Add A Connection String- need to fix it later
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=Cozy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Add a service for DB
            services.AddDbContext<CozyDbContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //use static files first then use MVC
            app.UseStaticFiles();

            //Controller-View-?id
            //Home-Index-Optional
            app.UseMvcWithDefaultRoute();

        }
    }
}
