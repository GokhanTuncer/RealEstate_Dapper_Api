using RealEstate_Dapper_Api.DTOs.ToDoListDTOs;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
	public interface ITodoListRepository
	{
		Task<List<ResultToDoListDTO>> GetAllToDoList();
		Task CreateToDoList(CreateToDoListDTO ToDoListDTO);
		Task DeleteToDoList(int id);
		Task UpdateToDoList(UpdateToDoListDTO ToDoListDTO);
		Task<GetByIDToDoListDTO> GetToDoList(int id);
	}
}
