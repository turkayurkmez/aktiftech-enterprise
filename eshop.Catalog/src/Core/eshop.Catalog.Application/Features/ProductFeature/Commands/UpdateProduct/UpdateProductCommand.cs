using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eshop.Catalog.Application.Features.ProductFeature.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(70)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int? CategoryId { get; set; }
    }
}
