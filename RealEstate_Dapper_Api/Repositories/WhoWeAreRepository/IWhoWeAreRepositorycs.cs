using RealEstate_Dapper_Api.DTOs.CategoryDTOs;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
	public interface IWhoWeAreRepositorycs
	{
		Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
		void CreateCategory(CreateCategoryDTO categoryDTO);
		void DeleteCategory(int id);
		void UpdateCategory(UpdateCategoryDTO categoryDTO);
		Task<GetByIDCategoryDTO> GetCategory(int id);
	}
}
