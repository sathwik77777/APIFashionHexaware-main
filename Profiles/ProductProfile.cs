using AutoMapper;
using FashionHexa.DTO;
using FashionHexa.Entities;
namespace FashionHexa.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

        }
    }
}
