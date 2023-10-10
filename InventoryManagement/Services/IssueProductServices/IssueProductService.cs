using AutoMapper;
using InventoryManagement.Data;
using InventoryManagement.Dtos.IssueProductDto;
using InventoryManagement.Dtos.StockDto;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services.IssueProductServices
{
    public class IssueProductService : IIssueProductService
    {
        private readonly ApiDbContext _dbContext;
        public IssueProductService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IssueProduct>> SearchIssueProductAsync(string keyword)
        {
            if (keyword == null)
            {
                var issueProducts = await _dbContext.IssueProducts.Include(p => p.User)
                .ThenInclude(o => o.role)
                .Include(q => q.Product)
                .ThenInclude(r => r.Category)
                .ToListAsync();
                return issueProducts;
            }
            var matchingIssueProducts = _dbContext.IssueProducts.Include(p => p.User)
                .ThenInclude(o => o.role)
                .Include(q => q.Product)
                .ThenInclude(r => r.Category)
                .Where(x => x.User.FullName.ToLower().Contains(keyword.ToLower()))
                .ToList();
            return matchingIssueProducts;
        }
        public async Task<IssueProduct> CreateIssueProductAsync(IssueProduct issueProduct)
        {
            issueProduct.CreatedDate = DateTime.Now;
            await _dbContext.IssueProducts.AddAsync(issueProduct);

            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == issueProduct.ProductId);
            product.Stock -= issueProduct.Quantity;

            await _dbContext.SaveChangesAsync();
            return issueProduct;
        }

        public async Task<IssueProduct> DeleteIssueProductAsync(IssueProduct issueProduct)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == issueProduct.ProductId);
            product.Stock += issueProduct.Quantity;

            _dbContext.IssueProducts.Remove(issueProduct);
            await _dbContext.SaveChangesAsync();
            return issueProduct;
        }

        public async Task<List<IssueProduct>> GetAllIssueProductAsync()
        {
            return await _dbContext.IssueProducts.Include(p => p.User)
                .ThenInclude(o => o.role)
                .Include(q => q.Product)
                .ThenInclude(r => r.Category)
                .ToListAsync();
        }

        public async Task<IssueProduct?> GetIssueProductAsync([FromRoute] int issueProductId)
        {
            var issueProduct = await _dbContext.IssueProducts.Include(p => p.User)
                .ThenInclude(o => o.role)
                .Include(q => q.Product)
                .ThenInclude(r => r.Category)
                .FirstOrDefaultAsync(x => x.Id == issueProductId);
            return issueProduct;
        }

        public async Task<IssueProduct> UpdateIssueProductAsync(IssueProduct issueProduct, CreateIssueProductDto createIssueProductDto)
        {
            if (issueProduct.ProductId == createIssueProductDto.ProductId)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == issueProduct.ProductId);
                product.Stock += issueProduct.Quantity;
                product.Stock -= createIssueProductDto.Quantity;
            }
            else
            {
                var prevProd = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == issueProduct.ProductId);
                prevProd.Stock += createIssueProductDto.Quantity;

                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == createIssueProductDto.ProductId);
                product.Stock -= createIssueProductDto.Quantity;

            }
            issueProduct.UserId = createIssueProductDto.UserId;
            issueProduct.ProductId = createIssueProductDto.ProductId;
            issueProduct.Quantity = createIssueProductDto.Quantity;
            await _dbContext.SaveChangesAsync();
            return issueProduct;
        }
    }
}
