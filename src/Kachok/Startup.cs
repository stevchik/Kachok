﻿using Kachok.Data;
using Kachok.Data.Logging;
using Kachok.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace Kachok
{
    public class Startup
    {
        IConfiguration configuration { get; set; }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appConfig.json");

            configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = configuration["databases:Kachok"];
            string connectionAudit = configuration["databases:KachokAudit"];

            services.AddDbContext<KachokContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<KachokLoggingContext>(options => options.UseSqlServer(connectionAudit));

            services.AddIdentity<KachokUser, IdentityRole>()
                .AddEntityFrameworkStores<KachokContext>()
                .AddDefaultTokenProviders();

            // Add MVC services to the services container
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddLogging();

            services.AddTransient<KachokContextSeedData>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IRequestLoggingRepository, RequestLoggingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env, KachokContextSeedData seeder, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseRuntimeInfoPage("/info");
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //loggerFactory.AddDebug(LogLevel.Information);
            }

            var filterLoggerFactory = loggerFactory.WithFilter(new FilterLoggerSettings
                 {
                     { "Microsoft", LogLevel.Warning }, 
                     { "System", LogLevel.Warning }, 
                     { "Kachok", LogLevel.Debug }
                });


            filterLoggerFactory.AddProvider(new RequestLoggerProvider(serviceProvider));

            app.UseRequestLogging(filterLoggerFactory);

            app.UseIdentity();

            // Add static files to the request pipeline
            app.UseStaticFiles();

            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "api",
                    template: "{controller}/{id?}");
            });

            await seeder.EnsureSeedDataAsync();
        }
             
        // Entry point for the application.
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseStartup<Startup>()
              .Build();

            host.Run();
        }
    }
}
