using RealEstate_Dapper_Api.DTOs.ToDoListDTOs;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
	public interface ITodoListRepository
	{
		Task<List<ResultToDoListDTO>> GetAllToDoListAsync();
		void CreateToDoList(CreateToDoListDTO ToDoListDTO);
		void DeleteToDoList(int id);
		void UpdateToDoList(UpdateToDoListDTO ToDoListDTO);
		Task<GetByIDToDoListDTO> GetToDoList(int id);
	}
}
