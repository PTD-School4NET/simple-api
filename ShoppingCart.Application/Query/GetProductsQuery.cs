using MediatR;
using ShoppingCart.Dtos;
using System.Collections.Generic;

namespace ShoppingCart.Application.Query
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
