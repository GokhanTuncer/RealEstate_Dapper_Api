﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.ProductDTOs;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan günün fırsatları arasına eklendi");
        }
        [HttpGet("ProductDealOfTheDayStatusChangeTofalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan günün fırsatlarından çıkarıldı");
        }
        [HttpGet("Last5ProductList")]
		public async Task<IActionResult> Last5ProductList()
		{
			var values = await _productRepository.GetLast5ProductAsync();
			return Ok(values);
		}
        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertListByEmployeeByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByFalse(id);
            return Ok(values);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productRepository.CreateProduct(createProductDTO);
            return Ok("Ilan Başarıyla eklendi");
        }

        [HttpGet("GetProductByProductID")]
        public async Task<IActionResult> GetProductByProductID(int id)
        {
            var values = await _productRepository.GetProductByProductID(id);
            return Ok(values);
        }
        

    }
}
