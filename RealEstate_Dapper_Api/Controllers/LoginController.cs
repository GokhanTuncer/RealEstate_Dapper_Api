using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.LoginDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDTO loginDTO)
        {
            string query = "SELECT * FROM AppUser Where Username = @username and Password=@password";
            string query2 = "SELECT UserID FROM AppUser Where Username = @username and Password=@password";
            var paramaters = new DynamicParameters();
            paramaters.Add("@username", loginDTO.Username);
            paramaters.Add("@password", loginDTO.Password);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDTO>(query, paramaters);
                var values2 = await connection.QueryFirstOrDefaultAsync<GetAppUserIDDTO>(query2, paramaters);
                if (values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.Username = values.Username;
                    model.ID = values2.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
