using FashionHexa.Entities;
using FashionHexa.Database;
namespace FashionHexa.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyContext context;
        private readonly ProductService productService;

        public OrderService(MyContext Context)
        {
            context = Context;
           // productService=_productService;
        }

        public Order GetOrder(Guid orderId)
        {
            return context.Orders.Find(orderId);
        }

        public List<Order> GetOrders()
        {
            return context.Orders.ToList();
        }

        public List<Order> GetOrdersByUser(int userId)
        {
            return context.Orders.Where(o => o.UserId == userId).ToList();
        }

        public void PlaceOrder(Order order)
        {
            Product product = new Product();
            product = productService.GetProductById(order.ProductId);
            if (product.Stock > order.Quantity)
            {
                context.Orders.Add(order);
                product.Stock -= order.Quantity;
                context.SaveChanges();
            }
        }
    }
}
