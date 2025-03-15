using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    public class ProductImagesController : Controller
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImagesController(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductImageByID(int id)
        {
            var values = await _productImageRepository.GetProductImageByProductID(id);
            return Ok(values);
        }
    }
}
