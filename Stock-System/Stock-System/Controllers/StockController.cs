using Microsoft.AspNetCore.Mvc;
using Stock_System.Model;
using Stock_System.Services;

namespace Stock_System.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        public MainContext _context;
        public IStockService _stock;

        public StockController(MainContext context, IStockService stock)
        {
            _stock = stock;
            _context = context;
        }

        // retrieve all the stocks from the database
        [HttpGet()]
        public async Task<IActionResult> GetAllStock()
        {
            var stocks = await _stock.GetAllStocks();
            return Ok(stocks);
        }

        //update the price for all the stocks
        [HttpPut()]
        public async Task<IActionResult> UpdatePrices()
        {
            var stocks = await _stock.GetAllStocks();

            foreach (var stock in stocks)
            {
                stock.stockPrice = GetRandomPrice();
            }
            _stock.saveStocks();
            return Ok();
        }

        private int GetRandomPrice()
        {
            var random = new Random();
            return random.Next(1, 101);
        }
    }
}