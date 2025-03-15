using RealEstate_Dapper_Api.DTOs.ProductDTOs;
using RealEstate_Dapper_Api.DTOs.ProductImageDTOs;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepository
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImageByProductIDDTO>> GetProductImageByProductID(int id);
    }
}
