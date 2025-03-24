using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
	public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
	{
		private readonly Context _context;

		public WhoWeAreDetailRepository(Context context)
		{
			_context = context;
		}
		public async Task CreateWhoWeareDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO)
		{

			string query = "INSERT INTO WhoWeAreDetail (Title, SubTitle,Description1,Description2) VALUES (@title, @subTitle,@description1,@description2)";  
			var parameters = new DynamicParameters();
			parameters.Add("@title", createWhoWeAreDetailDTO.Title);
			parameters.Add("@subTitle", createWhoWeAreDetailDTO.SubTitle);
			parameters.Add("@description1", createWhoWeAreDetailDTO.Description1);
			parameters.Add("@description2", createWhoWeAreDetailDTO.Description2);		
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteWhoWeareDetail(int id)
		{
			string query = "DELETE FROM WhoWeAreDetail WHERE WhoWeAreDetailID = @whoWeAreDetailID";  
			var parameters = new DynamicParameters();
			parameters.Add("@whoWeareDetailID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeareDetail()
		{
			string query = "SELECT * FROM WhoWeAreDetail";  
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultWhoWeAreDetailDTO>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id)
		{
			string query = "SELECT * FROM WhoWeAreDetail WHERE WhoWeAreDetailID = @whoWeAreDetailID";
			var parameters = new DynamicParameters();
			parameters.Add("@WhoWeAreDetailID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDTO>(query, parameters);
				return values;
			}
		}

		public async Task UpdateWhoWeareDetail(UpdateWhoWeareDetailDTO updateWhoWeareDetailDTO)
		{
			string query = "Update WhoWeAreDetail Set Title=@title,Subtitle=@subTitle,Description1=@description1,Description2=@description2 where WhoWeAreDetailID=@whoWeAreDetailID";
			var parameters = new DynamicParameters();
			parameters.Add("@title", updateWhoWeareDetailDTO.Title);
			parameters.Add("@Subtitle", updateWhoWeareDetailDTO.SubTitle);
			parameters.Add("@description1", updateWhoWeareDetailDTO.Description1);
			parameters.Add("@description2", updateWhoWeareDetailDTO.Description2);
			parameters.Add("@whoWeAreDetailID", updateWhoWeareDetailDTO.WhoWeAreDetailID);
			using (var connectiont = _context.CreateConnection())
			{
				await connectiont.ExecuteAsync(query, parameters);
			}
		}
	}
}
