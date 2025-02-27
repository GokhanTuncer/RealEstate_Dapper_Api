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
		
		public async Task CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
		{
            string query = "insert into BottomGrid (Icon,Title,Description) values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createBottomGridDTO.Icon);
            parameters.Add("@title", createBottomGridDTO.Title);
            parameters.Add("@description", createBottomGridDTO.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

		public async Task DeleteBottomGrid(int id)
		{
            string query = "Delete From BottomGrid Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
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

		public async Task<GetBottomGridDTO> GetBottomGrid(int id)
		{
            string query = "Select * From BottomGrid Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDTO>(query, parameters);
                return values;
            }
        }

		public async Task UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO)
		{
            string query = "Update BottomGrid Set Icon=@icon,Title=@title,Description=@description where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateBottomGridDTO.Icon);
            parameters.Add("@title", updateBottomGridDTO.Title);
            parameters.Add("@description", updateBottomGridDTO.Description);
            parameters.Add("@bottomGridID", updateBottomGridDTO.BottomGridID);

            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }
        }
	}
}
