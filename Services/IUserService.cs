using FashionHexa.Entities;
namespace FashionHexa.Services
{
    public interface IUserService
    {
        void CreateUser(User user); //Done
        List<User> GetAllUsers(); //Done
        
        User GetUser(int userId);
        void EditUser(User user); //Done
        void DeleteUser(int userId); //Done
        User ValidteUser(string email, string password); //Done
    }
}
