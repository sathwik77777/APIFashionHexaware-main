using FashionHexa.Entities;

namespace FashionHexa.Services
{
    public interface IOrderService
    {
        void PlaceOrder(Order order); //Done
        Order GetOrder(Guid orderId); //Done
        List<Order> GetOrdersByUser(int userId); //Done
        List<Order> GetOrders(); //Done
    }
}
