namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
	public interface ITodoListRepository
	{
		Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
		void CreateCategory(CreateCategoryDTO categoryDTO);
		void DeleteCategory(int id);
		void UpdateCategory(UpdateCategoryDTO categoryDTO);
		Task<GetByIDCategoryDTO> GetCategory(int id);
	}
}
