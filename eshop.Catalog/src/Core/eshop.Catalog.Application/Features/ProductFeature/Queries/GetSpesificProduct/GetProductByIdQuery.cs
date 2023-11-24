using eshop.Catalog.Application.Features.ProductFeature.Queries.GetAllProducts;
using MediatR;

namespace eshop.Catalog.Application.Features.ProductFeature.Queries.GetSpesificProduct
{
    public class GetProductByIdQuery : IRequest<ProductSummaryResponseDto>
    {
        public int ProductId { get; set; }

    }
}
