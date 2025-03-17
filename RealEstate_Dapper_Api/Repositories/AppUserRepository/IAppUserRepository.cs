using RealEstate_Dapper_Api.DTOs.AppUserDTOs;


namespace RealEstate_Dapper_Api.Repositories.AppUserRepository
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIDDTO> GetAppUserByProductID(int id);
    }
}
