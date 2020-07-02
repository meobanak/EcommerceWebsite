using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Database;
using EcommerceWebsite.Database.LiteDB;
using EcommerceWebsite.Service.Interface;
using EcommerceWebsite.Service.LiteDB.EcomerceFashionService;
using Exam1.Models;
using Exam1.Service.Interface;
using Exam1.Service.LiteDB;
using Exam1.Service.LiteDB.EcomerceFashionService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Exam1
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
            services.AddMvc();
            #region Init LiteDB
            services.Configure<LiteDBOptions>(Configuration.GetSection("LiteDbOptions"));
            services.AddSingleton<DataContext, LiteDBContext>();
            services.AddScoped<IDBInit, LiteDB_InitFashionShop>();
            services.AddScoped<IIndex, LiteDB_Index>();
            services.AddTransient<IRegister, LiteDB_Register>();
            #endregion
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
