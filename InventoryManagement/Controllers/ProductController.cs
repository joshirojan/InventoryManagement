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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;  
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {

            if (createProductDto == null)
                return BadRequest();

            Product product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                CategoryId = createProductDto.CategoryId,
            };

            var returnVal = await _productService.CreateProductAsync(product);

            var newProductDto = _mapper.Map<CreateProductDto>(returnVal);

            return Ok(newProductDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateProductDto createProductDto)
        {

            if (createProductDto == null)
                return BadRequest();

            var product = await _productService.GetProductAsync(id);

            if (product == null)
                return NotFound();

            var retVal = await _productService.UpdateProductAsync(product, createProductDto);

            var newProductDto = _mapper.Map<CreateProductDto>(retVal);

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
