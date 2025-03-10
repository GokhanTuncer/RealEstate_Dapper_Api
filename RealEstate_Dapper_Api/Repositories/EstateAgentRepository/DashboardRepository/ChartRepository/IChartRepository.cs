using RealEstate_Dapper_Api.DTOs.ChartDTOs;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository
{
	public interface IChartRepository
	{
		Task<List<ResultChartDTO>> Get5CityForChart();
	}
}
