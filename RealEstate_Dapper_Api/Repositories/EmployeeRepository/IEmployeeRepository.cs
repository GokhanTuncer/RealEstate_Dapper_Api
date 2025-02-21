using RealEstate_Dapper_Api.DTOs.EmployeeDTOs;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync();
        void CreateEmployee(CreateEmployeeDTO employeeDTO);
        void DeleteEmployee(int id);
        void UpdateEmployee(UpdateEmployeeDTO employeeDTO);
        Task<GetByIDEmployeeDTO> GetEmployee(int id);
    }
}
