using InventoryManagement.Data;
using InventoryManagement.Dtos.StockDto;
using InventoryManagement.Models;
using InventoryManagement.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services.StockServices
{
    public class StockService:IStockService
    {
        private readonly ApiDbContext _dbContext;

        public StockService(ApiDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Stock>> SearchStockAsync(string keyword)
        {
            if (keyword == null)
            {
                var stocks = await _dbContext.Stocks.Include(p => p.Product).ToListAsync();
                return stocks;
            }
            var matchingStocks = _dbContext.Stocks.Include(p => p.Product)
                .Where(x => x.Product.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();
            return matchingStocks;
        }
        public async Task<Stock> CreateStockAsync(Stock stock)
        {
            stock.CreatedDate = DateTime.Now;
            await _dbContext.Stocks.AddAsync(stock);

            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == stock.ProductId);
            product.Stock += stock.Quantity;


            await _dbContext.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock> DeleteStockAsync(Stock stock)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == stock.ProductId);
            product.Stock -= stock.Quantity;

            _dbContext.Stocks.Remove(stock);
            await _dbContext.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllStockAsync()
        {
            return await _dbContext.Stocks.Include(p => p.Product)
                .ThenInclude(q => q.Category)
                .ToListAsync();
        }

        public async Task<Stock?> GetStockAsync([FromRoute] int stockId)
        {
            var stock = await _dbContext.Stocks.Include(p => p.Product)
                .ThenInclude(q => q.Category)
                .FirstOrDefaultAsync(x => x.Id == stockId);
            return stock;
        }

        public async Task<Stock> UpdateStockAsync(Stock stock, CreateStockDto createStockDto)
        {
        
            if (stock.ProductId == createStockDto.ProductId)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == stock.ProductId);
                product.Stock -= stock.Quantity;
                product.Stock += createStockDto.Quantity;
            }
            else
            {
                var prevProd = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == stock.ProductId);
                prevProd.Stock -= stock.Quantity;

                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == createStockDto.ProductId);
                product.Stock += createStockDto.Quantity;

            }

            stock.ProductId = createStockDto.ProductId;
            stock.Quantity = createStockDto.Quantity;

            await _dbContext.SaveChangesAsync();
            return stock;
        }

    }
}
