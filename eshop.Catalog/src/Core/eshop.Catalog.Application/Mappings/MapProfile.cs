using AutoMapper;
using eshop.Catalog.Application.DataTransferObjects.Requests;
using eshop.Catalog.Application.DataTransferObjects.Responses;
using eshop.Catalog.Application.Features.ProductFeature.Commands.CreateProduct;
using eshop.Catalog.Application.Features.ProductFeature.Commands.UpdateProduct;
using eshop.Catalog.Application.Features.ProductFeature.Queries.GetAllProducts;
using eshop.Catalog.Domain;

namespace eshop.Catalog.Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductSummaryResponse>();
            CreateMap<Product, ProductSummaryResponseDto>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
