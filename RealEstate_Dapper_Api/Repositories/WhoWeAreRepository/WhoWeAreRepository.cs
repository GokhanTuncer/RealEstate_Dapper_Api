using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
	public class WhoWeAreRepository : IWhoWeAreRepository
	{
		private readonly Context _context;

		public WhoWeAreRepository(Context context)
		{
			_context = context;
		}
		public async void CreateWhoWeareDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO)
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

		public async void DeleteWhoWeareDetail(int id)
		{
			string query = "DELETE FROM WhoWeAreDetail WHERE WhoWeAreDetailID = @whoWeAreDetailID";  //Kategori silinir
			var parameters = new DynamicParameters();
			parameters.Add("@whoWeareDetailID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeareDetailAsync()
		{
			string query = "SELECT * FROM WhoWeAreDetail";  //Kategori çağırılır
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

		public async void UpdateWhoWeareDetail(UpdateWhoWeareDetailDTO updateWhoWeareDetailDTO)
		{
			string query = "UPDATE WhoWeAreDetail SET Title = @title,Subtitle=@subTitle,Description1=@description1,Description1=@description2 where  WhoWeAreDetailID = @whoWeAreDetailID";  //Kategori güncellenir
			var parameters = new DynamicParameters();
			parameters.Add("@title", updateWhoWeareDetailDTO.Title);
			parameters.Add("@subTitle", updateWhoWeareDetailDTO.SubTitle);
			parameters.Add("@description1", updateWhoWeareDetailDTO.Description1);
			parameters.Add("@description2", updateWhoWeareDetailDTO.Description2);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
