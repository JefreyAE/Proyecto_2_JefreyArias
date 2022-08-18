
using API_Proyecto_2.Interfaces;
using API_Proyecto_2.Models;
using API_Proyecto_2.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Proyecto_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService _loginService;
        public IConfiguration _configuration;

        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        // POST api/login
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<User>>> Login(User user)
        {
            var response = await this._loginService.LoginUser(user.Password, user.Email);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }
    }
}
