using RealEstate_Dapper_Api.DTOs.ProductDTOs;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository
{
    public interface ILast5ProductsRepository
    {
        Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5ProductAsync(int id);
    }
}
