using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySampleApp.Application.Commands;
using MySampleApp.Application.Queries;
using MySampleApp.Domain.Entities;
using MySampleApp.Domain.Options;

namespace MySampleApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddProduct([FromBody] ProductEntity productEntity)
        {
            var result = await sender.Send(new AddProductCommand(productEntity));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await sender.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int Id)
        {
            var result = await sender.Send(new GetProductByIdQuery(Id));
            if (result == null)
            {
                return NotFound(new { Message = $"No product found with ID = {Id}" });
            }
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int Id, [FromBody] ProductEntity productEntity)
        {
            var result = await sender.Send(new UpdateProductCommand(Id, productEntity));
            if (result == null)
            {
                return NotFound(new { Message = $"No product found with ID = {Id}" });
            }
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int Id)
        {
            var result = await sender.Send(new DeleteProductCommand(Id));
            if (result == null)
            {
                return NotFound(new { Message = $"No product found with ID = {Id}" });
            }
            return Ok(result);
        }
    }
}
