using BwMelder.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder
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
            var connectionString = Configuration["Database"] ?? Configuration.GetConnectionString("DefaultSqlite");

            services.AddDbContext<BwMelderDbContext>(options =>
                options.UseSqlite(connectionString)
            );

            services.AddRazorPages(options =>
            {
                // Allow anonymous access to crew details for coaches.
                options.Conventions.AllowAnonymousToPage("/Crews/Details");
                
                // Allow anonymous access to everything required to manage a single crew.
                options.Conventions.AllowAnonymousToFolder("/Crews/Athletes");
                options.Conventions.AllowAnonymousToFolder("/Crews/HomeCoaches");

                // Allow anonymous access for team coaches so they can add themselves.
                // Note that Index is not included.
                options.Conventions.AllowAnonymousToPage("/TeamCoaches/Create");
                options.Conventions.AllowAnonymousToPage("/TeamCoaches/Details");
                options.Conventions.AllowAnonymousToPage("/TeamCoaches/Edit");
                options.Conventions.AllowAnonymousToPage("/TeamCoaches/Delete");

                // Note that the homepage and login/logout are allowed for anonymous access by attributes.
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Admin/Login";
                    options.LogoutPath = "/Admin/Logout";
                });
            
            // Require authentication on all pages if not specified otherwise.
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
