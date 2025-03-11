using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.DTOs.MessageDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInBoxMessageDTO>> GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "SELECT Top(3) * FROM Message WHERE Receiver = @receiverId Order By MessageID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}
