using RealEstate_Dapper_Api.DTOs.CategoryDTOs;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
       Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
       void CreateCategory(CreateCategoryDTO categoryDTO);
       void DeleteCategory(int id);
       void UpdateCategory(UpdateCategoryDTO categoryDTO);
        Task<GetByIDCategoryDTO> GetCategory(int id);
    }
}
