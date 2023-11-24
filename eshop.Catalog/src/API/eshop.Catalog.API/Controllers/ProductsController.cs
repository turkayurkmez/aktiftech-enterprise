using eshop.Catalog.Application.Features.ProductFeature.Commands.CreateProduct;
using eshop.Catalog.Application.Features.ProductFeature.Commands.UpdateProduct;
using eshop.Catalog.Application.Features.ProductFeature.Queries.GetAllProducts;
using eshop.Catalog.Application.Features.ProductFeature.Queries.GetSpesificProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetProductByIdQuery() { ProductId = id };
            var product = await mediator.Send(query);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductCommand createProductCommand)
        {
            var lastId = await mediator.Send(createProductCommand);
            return lastId != 0 ? CreatedAtAction(nameof(Get), routeValues: new { id = lastId }, null) : BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateProductCommand updateProductCommand)
        {
            if (ModelState.IsValid)
            {
                updateProductCommand.Id = id;
                await mediator.Send(updateProductCommand);
                return Ok();
            }
            return BadRequest(ModelState);

        }

    }
}
