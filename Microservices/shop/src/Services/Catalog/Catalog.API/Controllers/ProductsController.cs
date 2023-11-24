using Catalog.API.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using shop.Messages;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublishEndpoint _endpoint;

        public ProductsController(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        [HttpPut]
        public async Task<IActionResult> DiscountProduct(Product product)
        {
            //varsayın ki db'yi güncellediniz.
            var oldPrice = 100;
            var newPrice = product.Price;

            var productPriceChanged = new ProductPriceChanged { NewPrice = newPrice, OldPrice = oldPrice, ProductId = product.Id };

            //TODO 1: Burada event fırlatılacak.
            await _endpoint.Publish(productPriceChanged);

            return Ok();
        }
    }
}
