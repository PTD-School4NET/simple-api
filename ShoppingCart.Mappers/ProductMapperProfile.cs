using AutoMapper;
using ShoppingCart.Dtos;
using ShoppingCart.Models;

namespace ShoppingCart.Mappers
{
    internal class ProductMapperProfile : BaseProfile
    {
        public ProductMapperProfile()
        {
            this.CreateMap<Product, ProductDto>().ForMember(dest => dest.Cost, opt => opt.MapFrom(source => source.Price));
        }
    }
}
