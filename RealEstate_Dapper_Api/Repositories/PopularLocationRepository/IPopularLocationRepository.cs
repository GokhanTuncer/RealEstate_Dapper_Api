using RealEstate_Dapper_Api.DTOs.PopularLocationDTOs;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllPopularLocationAsync();
    }
}
