using Kachok.Data;
using Kachok.Data.Interfaces;
using Kachok.Infrastructure.Logging;
using Kachok.Model;
using Kachok.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
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
using System.Net;
using System.Threading.Tasks;

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

            services.AddIdentity<KachokUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 5;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                            ctx.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        return Task.FromResult(0);
                    }
                };
            })
            .AddEntityFrameworkStores<KachokContext>()
            .AddDefaultTokenProviders();

            // Add MVC services to the services container
            services.AddMvc(config =>
            {
#if !DEBUG
                config.Filters.Add(new RequireHttpsAttribute());
#endif
            })
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddLogging();

            services.AddTransient<KachokContextSeedData>();

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();

            services.AddScoped<IRequestLoggingRepository, RequestLoggingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env, KachokContextSeedData seeder, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseRuntimeInfoPage("/info");
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            var filterLoggerFactory = loggerFactory.WithFilter(new FilterLoggerSettings
                 {
                     { "Microsoft", LogLevel.Warning },
                     { "System", LogLevel.Warning },
                     { "Kachok", LogLevel.Debug }
                });
            filterLoggerFactory.AddProvider(new RequestLoggerProvider(serviceProvider));
            app.UseRequestLogging(filterLoggerFactory);

            var filterLoggerFactoryDebug = loggerFactory.WithFilter(new FilterLoggerSettings
                 {
                     { "Microsoft.EntityFrameworkCore", LogLevel.Debug },
                     { "Microsoft", LogLevel.Warning },
                     { "System", LogLevel.Warning },
                     { "Kachok", LogLevel.Debug }
                });
            filterLoggerFactoryDebug.AddProvider(new CustomLoggerProvider());

            app.UseIdentity();

            // Add static files to the request pipeline
            app.UseStaticFiles();

            AutoMapperBootstrap.Initialize(serviceProvider);

            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Site", action = "Index" });

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
