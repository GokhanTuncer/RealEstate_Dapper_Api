using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.ChartDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository
{
	public class ChartRepository : IChartRepository
	{
		private readonly Context _context;

		public ChartRepository(Context context)
		{
			_context = context;
		}

		public async Task<List<ResultChartDTO>> Get5CityForChart()
		{
			string query = "Select Top(5) City,Count(*) as 'CityCount' From Product Group By City order by CityCount Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultChartDTO>(query);
				return values.ToList();
			}
		}
	}
}
