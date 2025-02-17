using RealEstate_Dapper_Api.DTOs.ServiceDTOs;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDTO>> GetAllServiceAsync();
        Task CreateService(CreateServiceDTO createserviceDTO);
        Task DeleteService(int id);
        Task UpdateService(UpdateServiceDTO updateserviceDTO);
        Task<GetByIDServiceDTO> GetService(int id);
    }
}
