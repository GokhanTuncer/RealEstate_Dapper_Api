using RealEstate_Dapper_Api.DTOs.ServiceDTOs;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDTO>> GetAllServiceAsync();
        void CreateService(CreateServiceDTO createserviceDTO);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDTO updateserviceDTO);
        Task<GetByIDServiceDTO> GetService(int id);
    }
}
