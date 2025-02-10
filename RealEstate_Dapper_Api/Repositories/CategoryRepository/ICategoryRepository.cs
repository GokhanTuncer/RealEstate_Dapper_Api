using RealEstate_Dapper_Api.DTOs.CategoryDTOs;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
       Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
    }
}
