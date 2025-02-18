using Dapper;
using RealEstate_Dapper_Api.DTOs.BottomGridDTOs;
using RealEstate_Dapper_Api.DTOs.ProductDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
	public class BottomGridRepository : IBottomGridRepository
	{
		private readonly Context _context;

		public BottomGridRepository(Context context)
		{
			_context = context;
		}
		
		public Task CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
		{
			throw new NotImplementedException();
		}

		public Task DeleteBottomGrid(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync()
		{
			string query = "SELECT * FROM BottomGrid";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultBottomGridDTO>(query);
				return values.ToList();
			}
		}

		public Task<GetBottomGridDTO> GetBottomGrid(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO)
		{
			throw new NotImplementedException();
		}
	}
}
