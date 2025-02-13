using RealEstate_Dapper_Api.DTOs.ProductDTOs;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync();
    }
}
