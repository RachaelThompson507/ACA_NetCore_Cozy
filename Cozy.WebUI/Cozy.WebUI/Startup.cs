using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Cozy.Data.Interfaces;
using Cozy.Data.Implementation.Mock;
using Cozy.Data.Implementation.EFCore;
using Cozy.Service.Services;

namespace Cozy.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Repository Layer
            services.AddScoped<IHomeRepository,MockHomeRepository>();
            //services.AddScoped<IHomeRepository, EFCoreHomeRepository>();

            //Service Layer
            services.AddScoped<IHomeService, HomeService>();

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
