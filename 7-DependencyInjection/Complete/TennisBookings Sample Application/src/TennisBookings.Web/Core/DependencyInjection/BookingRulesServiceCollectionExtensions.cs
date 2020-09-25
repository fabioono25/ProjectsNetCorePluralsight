using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TennisBookings.Web.Domain.Rules;

namespace TennisBookings.Web.Core.DependencyInjection
{
    public static class BookingRulesServiceCollectionExtensions
    {
        public static IServiceCollection AddBookingRules(this IServiceCollection services)
        {
            // old way
            //services.TryAddEnumerable(new ServiceDescriptor[]
            //{
            //    ServiceDescriptor.Singleton<ICourtBookingRule, ClubIsOpenRule>(),
            //    ServiceDescriptor.Singleton<ICourtBookingRule, MaxBookingLengthRule>()
            //});

            // Scrutor assembly scanning
            services.Scan(scan => scan
                .FromAssemblyOf<ICourtBookingRule>()
                    .AddClasses(classes => classes.AssignableTo<IScopedCourtBookingRule>())
                        .As<ICourtBookingRule>()
                        .WithScopedLifetime()
                    .AddClasses(classes => classes.AssignableTo<ISingletonCourtBookingRule>())
                        .As<ICourtBookingRule>()
                        .WithSingletonLifetime());
            
            services.TryAddScoped<IBookingRuleProcessor, BookingRuleProcessor>();

            return services;
        }
    }
}
