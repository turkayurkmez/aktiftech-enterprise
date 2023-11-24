using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Domain;
using eshop.Catalog.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace eshop.Catalog.Persistence.Repositories
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public ProductRepository(CatalogDbContext catalogDbContext) : base(catalogDbContext)
        {
        }

        public async Task<IEnumerable<Product>> SearchProductByName(string productName)
        {
            return await this.catalogDbContext.Products.Where(p => p.Name.Contains(productName)).ToListAsync();
        }
    }
}
