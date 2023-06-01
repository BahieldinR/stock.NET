using Stock_System.Model;

namespace Stock_System.Services
{
    public interface IStockService
    {
        public Task<List<Stock>> GetAllStocks();
        public void saveStocks();
    }
}