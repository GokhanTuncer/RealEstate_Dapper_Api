using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDTO categoryDTO)
        {
            string query = "INSERT INTO Category (CategoryName, CategoryStatus) VALUES (@CategoryName, @CategoryStatus)";  //Yeni Kategori oluşturulur
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", categoryDTO.CategoryName);
            parameters.Add("@CategoryStatus",true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "DELETE FROM Category WHERE CategoryID = @CategoryID";  //Kategori silinir
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
        {
            string query= "SELECT * FROM Category";  //Kategori çağırılır
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async void UpdateCategory(UpdateCategoryDTO categoryDTO)
        {
            string query = "UPDATE Category SET CategoryName = @CategoryName, CategoryStatus = @CategoryStatus WHERE CategoryID = @CategoryID";  //Kategori güncellenir
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", categoryDTO.CategoryName);
            parameters.Add("@CategoryStatus", categoryDTO.CategoryStatus);
            parameters.Add("@CategoryID", categoryDTO.CategoryID);
            using (var connection =_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
