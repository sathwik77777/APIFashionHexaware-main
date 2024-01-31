using AutoMapper;
using FashionHexa.DTO;
using FashionHexa.Entities;
namespace FashionHexa.Profiles
{
    public class SellerProfile : Profile
    {
        public SellerProfile() 
        {
            CreateMap<Seller, SellerDTO>();
            CreateMap<SellerDTO, Seller>();
        
        }

    }
}
