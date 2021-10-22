using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos
{
    public class GetProductsDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
