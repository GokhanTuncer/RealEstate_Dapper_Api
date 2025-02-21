using RealEstate_Dapper_Api.DTOs.EmployeeDTOs;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void CreateEmployee(CreateEmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIDEmployeeDTO> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(UpdateEmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
