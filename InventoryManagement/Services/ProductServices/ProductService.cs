using InventoryManagement.Data;
using InventoryManagement.Dtos.ProductDto;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagement.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly ApiDbContext _dbContext;
        public ProductService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            product.CreatedDateTime = DateTime.Now;
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }


        public async Task<Product> DeleteProductAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            var products = await _dbContext.Products.Include(p => p.Category).ToListAsync();
            return products;
        }

        public async Task<Product?> GetProductAsync([FromRoute] int productId)
        {
            var product =  await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(x => x.Id == productId);
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product, CreateProductDto createProductDto)
        {
            product.Name = string.IsNullOrEmpty(createProductDto.Name) ? product.Name : createProductDto.Name;
            product.Description = string.IsNullOrEmpty(createProductDto.Description) ? product.Description : createProductDto.Description;
            product.ImageUrl = string.IsNullOrEmpty(createProductDto.ImageUrl) ? product.ImageUrl : createProductDto.ImageUrl;
            product.CategoryId = (createProductDto.CategoryId == 0) ? product.CategoryId : createProductDto.CategoryId;
            await _dbContext.SaveChangesAsync();
            return product;
        }




    }
}
