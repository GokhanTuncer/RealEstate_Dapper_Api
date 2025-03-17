using RealEstate_Dapper_Api.DTOs.PropertyAmenityDTOs;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrueDTO>> ResultPropertyAmenityByStatusTrue(int id);
    }
}
