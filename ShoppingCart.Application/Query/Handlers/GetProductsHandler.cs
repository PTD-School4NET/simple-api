using AutoMapper;
using MediatR;
using ShoppingCart.Data.Abstractions;
using ShoppingCart.Dtos;
using ShoppingCart.Models; 
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Query.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        { 
            var productListDb = await this._unitOfWork.GetRepo<Product>().FindAsync(x => !x.IsDeleted, request.Skip, request.Take);

            return this._mapper.Map<List<ProductDto>>(productListDb).ToList(); 
        }
    }
}
