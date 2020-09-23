using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TennisBookings.Web.Configuration;
using TennisBookings.Web.Services;
using System.Linq;
using Microsoft.Extensions.Options;

namespace TennisBookings.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IWeatherForecaster, WeatherForecaster>();
            //services.AddTransient<IWeatherForecaster, AmazingWeatherForecaster>(); //it will consider the last registration (TryAddSingleton)
            services.Replace(ServiceDescriptor.Singleton<IWeatherForecaster, AmazingWeatherForecaster>()); // remove previous registration - RemoveAll

            //using IOptions to register strongly-typed object
            services.Configure<FeaturesConfiguration>(Configuration.GetSection("Features"));

            // using Service Descrptors
            //var serviceDescriptor1 = ServiceDescriptor.Transient<IWeatherForecaster, WeatherForecaster>();
            services.TryAddSingleton<IBookingConfiguration>(sp => sp.GetRequiredService<IOptions<BookingConfiguration>>().Value);
            //services.Add(serviceDescriptor1);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseMvc();
        }
    }
}
