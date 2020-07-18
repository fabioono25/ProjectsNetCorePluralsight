using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using TennisBookings.Web.Configuration;
using TennisBookings.Web.Core.DependencyInjection;
using TennisBookings.Web.Core.Middleware;
using TennisBookings.Web.Data;
using TennisBookings.Web.Domain;
using TennisBookings.Web.Domain.Rules;
using TennisBookings.Web.External;
using TennisBookings.Web.Services;
using TennisBookings.Web.Services.Notifications;

namespace TennisBookings.Web
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
            services.AddAppConfiguration(Configuration)
                .AddBookingServices()
                .AddBookingRules()
                .AddCourtUnavailability()
                .AddMembershipServices()
                .AddStaffServices()
                //.AddCourtServices() - replaced with Autofac registration in ConfigureContainer
                .AddWeatherForecasting()
                .AddNotifications()
                .AddGreetings()
                .AddCaching()
                .AddTimeServices()
                .AddAuditing();

            //working with service descriptors
            var serviceDescriptor1 = new ServiceDescriptor(typeof(IWeatherForecaster), typeof(WeatherForecaster), ServiceLifetime.Singleton); //instance directly
            var serviceDescriptor2 = ServiceDescriptor.Describe(typeof(IWeatherForecaster), typeof(WeatherForecaster), ServiceLifetime.Singleton); //static
            var serviceDescriptor3 = ServiceDescriptor.Singleton(typeof(IWeatherForecaster), typeof(WeatherForecaster)); //specific static method
            var serviceDescriptor4 = ServiceDescriptor.Singleton<IWeatherForecaster, WeatherForecaster>(); //generic version

            services.Add(serviceDescriptor1);

            //add, remove and prioritizing services
            services.AddHttpClient<IWeatherApiClient, WeatherApiClient>();
            services.AddSingleton<IWeatherForecaster, WeatherForecaster>(); //this will be considered
            //services.TryAddSingleton<IWeatherForecaster, AmazingWeatherForecaster>();
            services.Replace(ServiceDescriptor.Singleton<IWeatherForecaster, AmazingWeatherForecaster>());
            services.RemoveAll<IWeatherForecaster>();

            //registering multiple implementations
            //services.AddSingleton<ICourtBookingRule, ClubIsOpenRule>();
            //services.AddSingleton<ICourtBookingRule, MaxBookingLengthRule>();
            //services.AddSingleton<ICourtBookingRule, MaxPeakTimeBookingLengthRule>();
            //services.AddSingleton<ICourtBookingRule, MemberCourtBookingsMaxHoursPerDayRule>();
            //services.AddSingleton<ICourtBookingRule, MemberCourtBookingsMaxHoursPerDayRule>(); //duplicated

            services.TryAddEnumerable(ServiceDescriptor.Singleton<ICourtBookingRule, ClubIsOpenRule>());
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ICourtBookingRule, MaxBookingLengthRule>());
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ICourtBookingRule, MaxPeakTimeBookingLengthRule>());
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ICourtBookingRule, MemberCourtBookingsMaxHoursPerDayRule>());
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ICourtBookingRule, MemberCourtBookingsMaxHoursPerDayRule>()); //duplicated

            services.TryAddEnumerable(new[]
            {
                ServiceDescriptor.Singleton<ICourtBookingRule, ClubIsOpenRule>(),
                ServiceDescriptor.Singleton<ICourtBookingRule, ClubIsOpenRule>()
            });

            services.TryAddScoped<IBookingRuleProcessor, BookingRuleProcessor>();

            services.TryAddSingleton<IBookingConfiguration>(sp => sp.GetRequiredService<IOptions<BookingConfiguration>>().Value); //Factory

            services.AddSingleton<EmailNotificationService>();
            services.AddSingleton<SmsNotificationService>();

            services.AddSingleton<INotificationService>(sp =>
                new CompositeNotificationService(
                    new INotificationService[]
                    {
                        sp.GetRequiredService<EmailNotificationService>(),
                        sp.GetRequiredService<SmsNotificationService>()
                    })); //composite notification service

            services.AddTransient<IMembershipAdvertBuilder, MembershipAdvertBuilder>(); //legacy or third-party
            services.AddScoped<IMembershipAdvert>(sp =>
            {
                var builder = sp.GetService<IMembershipAdvertBuilder>();

                builder.WithDiscount(10m);

                return builder.Build();
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/FindAvailableCourts");
                    options.Conventions.AuthorizePage("/BookCourt");
                    options.Conventions.AuthorizePage("/Bookings");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddIdentity<TennisBookingsUser, TennisBookingsRole>()
                .AddEntityFrameworkStores<TennisBookingDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddDbContext<TennisBookingDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseLastRequestTracking(); // only track requests which make it to MVC, i.e. not static files
            app.UseMvc();
        }

        // This method is called after ConfigureServices
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CourtMaintenanceService>()
                .As<ICourtMaintenanceService>()
                .InstancePerLifetimeScope();
        }
    }
}
