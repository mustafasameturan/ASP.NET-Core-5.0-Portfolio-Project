using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using PortfolioCoreProject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CorePortfolio
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization(option =>
                {
                    var type = typeof(SharedResource);
                    var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                    var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                    var localizer = factory.Create("SharedResource", assemblyName.Name);
                    option.DataAnnotationLocalizerProvider = (t, f) => localizer;
                });      
            services.AddNotyf(config => { config.DurationInSeconds = 8; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
            services.AddDbContext<Context>();
            services.AddIdentity<SystemUser, SystemRole>()
                .AddEntityFrameworkStores<Context>();


            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            //services.AddAuthentication(
            //    CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(x =>
            //    {
            //        x.LoginPath = "/User/Login/Index/";
            //    });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.AccessDeniedPath = "/ErrorPage/Index/";
                options.LoginPath = "/User/Login/Index/";
            });

            //Validators
            //services.AddSingleton<PortfolioValidator>();
            //services.AddSingleton<ExperienceValidator>();
            //services.AddSingleton<ServiceValidator>();
            //services.AddSingleton<SkillValidator>();
            //services.AddSingleton<SocialMediaValidator>();
            //services.AddSingleton<AnnouncementValidator>();
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

            var suportedCultures = new[]
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("tr-TR"),
                SupportedCultures = suportedCultures,
                SupportedUICultures = suportedCultures
            });

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseNotyf();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Default}/{id?}"
                );
            });
        }
    }
}
