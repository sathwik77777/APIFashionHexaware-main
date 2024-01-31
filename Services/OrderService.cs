using FashionHexa.Entities;
using FashionHexa.Database;
namespace FashionHexa.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyContext context;
        public OrderService(MyContext Context)
        {
            context = Context;
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
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
