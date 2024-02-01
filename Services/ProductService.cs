using FashionHexa.Entities;
using FashionHexa.Database;
namespace FashionHexa.Services
{
    public class ProductService : IProductService
    {
        private readonly MyContext context;
        public ProductService(MyContext Context)
        {
            context = Context;
        }
        public void AddProduct(Product product) //Add Product 
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {

                Product product = context.Products.SingleOrDefault(p => p.ProductId == productId);
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProductById(int productId)
        {
            try
            {

                Product product = context.Products.SingleOrDefault(p => p.ProductId == productId);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                return context.Products.ToList(); //ToList() return all products in the form of List
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetProductsByPrice(double price)
        {
            try
            {
                List<Product> products =
                context.Products.Where(item => item.Price > price).ToList();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetProductByName(string productName)
        {
            try
            {

                return context.Products.Where(p => p.Name == productName).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*public bool UpdateProductQuantity(int productId, int Quantity) 
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                if(Quantity >= 0 && Quantity <= product.quantity)
                {
                    product.quantity = Quantity;
                    return true;
                }
            }
            return false;
            
        }*/


        /*public List<Product> GetproductBySeller(int userId)
        {
            try
            {
                return context.Products.Where(p => p.UserId == userId).ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }*/
    }
}
