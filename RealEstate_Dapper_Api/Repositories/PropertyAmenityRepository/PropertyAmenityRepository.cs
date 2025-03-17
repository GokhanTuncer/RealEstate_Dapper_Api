using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.PropertyAmenityDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPropertyAmenityByStatusTrueDTO>> ResultPropertyAmenityByStatusTrue(int id)
        {
            string query = "SELECT PropertyAmenityID,Title FROM PropertyAmenity Inner Join Amenity On Amenity.AmenityID=PropertyAmenity.AmenityID Where PropertyID=@PropertyID And Status=1";  
            var parameters = new DynamicParameters();
            parameters.Add("@PropertyID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDTO>(query,parameters);
                return values.ToList();
            }
        }
    }
}
