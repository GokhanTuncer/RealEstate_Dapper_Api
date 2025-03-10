using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstateAgentDashboardStatisticController : ControllerBase
	{
		private readonly IStatisticRepository _statisticRepository;

		public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository)
		{
			_statisticRepository = statisticRepository;
		}

		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_statisticsRepository.ActiveCategoryCount());
		}
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_statisticsRepository.ActiveCategoryCount());
		}
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_statisticsRepository.ActiveCategoryCount());
		}
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_statisticsRepository.ActiveCategoryCount());
		}
	}
}
