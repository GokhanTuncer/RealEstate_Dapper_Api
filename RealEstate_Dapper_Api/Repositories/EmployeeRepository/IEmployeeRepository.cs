using RealEstate_Dapper_Api.DTOs.EmployeeDTOs;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDTO>> GetAllEmployee();
        Task CreateEmployee(CreateEmployeeDTO employeeDTO);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateEmployeeDTO employeeDTO);
        Task<GetByIDEmployeeDTO> GetEmployee(int id);
    }
}
