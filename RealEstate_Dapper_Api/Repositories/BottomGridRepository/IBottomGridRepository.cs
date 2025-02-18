using RealEstate_Dapper_Api.DTOs.BottomGridDTOs;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
	public interface IBottomGridRepository
	{
		Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync();
		Task CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO);
		Task DeleteBottomGrid(int id);
		Task UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO);
		Task<GetBottomGridDTO> GetBottomGrid(int id);
	}
}
