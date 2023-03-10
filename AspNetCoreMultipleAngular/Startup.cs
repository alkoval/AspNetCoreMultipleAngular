using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace AspNetCoreMultipleAngular
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
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            /*services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });*/
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
            /*if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }*/

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value == "/")
                {
                    context.Request.Path = "/clientapp";
                }

                await next();
            });

            app.Map(new PathString("/clientapp"), client =>
            {
                var path = env.IsDevelopment() ? @"ClientApp" : @"ClientApp/dist";
                var clientAppDist = new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), path))
                };
                client.UseSpaStaticFiles(clientAppDist);

                if (env.IsDevelopment())
                {
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp";
                        spa.UseAngularCliServer(npmScript: "start");
                    });
                }
                else
                {
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp";
                        spa.Options.DefaultPageStaticFileOptions = clientAppDist;
                    });
                }
            });

            app.Map(new PathString("/clientapp2"), client =>
            {
                var path = env.IsDevelopment() ? @"ClientApp2" : @"ClientApp2/dist";
                var clientAppDist = new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), path))
                };
                client.UseSpaStaticFiles(clientAppDist);

                if (env.IsDevelopment())
                {
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp2";
                        spa.UseAngularCliServer(npmScript: "start");
                    });
                }
                else
                {
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp2";
                        spa.Options.DefaultPageStaticFileOptions = clientAppDist;
                    });
                }
            });

            app.Map(new PathString("/clientapp3"), client =>
            {
                var path = env.IsDevelopment() ? @"ClientApp3" : @"ClientApp3/dist/my-first-app";
                var clientAppDist = new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), path))
                };
                client.UseSpaStaticFiles(clientAppDist);

                if (env.IsDevelopment())
                {
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp3";
                        spa.UseAngularCliServer(npmScript: "start");
                    });
                }
                else
                {
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp3";
                        spa.Options.DefaultPageStaticFileOptions = clientAppDist;
                    });
                }
            });

            app.Map(new PathString("/clientapp3-2"), client =>
            {
                var path = env.IsDevelopment() ? @"ClientApp3" : @"ClientApp3/dist/my-second-app";
                var clientAppDist = new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), path))
                };
                client.UseSpaStaticFiles(clientAppDist);

                if (env.IsDevelopment())
                {
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp3";
                        spa.UseAngularCliServer(npmScript: "start-2");
                    });
                }
                else
                {
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp3";
                        spa.Options.DefaultPageStaticFileOptions = clientAppDist;
                    });
                }
            });
        }
    }
}
