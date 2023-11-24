using MediatR;

namespace eshop.Catalog.Application.Features.ProductFeature.Queries.GetAllProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductSummaryResponseDto>>
    {
    }
}
