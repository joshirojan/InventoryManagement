using InventoryManagement.Dtos.ProductDto;
using InventoryManagement.Models;

namespace InventoryManagement.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductAsync();

        Task <Product> GetProductAsync(int productId);
        Task <Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product, CreateProductDto createProductDto);

        Task<Product> DeleteProductAsync(Product product);

        Task<List<Product>> SearchProductAsync(string keyword);

    }
}
