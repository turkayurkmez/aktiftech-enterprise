using FluentValidation;

namespace eshop.Catalog.Application.Features.ProductFeature.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            /*Validasyonu oluşturmak için iki pattern'den faydalandı:
             * 1. Spesification
             * 2. Builder Pattern
             * 3. Chain of Responsibility
             */
            RuleFor(product => product.Name)
                   .NotEmpty().WithMessage("{PropertyName} is required")
                   .NotNull()
                   .MaximumLength(70).WithMessage("{PropertyName} must be less than 70")
                   .MinimumLength(2).WithMessage("{PropertyName} must be more than 2");
        }
    }
}
