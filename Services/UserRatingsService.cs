using FashionHexa.Entities;
using FashionHexa.Database;
using Microsoft.EntityFrameworkCore;

namespace FashionHexa.Services
{
    public class UserRatingsService : IUserRatingsService
    {
        private readonly MyContext context;
        public UserRatingsService(MyContext Context)
        {
            context = Context;
        }

        public void AddRating(UserRatings userRatings)
        {
            context.UserRatings.Add(userRatings);
            context.SaveChanges();
        }

        public void DeleteRating(int UserRatingsId)
        {
            UserRatings userRatings = context.UserRatings.FirstOrDefault(Ur => Ur.UserRatingsId == UserRatingsId);
            if (userRatings != null)
            {
                context.UserRatings.Remove(userRatings);
                context.SaveChanges();
            }
        }

        public List<UserRatings> GetUserRatings(int userId)
        {
            return context.UserRatings.Where(ur => ur.UserId == userId).ToList();
        }



        public void UpdateRating(UserRatings userRatings)
        {
            context.UserRatings.Update(userRatings);
            context.SaveChanges();
        }
    }
}
