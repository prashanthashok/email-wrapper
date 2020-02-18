using email_wrapper.Contracts;
using email_wrapper.Helpers;
using email_wrapper.Models;
using email_wrapper.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace email_wrapper
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
            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
            services.AddScoped<IEmailHelperRepository, EmailHelperRepository>();
            services.AddScoped<SendGridHelper>();
            services.AddScoped<MailGunHelper>();

            services.AddTransient<Func<EmailProviderEnum, IEmailHelper>>(serviceProvider => key =>
            {
                switch(key)
                {
                    case EmailProviderEnum.MailGun:
                        return serviceProvider.GetService<MailGunHelper>();
                    case EmailProviderEnum.SendGrid:
                        return serviceProvider.GetService<SendGridHelper>();
                    default:
                        return null;

                }
            });

            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddOptions();
            //services.AddScoped<IEmailHelper, SendGridHelper>();
            //services.AddScoped<IEmailHelper, MailGunHelper>();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
