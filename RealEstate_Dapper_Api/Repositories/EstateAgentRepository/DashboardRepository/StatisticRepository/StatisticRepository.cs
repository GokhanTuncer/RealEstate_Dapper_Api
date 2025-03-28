﻿using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
	public class StatisticRepository : IStatisticRepository
	{
		private readonly Context _context;
		public StatisticRepository(Context context)
		{
			_context = context;
		}
		public int AllProductCount()
		{
			string query = "Select Count(*) From Product";
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ProductCountByEmployeeID(int id)
		{
			string query = "Select Count(*) From Product where EmployeeID = @employeeID";
			var parameters = new DynamicParameters();
			parameters.Add("@employeeID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query, parameters);
				return values;
			}
		}

		public int ProductCountByStatusFalse(int id)
		{
			string query = "Select Count(*) From Product where EmployeeID = @employeeId And ProductStatus=0";
			var parameters = new DynamicParameters();
			parameters.Add("@employeeId", id);
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query, parameters);
				return values;
			}
		}

		public int ProductCountByStatusTrue(int id)
		{
			string query = "Select Count(*) From Product where EmployeeID = @employeeId And ProductStatus=1";
			var parameters = new DynamicParameters();
			parameters.Add("@employeeId", id);
			using (var connection = _context.CreateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query, parameters);
				return values;
			}
		}
	}
}
