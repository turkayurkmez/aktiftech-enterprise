using eshop.Catalog.Domain;

namespace eshop.Catalog.Application.Contracts.Persistence
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> SearchProductByName(string productName);
    }
}
