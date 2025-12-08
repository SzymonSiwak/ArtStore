using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ArtStore.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
