using FashionHexa.Entities;
using FashionHexa.Database;

namespace FashionHexa.Services
{
    public class UserService: IUserService
    {
        private readonly MyContext Context;
        public UserService(MyContext context)
        {
            Context = context;
        }
        public void CreateUser(User user)
        {
            try
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUser(int userId)
        {
            User user = Context.Users.Find(userId);
            if (user != null)
            {
                Context.Users.Remove(user);
                Context.SaveChanges();
            }
        }

        public void EditUser(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            var result= Context.Users.ToList();
            return result;
        }

        public User GetUser(int userId)  
        {
            return Context.Users.Find(userId);
        }

        public User ValidteUser(string email, string password)
        {
            return Context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
        
    }
}
