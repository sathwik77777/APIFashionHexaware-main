using AutoMapper;
using FashionHexa.DTO;
using FashionHexa.Entities;
namespace FashionHexa.Profiles
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDTO>();
            CreateMap<BrandDTO, Brand>();

        }

    }
}
