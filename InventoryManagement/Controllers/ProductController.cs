using AutoMapper;
using InventoryManagement.Dtos.ProductDto;
using InventoryManagement.Models;
using InventoryManagement.Services.ProductServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;  
            _mapper = mapper;
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts(string? keyword)
        {
            if (keyword == null)
            {
                var allProducts = await _productService.GetAllProductAsync();
                return Ok(allProducts);
            }
            var products = await _productService.SearchProductAsync(keyword);
          
            var productDto = _mapper.Map<List<ProductDto>>(products);

            return Ok(productDto);
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductAsync();

            var productDto = _mapper.Map<List<ProductDto>>(products);

            return Ok(productDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
                return NotFound();

            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto == null)
                return BadRequest();

            if (createProductDto.CategoryId == 0)
                return BadRequest("Select Category");

            Product product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                CategoryId = createProductDto.CategoryId,
            };

            var returnVal = await _productService.CreateProductAsync(product);

            var sendVal = await _productService.GetProductAsync(returnVal.Id);

            var productDto = _mapper.Map<ProductDto>(sendVal);

            return Ok(productDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateProductDto createProductDto)
        {

            if (createProductDto == null)
                return BadRequest();

            if (createProductDto.CategoryId == 0) {
                return BadRequest("Select Category");
            }

            var product = await _productService.GetProductAsync(id);

            if (product == null)
                return NotFound();

            var retVal = await _productService.UpdateProductAsync(product, createProductDto);

            var sendVal = await _productService.GetProductAsync(retVal.Id);

            var newProductDto = _mapper.Map<ProductDto>(sendVal);

            return Ok(newProductDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
                return NotFound();

            var retVal = await _productService.DeleteProductAsync(product);

            var newProductDto = _mapper.Map<CreateProductDto>(retVal);

            return Ok(newProductDto);
        }
    }
}
