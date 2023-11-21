using AutoMapper;
using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Application.DataTransferObjects.Requests;
using eshop.Catalog.Application.DataTransferObjects.Responses;
using eshop.Catalog.Domain;

namespace eshop.Catalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<int> CreateProduct(CreateProductRequest createProductRequest)
        {
            var product = mapper.Map<Product>(createProductRequest);
            await productRepository.CreateAsync(product);
            return product.Id;
        }

        public Task<IEnumerable<ProductSummaryResponse>> GetProductSummaries()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            throw new NotImplementedException();
        }
    }
}
