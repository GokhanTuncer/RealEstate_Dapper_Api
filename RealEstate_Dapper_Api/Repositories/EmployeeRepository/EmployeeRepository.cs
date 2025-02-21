using Dapper;
using RealEstate_Dapper_Api.DTOs.EmployeeDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageURL,Status) values (@name,@title,@mail,@phoneNumber,@imageURL,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDTO.Name);
            parameters.Add("@title", createEmployeeDTO.Title);
            parameters.Add("@mail", createEmployeeDTO.Mail);
            parameters.Add("@phoneNumber", createEmployeeDTO.PhoneNumber);
            parameters.Add("@imageUrl", createEmployeeDTO.ImageURL);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDTO> GetEmployee(int id)
        {
            string query = "Select * From Employee Where EmployeeID=@EmployeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDTO>(query, parameters);
                return values;
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            string query = "Update Employee Set Name=@name,Title=@title,Mail=@mail,PhoneNumber=@phoneNumber,ImageURL=@imageURL,Status=@status where EmployeeID=@employeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDTO.Name);
            parameters.Add("@title", updateEmployeeDTO.Title);
            parameters.Add("@mail", updateEmployeeDTO.Mail);
            parameters.Add("@phoneNumber", updateEmployeeDTO.PhoneNumber);
            parameters.Add("@imageUrl", updateEmployeeDTO.ImageURL);
            parameters.Add("@status", updateEmployeeDTO.Status);
            parameters.Add("@employeeId", updateEmployeeDTO.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
