using RealEstate_Dapper_Api.DTOs.SubFeatureDTOs;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepository
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDTO>> GetAllSubFeatureAsync();
    }
}
