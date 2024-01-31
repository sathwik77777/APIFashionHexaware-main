using FashionHexa.Entities;
using FashionHexa.Database;

namespace FashionHexa.Services
{
    public class SellerService : ISellerService
    {
        private readonly MyContext context;
        public SellerService(MyContext Context)
        {
            context = Context;
        }
        public void AddSeller(Seller seller)
        {
            try
            {
                context.Sellers.Add(seller);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deleteseller(int userId)
        {
            try
            {
                
                Seller seller = context.Sellers.SingleOrDefault(p => p.UserId == userId); 
                context.Sellers.Remove(seller);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Seller> GetAllSeller()
        {
            try
            {
                return context.Sellers.ToList(); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Seller GetSellerById(int userId)
        {
            try
            {
                
                Seller seller = context.Sellers.SingleOrDefault(p => p.UserId == userId);
                return seller;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdaterSeller(Seller seller)
        {
            try
            {
                context.Sellers.Update(seller);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Seller ValidteUser(string email, string password)
        {
            return context.Sellers.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
