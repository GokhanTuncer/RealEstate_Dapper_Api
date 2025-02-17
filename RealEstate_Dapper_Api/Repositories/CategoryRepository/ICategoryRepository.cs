using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDTOs;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
       Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync();
       void CreateCategory(CreateCategoryDTO categoryDTO);
       void DeleteCategory(int id);
       void UpdateCategory(UpdateCategoryDTO categoryDTO);
        Task<GetByIDCategoryDTO> GetCategory(int id);
    }
}
