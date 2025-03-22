using RealEstate_Dapper_Api.DTOs.SubFeatureDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepository
{
    public class SubFeatureRepository  :ISubFeatureRepository
    {
        private readonly Context _context;

        public SubFeatureRepository(Context context)
        {
            _context = context;
        }

        public Task<List<ResultSubFeatureDTO>> GetAllSubFeatureAsync()
        {
            throw new NotImplementedException();
        }
    }
}
