using AutoMapper;
using InventoryManagement.Dtos.IssueProductDto;
using InventoryManagement.Dtos.ProductDto;
using InventoryManagement.Models;
using InventoryManagement.Services.IssueProductServices;
using InventoryManagement.Services.ProductServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IssueProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IIssueProductService _issueProductService;
        private readonly IMapper _mapper;
        public IssueProductController(IIssueProductService issueProductService, IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _issueProductService = issueProductService;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchIssueProducts(string? keyword)
        {
            if (keyword == null)
            {
                var allIssueProducts = await _issueProductService.GetAllIssueProductAsync();
                return Ok(allIssueProducts);
            }
            var issueProducts = await _issueProductService.SearchIssueProductAsync(keyword);

            var issueProductDto = _mapper.Map<List<CreateIssueProductDto>>(issueProducts);

            return Ok(issueProductDto);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var issueProducts = await _issueProductService.GetAllIssueProductAsync();

            var createProductDto = _mapper.Map<List<CreateIssueProductDto>>(issueProducts);

            return Ok(createProductDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var issueProduct = await _issueProductService.GetIssueProductAsync(id);

            if (issueProduct == null)
                return NotFound();

            var createProductDto = _mapper.Map<CreateIssueProductDto>(issueProduct);

            return Ok(createProductDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIssueProductDto createIssueProductDto)
        {
            if (createIssueProductDto == null)
                return BadRequest();

            var productfromdb = await _productService.GetProductAsync(createIssueProductDto.ProductId);
            if (productfromdb != null)
            {
                if (createIssueProductDto.Quantity > productfromdb.Stock)
                {
                    return BadRequest("Stock not available");
                }
            }

            IssueProduct issueProduct = new IssueProduct
            {
                UserId = createIssueProductDto.UserId,
                ProductId = createIssueProductDto.ProductId,
                Quantity = createIssueProductDto.Quantity
            };

            var returnVal = await _issueProductService.CreateIssueProductAsync(issueProduct);

            var sendVal = await _issueProductService.GetIssueProductAsync(returnVal.Id);

            var newCreateIssueProductDto = _mapper.Map<CreateIssueProductDto>(sendVal);

            return Ok(newCreateIssueProductDto);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateIssueProductDto createIssueProductDto)
        {
            if (createIssueProductDto == null)
                return BadRequest();
            if(createIssueProductDto.UserId==0)
                return BadRequest("Select User");
            if (createIssueProductDto.ProductId == 0)
                return BadRequest("Select User");
            if (createIssueProductDto.Quantity == 0)
                return BadRequest("Select User");

            var issueProduct = await _issueProductService.GetIssueProductAsync(id);

            if (issueProduct == null)
                return NotFound();

            var productfromdb = await _productService.GetProductAsync(createIssueProductDto.ProductId);
            if (productfromdb != null)
            {
                if (createIssueProductDto.Quantity > productfromdb.Stock)
                {
                    return BadRequest("Stock not available");
                }
            }

            var retVal = await _issueProductService.UpdateIssueProductAsync(issueProduct, createIssueProductDto);

            var sendVal = await _issueProductService.GetIssueProductAsync(retVal.Id);

            var newCreateIssueProductDto = _mapper.Map<CreateIssueProductDto>(sendVal);

            return Ok(newCreateIssueProductDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var issueProduct = await _issueProductService.GetIssueProductAsync(id);

            if (issueProduct == null)
                return NotFound();

            var retVal = await _issueProductService.DeleteIssueProductAsync(issueProduct);

            var newCreateIssueProductDto = _mapper.Map<CreateIssueProductDto>(retVal);

            return Ok(newCreateIssueProductDto);
        }
    }
}
