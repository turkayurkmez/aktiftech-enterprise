using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Persistence.DbContexts;
using eshop.Catalog.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Catalog.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //CatalogDbContext catalogDbContext
            //IProductRepository productRepository

            services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CatalogDbConnectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;

        }
    }
}
