using EventMI.Core.Services;
using EventMI.Infrastructure.Common;
using EventMI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class EventMIServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<EventServices>();

        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EventMIDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IRepository, Repository>();

        return services;
    }
}