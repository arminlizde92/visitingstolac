using System;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VisitingStolac.API.IoC;
using VisitingStolac.API.Middleware;

namespace VisitingStolac.API
{
    public class Startup
    {
        /// <summary> private instance of Icontainer </summary>
        private IContainer _appContainer { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary> public instance of iconfiguration </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region IOC Setup

            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            Type[] controllerTypes = typeof(Startup).Assembly.GetExportedTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();

            containerBuilder.RegisterTypes(controllerTypes).PropertiesAutowired();

            // mock module
            containerBuilder.RegisterModule(new MockModule());

            // actual module
            //containerBuilder.RegisterModule(new AppModule(Configuration));

            _appContainer = containerBuilder.Build();

            #endregion

            return new AutofacServiceProvider(_appContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandlingMiddleware();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
