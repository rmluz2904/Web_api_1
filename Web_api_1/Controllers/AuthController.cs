using Microsoft.AspNetCore.Mvc;
using Web_api_1.Domain.Model;
using Web_api_1.Application.ViewModel;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Web_api_1.Application.Services;

namespace Web_api_1.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {

        [HttpPost]
        public IActionResult Auth (string username, string password)
        {
            if (username =="Ricardo" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Domain.Model.EmployeeAggregate.Employee());
                return Ok(token);
            }
            return BadRequest("Username or password invalid");
        }
    }
}
