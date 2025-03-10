using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductsController : ControllerBase
    {
        private readonly ILast5ProductsRepository _lastProductsRepository;

        public EstateAgentLastProductsController(ILast5ProductsRepository last5ProductsRepository)
        {
            _lastProductsRepository = last5ProductsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetLast5ProductAsync(int id)
        {
            var values = await _lastProductsRepository.GetLast5ProductAsync(id);
            return Ok(values);
        }
    }
}
