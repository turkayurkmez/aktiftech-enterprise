using AutoMapper;
using eshop.Catalog.Application.Contracts.Logging;
using eshop.Catalog.Application.Contracts.Persistence;
using MediatR;

namespace eshop.Catalog.Application.Features.ProductFeature.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductSummaryResponseDto>>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly IAppLogger<GetProductsQueryHandler> logger;

        public GetProductsQueryHandler(IMapper mapper, IProductRepository productRepository, IAppLogger<GetProductsQueryHandler> logger)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.logger = logger;
        }

        public async Task<IEnumerable<ProductSummaryResponseDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAsync();
            var response = mapper.Map<IEnumerable<ProductSummaryResponseDto>>(products);
            logger.LogInformation("Products getting from database");
            return response;
        }
    }
}
