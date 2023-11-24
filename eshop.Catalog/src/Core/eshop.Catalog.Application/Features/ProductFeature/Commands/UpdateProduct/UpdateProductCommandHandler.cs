using AutoMapper;
using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Domain;
using MediatR;

namespace eshop.Catalog.Application.Features.ProductFeature.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            await productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
