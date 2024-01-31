using AutoMapper;
using FashionHexa.DTO;
using FashionHexa.Entities;
namespace FashionHexa.Profiles
{
    public class UserRatingsProfile : Profile
    {
        public UserRatingsProfile() 
        {
            CreateMap<UserRatings, UserRatingsDTO>();
            CreateMap<UserRatingsDTO, UserRatings>();
        }
    }
}
