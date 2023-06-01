using Microsoft.EntityFrameworkCore;
using Stock_System.Model;

namespace Stock_System.Services
{
    public class OrderService : IOrderService
    {
        public MainContext _context;

        public OrderService(MainContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var Orders = await _context.Orders.ToListAsync();

            return Orders;
        }

        public void CreateOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
        }
    }
}