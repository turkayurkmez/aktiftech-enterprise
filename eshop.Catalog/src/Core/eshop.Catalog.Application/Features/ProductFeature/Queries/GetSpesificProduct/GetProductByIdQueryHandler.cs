using AutoMapper;
using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Application.Features.ProductFeature.Queries.GetAllProducts;
using MediatR;

namespace eshop.Catalog.Application.Features.ProductFeature.Queries.GetSpesificProduct
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductSummaryResponseDto>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductSummaryResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);
            var response = mapper.Map<ProductSummaryResponseDto>(product);
            return response;
        }
    }
}
