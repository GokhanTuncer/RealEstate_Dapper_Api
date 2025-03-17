using Dapper;
using RealEstate_Dapper_Api.DTOs.AppUserDTOs;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetAppUserByProductIDDTO> GetAppUserByProductID(int id)
        {
            string query = "SELECT * FROM AppUser WHERE AppUserID = @UserID";
            var parameters = new DynamicParameters();
            parameters.Add("@UserID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIDDTO>(query, parameters);
                return values;
            }
        }
    }
}
