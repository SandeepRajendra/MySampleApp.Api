using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySampleApp.Application.Queries;

namespace MySampleApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalProductController(ISender sender) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAllExternalProduct()
        {
            var result = await sender.Send(new GetExternalProductDataQuery());
            return Ok(result);
        }
    }
}
