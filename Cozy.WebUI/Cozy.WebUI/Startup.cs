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
using Cozy.Domain.Models;
using Cozy.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace Cozy.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Repository Layer
            //Mock REPOS
            //GetDependencyResolvedForRepositoryLayer(services);

            //EFCore REPOS
            GetDependencyResolvedForEFCoreRepositoryLayer(services);

            //Service Layer
            GetDependencyResolvedForServiceLayer(services);

            services.AddDbContext<CozyDbContext>();

            //service for Identitiy
            services.AddIdentity<AppUser,IdentityRole>()
                .AddEntityFrameworkStores<CozyDbContext>();

            //HW Find Out How to set DIFFERENT options for Password Creation

            //MVC
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

            //use Identity Service
            app.UseAuthentication();

            //Controller-View-?id
            //Home-Index-Optional
            app.UseMvcWithDefaultRoute();

        }
        private void GetDependencyResolvedForRepositoryLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeRepository, MockHomeRepository>();
            services.AddScoped<ILeaseRepository, MockLeaseRepository>();
            //services.AddScoped<ILandlordRepository, MockLandlordRepository>();
            services.AddScoped<IMaintenanceRepository, MockMaintenanceRepository>();
            services.AddScoped<IMaintenanceStatusRepository, MockMaintenanceStatusRepository>();
            services.AddScoped<IPaymentRepository, MockPaymentRepository>();
            //services.AddScoped<ITenantRepository, MockTenantRepository>();
        }

        private void GetDependencyResolvedForEFCoreRepositoryLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeRepository, EFCoreHomeRepository>();
            services.AddScoped<ILeaseRepository, EFCoreLeaseRepository>();
            //services.AddScoped<ILandlordRepository, EFCoreLandlordRepository>();
            services.AddScoped<IMaintenanceRepository, EFCoreMaintenanceRepository>();
            services.AddScoped<IMaintenanceStatusRepository, EFCoreMaintenanceStatusRepository>();
            services.AddScoped<IPaymentRepository, EFCorePaymentRepository>();
            //services.AddScoped<ITenantRepository, EFCoreTenantRepository>();
        }

        private void GetDependencyResolvedForServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ILeaseService, LeaseService>();
            //services.AddScoped<ILandlordService, LandlordService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<IMaintenanceStatusService, MaintenanceStatusService>();
            services.AddScoped<IPaymentService, PaymentService>();
            //services.AddScoped<ITenantService, TenantService>();
        }
    }
}
