using RealEstate_Dapper_Api.DTOs.ContactDTOs;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
	public interface IContactRepository
	{
		Task<List<ResultContactDTO>> GetAllContactAsync();
		Task CreateContact(CreateContactDTO ContactDTO);
		Task DeleteContact(int id);
		Task<List<Last4ContactResultDTO>> GetLast4Contact();
		Task<GetByIDContactDTO> GetContact(int id);
	}
}
