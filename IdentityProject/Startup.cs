using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
//
using Microsoft.AspNetCore.Identity;
using IdentityProject.Models;
using IdentityProject.Services;

namespace IdentityProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //mvc services
            services.AddMvc();

            //identity services
            services.AddIdentity<IdentityUser, IdentityRole>(
                    option =>
                    {
                        option.User.RequireUniqueEmail = true;
                        option.Password.RequireDigit = true;
                        option.Password.RequiredLength = 6;
                        option.Password.RequireLowercase = true;
                        option.Password.RequireNonAlphanumeric = true;
                        option.Password.RequireUppercase = true;

                    }
                ).AddEntityFrameworkStores<MyDbContext>();
            services.AddDbContext<MyDbContext>();

            //config access denied
            services.ConfigureApplicationCookie(
                option =>
                {
                    option.AccessDeniedPath = "/Account/Denied";
                }
                    );

            services.AddScoped<IDataService<Profile>, DataService<Profile>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //...
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
