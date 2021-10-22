using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using ShoppingCart.Application.Query;
using ShoppingCart.Common.Exceptions;
using ShoppingCart.Dtos; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {   
        private readonly IMediator _mediator; 

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator; 
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        public async Task<IActionResult> Get(GetProductsDto getProductsDto)
        {
            var query = new GetProductsQuery()
            {
                Skip = getProductsDto.Skip,
                Take = getProductsDto.Take
            };

            var listOfProducts = await this._mediator.Send(query);

            return Ok(listOfProducts);
        }
    }
}
