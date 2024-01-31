using FashionHexa.Entities;
namespace FashionHexa.Services
{
    public interface IUserRatingsService
    {
        void AddRating(UserRatings userRatings);
        List<UserRatings> GetUserRatings(int userId);
        void UpdateRating(UserRatings userRatings);
        void DeleteRating(int UserRatingsId);
    }
}
