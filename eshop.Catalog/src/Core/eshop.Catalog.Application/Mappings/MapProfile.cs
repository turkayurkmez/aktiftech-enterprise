using AutoMapper;
using eshop.Catalog.Application.DataTransferObjects.Requests;
using eshop.Catalog.Application.DataTransferObjects.Responses;
using eshop.Catalog.Domain;

namespace eshop.Catalog.Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductSummaryResponse>();
        }
    }
}
