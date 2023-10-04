﻿using AutoMapper;
using InventoryManagement.Dtos.IssueProductDto;
using InventoryManagement.Models;
using InventoryManagement.Services.IssueProductServices;
using InventoryManagement.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            var newCreateIssueProductDto = _mapper.Map<CreateIssueProductDto>(returnVal);

            return Ok(newCreateIssueProductDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateIssueProductDto createIssueProductDto)
        {
            if (createIssueProductDto == null)
                return BadRequest();

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

            var newCreateIssueProductDto = _mapper.Map<CreateIssueProductDto>(retVal);

            return Ok(newCreateIssueProductDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
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