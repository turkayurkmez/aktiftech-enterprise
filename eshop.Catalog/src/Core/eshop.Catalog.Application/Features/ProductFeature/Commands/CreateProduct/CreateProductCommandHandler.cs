using AutoMapper;
using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Domain;
using MediatR;

namespace eshop.Catalog.Application.Features.ProductFeature.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            await productRepository.CreateAsync(product);
            return product.Id;
        }

        //public async Task<int> Handle(CreateProductCommand command)
        //{
        //    var product = mapper.Map<Domain.Product>(command);
        //    await productRepository.CreateAsync(product);
        //    return product.Id;
        //}
    }
}
