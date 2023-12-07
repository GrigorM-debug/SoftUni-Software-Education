using EventMi.Core.Contracts;
using EventMi.Core.Services;
using EventMi.Infrastructure.Common;
using EventMi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventMi.Extensions
{
    public static class EventMIServiceCollectionExtension 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEventServices, EventServices>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EventMiDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
