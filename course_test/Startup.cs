using BusinessLayer.Interfaces;
using BusinessLayer.Implementations;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace course_test
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("DataLayer")));
            services.AddTransient<ICarRepository, EFCarRepository>();
            services.AddTransient<ICarServiceRepository, EFCarServiceRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<ISparepartRepository, EFSparepartRepository>();
            services.AddTransient<IStaffRepository, EFStaffRepository>();
            services.AddTransient<ITimeOrderRepository, EFTimeOrderRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IRoleRepository, EFRoleRepository>();
            services.AddScoped<DataManager>();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("Home/Login");
            //        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("Home/Login");
            //    });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
