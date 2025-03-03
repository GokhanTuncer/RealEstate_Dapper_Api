using RealEstate_Dapper_Api.DTOs.ContactDTOs;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
	public class ContactRepository : IContactRepository
	{
		public Task CreateContact(CreateContactDTO ContactDTO)
		{
			throw new NotImplementedException();
		}

		public Task DeleteContact(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<ResultContactDTO>> GetAllContactAsync()
		{
			throw new NotImplementedException();
		}

		public Task<GetByIDContactDTO> GetContact(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Last4ContactResultDTO>> GetLast4Contact()
		{
			throw new NotImplementedException();
		}
	}
}
