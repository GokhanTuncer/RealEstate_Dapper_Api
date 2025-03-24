using RealEstate_Dapper_Api.DTOs.PopularLocationDTOs;


namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllPopularLocation();
        Task CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO);
        Task DeletePopularLocation(int id);
        Task UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO);
        Task<GetByIDPopularLocationDTO> GetPopularLocation(int id);
    }
}
