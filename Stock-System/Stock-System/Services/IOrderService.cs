using Stock_System.Model;

namespace Stock_System.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order newOrder);

        Task<List<Order>> GetAllOrders();
    }
}