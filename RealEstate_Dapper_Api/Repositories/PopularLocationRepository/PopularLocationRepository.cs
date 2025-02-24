using Dapper;
using RealEstate_Dapper_Api.DTOs.PopularLocationDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class StatisticRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPopularLocationDTO>> GetAllPopularLocationAsync()
        {
            string query = "SELECT * FROM PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDTO>(query);
                return values.ToList();
            }
        }
    }
}
