using AutoMapper;
using InventoryManagement.Dtos.ProductDto;
using InventoryManagement.Dtos.StockDto;
using InventoryManagement.Models;
using InventoryManagement.Services.StockServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        public StockController(IStockService stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchStocks(string? keyword)
        {
            if (keyword == null)
            {
                var allStocks = await _stockService.GetAllStockAsync();
                return Ok(allStocks);
            }
            var stocks = await _stockService.SearchStockAsync(keyword);

            var stockDto = _mapper.Map<List<CreateStockDto>>(stocks);

            return Ok(stockDto);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllStockAsync();

            var stockDto = _mapper.Map<List<CreateStockDto>>(stocks);

            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockService.GetStockAsync(id);

            if (stock == null)
                return NotFound();

            var stockDto = _mapper.Map<CreateStockDto>(stock);

            return Ok(stockDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto createStockDto)
        {

            if (createStockDto == null)
                return BadRequest();

            if (createStockDto.ProductId == 0)
            {
                return BadRequest("Select Product");
            }

            if (createStockDto.Quantity == 0)
            {
                return BadRequest("Enter Quantity Value");
            }

            Stock stock = new Stock
            {
                ProductId = createStockDto.ProductId,
                Quantity = createStockDto.Quantity,
                CreatedDate = DateTime.Now,
            };

            var returnVal = await _stockService.CreateStockAsync(stock);

            var sendVal = await _stockService.GetStockAsync(returnVal.Id);

            var newStockDto = _mapper.Map<CreateStockDto>(sendVal);

            return Ok(newStockDto);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateStockDto createStockDto)
        {

            if (createStockDto == null)
                return BadRequest();

            var stock = await _stockService.GetStockAsync(id);

            if (stock == null)
                return NotFound();

            var retVal = await _stockService.UpdateStockAsync(stock, createStockDto);

            var sendVal = await _stockService.GetStockAsync(retVal.Id);

            var newStockDto = _mapper.Map<CreateStockDto>(retVal);

            return Ok(newStockDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var stock = await _stockService.GetStockAsync(id);


            if (stock == null)
                return NotFound();

            var retVal = await _stockService.DeleteStockAsync(stock);


            var newStockDto = _mapper.Map<CreateStockDto>(retVal);

            return Ok(newStockDto);
        }
    }
}
