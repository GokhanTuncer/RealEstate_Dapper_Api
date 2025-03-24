using RealEstate_Dapper_Api.DTOs.CategoryDTOs;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
       Task<List<ResultCategoryDTO>> GetAllCategory();
        Task CreateCategory(CreateCategoryDTO categoryDTO);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDTO categoryDTO);
        Task<GetByIDCategoryDTO> GetCategory(int id);
    }
}
