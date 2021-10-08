using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using ShoppingCart.Application.Query;
using ShoppingCart.Dtos; 
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {  
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        public async Task<IActionResult> Get()
        {
            var listOfProducts = await this._mediator.Send(new GetProductsQuery());

            return Ok(listOfProducts);
        }
    }
}
