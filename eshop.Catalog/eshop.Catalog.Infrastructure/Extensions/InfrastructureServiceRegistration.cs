using eshop.Catalog.Application.Contracts.Logging;
using eshop.Catalog.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Catalog.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
