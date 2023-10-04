using AutoMapper;
using InventoryManagement.Dtos.StockDto;
using InventoryManagement.Models;
using InventoryManagement.Services.StockServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        public StockController(IStockService stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
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

            Stock stock = new Stock
            {
                ProductId = createStockDto.ProductId,
                Quantity = createStockDto.Quantity,
            };

            var returnVal = await _stockService.CreateStockAsync(stock);

            var newStockDto = _mapper.Map<CreateStockDto>(returnVal);

            return Ok(newStockDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateStockDto createStockDto)
        {

            if (createStockDto == null)
                return BadRequest();

            var stock = await _stockService.GetStockAsync(id);

            if (stock == null)
                return NotFound();

            var retVal = await _stockService.UpdateStockAsync(stock, createStockDto);

            var newStockDto = _mapper.Map<CreateStockDto>(retVal);

            return Ok(newStockDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
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
