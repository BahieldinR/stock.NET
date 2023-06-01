using Microsoft.EntityFrameworkCore;
using Stock_System.Model;

namespace Stock_System.Services
{
    public class StockService : IStockService
    {
        public MainContext _context;

        public StockService(MainContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllStocks()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return stocks;
        }

        public void saveStocks()
        {
            _context.SaveChanges();
        }
    }
}