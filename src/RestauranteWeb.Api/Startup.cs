using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using RestauranteWeb.Api.Configurations;
using RestauranteWeb.CrossCutting.IoC;
using System.IO;
using System.Reflection;

namespace RestauranteWeb.Api
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
            services.AddMvc()
                    .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddWebApi(options =>
                               {
                                   options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                               });

            services.AddAutoMapperSetup();
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            builder.AddEnvironmentVariables();

            app.UseCors(c =>
                        {
                            c.AllowAnyHeader();
                            c.AllowAnyMethod();
                            c.AllowAnyOrigin();
                        });

            app.UseMvc();

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
                       {
                           routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                       });

            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
                                                                     {
                                                                         settings.GeneratorSettings.DefaultPropertyNameHandling =
                                                                             PropertyNameHandling.CamelCase;
                                                                     });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
