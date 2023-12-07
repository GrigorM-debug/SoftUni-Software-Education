using EventMI.Core.Contracts;
using EventMI.Core.Services;
using EventMI.Infrastructure.Common;
using EventMI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventMe.Extensions
{
    public static class EventMeServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEventServices, EventServices>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventMIDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
