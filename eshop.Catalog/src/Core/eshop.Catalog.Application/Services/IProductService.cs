using eshop.Catalog.Application.DataTransferObjects.Requests;
using eshop.Catalog.Application.DataTransferObjects.Responses;

namespace eshop.Catalog.Application.Services
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductRequest createProductRequest);
        Task<int> UpdateProduct(UpdateProductRequest updateProductRequest);
        Task<IEnumerable<ProductSummaryResponse>> GetProductSummaries();
    }
}
