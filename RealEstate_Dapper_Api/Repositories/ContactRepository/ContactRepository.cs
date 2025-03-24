using Dapper;
using RealEstate_Dapper_Api.DTOs.ContactDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
	public class ContactRepository : IContactRepository
	{
		private readonly Context _context;

		public ContactRepository(Context context)
		{
			_context = context;
		}
		public Task CreateContact(CreateContactDTO ContactDTO)
		{
			throw new NotImplementedException();
		}

		public Task DeleteContact(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<ResultContactDTO>> GetAllContact()
		{
			throw new NotImplementedException();
		}

		public Task<GetByIDContactDTO> GetContact(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Last4ContactResultDTO>> GetLast4Contact()
		{
			string query = "Select Top(4) * From Contact order by ContactID Desc";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<Last4ContactResultDTO>(query);
				return values.ToList();
			}
		}
	}
}
