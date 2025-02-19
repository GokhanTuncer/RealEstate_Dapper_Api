using RealEstate_Dapper_Api.DTOs.TestimonialDTOs;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDTO>> GetAllTestimonialAsync();

    }
}
