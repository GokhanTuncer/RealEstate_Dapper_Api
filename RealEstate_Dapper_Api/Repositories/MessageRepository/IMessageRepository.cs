using RealEstate_Dapper_Api.DTOs.MessageDTOs;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDTO>> GetInBoxLast3MessageListByReceiver(int id);
    }
}
