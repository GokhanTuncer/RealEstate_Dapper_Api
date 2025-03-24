using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDTOs;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
	public interface IWhoWeAreDetailRepository
	{
		Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeareDetail();
        Task CreateWhoWeareDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO);
        Task DeleteWhoWeareDetail(int id);
        Task UpdateWhoWeareDetail(UpdateWhoWeareDetailDTO updateWhoWeareDetailDTO);
		Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id);
	}
}
