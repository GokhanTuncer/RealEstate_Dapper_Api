using Dapper;
using RealEstate_Dapper_Api.DTOs.ProductDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDTO>> GetAllProductAsync()
        {
            string query = "SELECT * FROM Product";  
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync()
        {

            string query = "SELECT ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay FROM Product INNER JOIN Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }

		public async Task<List<ResultProductDTO>> GetLast5ProductAsync()
		{
			string query = "SELECT Top(5) * FROM Product Order By ProductID Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultProductDTO>(query);
				return values.ToList();
			}
		}

		public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId",id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
