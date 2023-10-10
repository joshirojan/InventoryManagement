using InventoryManagement.Dtos.StockDto;
using InventoryManagement.Models;

namespace InventoryManagement.Services.StockServices
{
    public interface IStockService
    {
        Task<List<Stock>> GetAllStockAsync();

        Task<Stock> GetStockAsync(int stockId);
        Task<Stock> CreateStockAsync(Stock stock);

        Task<Stock> UpdateStockAsync(Stock stock, CreateStockDto CreateStockDto);

        Task<Stock> DeleteStockAsync(Stock stock);

        Task<List<Stock>> SearchStockAsync(string keyword);
    }
}
