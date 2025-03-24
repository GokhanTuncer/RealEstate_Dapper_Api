using Dapper;
using RealEstate_Dapper_Api.DTOs.ProductDetailDTOs;
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

        public async Task CreateProduct(CreateProductDTO createProductDTO)
        {
            string query = "INSERT INTO Product (Title,Price,City,District,CoverImage,Address,Description,Type,DealOfTheDay,AdvertisementDate,ProductStatus,ProductCategory,EmployeeID) VALUES (@Title,@Price,@City,@District,@CoverImage,@Address,@Description,@Type,@DealOfTheDay,@AdvertisementDate,@ProductStatus,@ProductCategory,@EmployeeID)";  
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDTO.Title);
            parameters.Add("@Price", createProductDTO.Price);
            parameters.Add("@City", createProductDTO.City);
            parameters.Add("@District", createProductDTO.District);
            parameters.Add("@CoverImage", createProductDTO.CoverImage);
            parameters.Add("@Address", createProductDTO.Address);
            parameters.Add("@Description", createProductDTO.Description);
            parameters.Add("@Type", createProductDTO.Type);
            parameters.Add("@DealOfTheDay", createProductDTO.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDTO.AdvertisementDate);
            parameters.Add("@ProductStatus", createProductDTO.ProductStatus);
            parameters.Add("@ProductCategory", createProductDTO.ProductCategory);
            parameters.Add("@EmployeeID", createProductDTO.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
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

        public async Task<List<ResultLast3ProductWithCategoryDTO>> GetLast3ProductAsync()
        {
            string query = "Select Top(3) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where Type='Kiralık' Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync()
		{
			string query = "Select Top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where Type='Kiralık' Order By ProductID Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDTO>(query);
				return values.ToList();
			}
		}

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheday From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeId and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDTO>(query, parameters);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDTO>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheday From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeId and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheday From Product inner join Category on Product.ProductCategory=Category.CategoryID where DealOfTheDay=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIDDTO> GetProductByProductID(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,description,CategoryName,CoverImage,Type,Address,DealOfTheday,AdvertisementDate,SlugUrl From Product inner join Category on Product.ProductCategory=Category.CategoryID where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIDDTO>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<GetProductByProductIDDTO> GetProductDetailByProductID(int id)
        {
            string query = "Select * From ProductDetails Where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIDDTO>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductWithSearchListDTO>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = "Select * From Product Where Title like '%" + searchKeyValue + "%' And ProductCategory=@propertyCategoryId And City=@city";
            var parameters = new DynamicParameters();
           
            parameters.Add("@propertyCategoryId", propertyCategoryId);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}
