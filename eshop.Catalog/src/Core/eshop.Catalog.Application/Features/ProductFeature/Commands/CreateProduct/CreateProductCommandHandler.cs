using AutoMapper;
using eshop.Catalog.Application.Contracts.Logging;
using eshop.Catalog.Application.Contracts.Persistence;
using eshop.Catalog.Application.Exceptions;
using eshop.Catalog.Domain;
using MediatR;

namespace eshop.Catalog.Application.Features.ProductFeature.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IAppLogger<CreateProductCommandHandler> logger;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IAppLogger<CreateProductCommandHandler> logger)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                logger.LogWarning("Create Product Command is invalid!", validatorResult.Errors);
                throw new BadEntityRequestException("Type is invalid", validatorResult);
                //Sadece exception mu fırlatacaksınız?

            }
            var product = mapper.Map<Product>(request);
            await productRepository.CreateAsync(product);
            logger.LogInformation("Product created!");
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
