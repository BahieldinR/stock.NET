using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock_System.Model;
using Stock_System.Services;

namespace Stock_System.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public MainContext _context;
        public IOrderService _service;

        public OrderController(MainContext context, IOrderService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var Orders = await _service.GetAllOrders();

            if (Orders == null)
            {
                return NotFound();
            }

            return Ok(Orders);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] Order newOrder)
        {
            //Validate the input model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the stock name exists in the Stock table
            var stock = await _context.Stocks.FirstAsync(s => s.stockName == newOrder.stockName);

            if (stock == null)
            {
                return BadRequest("Stock not found");
            }

            // Check if the required stock amount is found
            if (stock.stockQuantity < newOrder.quantity)
            {
                return BadRequest("not enough stock available");
            }

            if (newOrder.quantity < 0)
            {
                return BadRequest("quantity cannot have a negative value");
            }

            int totalPrice = stock.stockPrice * newOrder.quantity;

            // Reduce the ordered stock quantity
            stock.stockQuantity -= newOrder.quantity;

            var order = new Order
            {
                stockID = stock.stockId,
                person = newOrder.person,
                stockName = newOrder.stockName,
                quantity = newOrder.quantity,
                price = totalPrice
            };

            // Add the order to the Orders table
            _service.CreateOrder(order);

            return Ok();
        }
    }
}