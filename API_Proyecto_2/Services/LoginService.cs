using API_Proyecto_2.DataContext;
using API_Proyecto_2.Helpers;
using API_Proyecto_2.Interfaces;
using API_Proyecto_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Proyecto_2.Services
{
    public class LoginService: ILoginService
    {
        public readonly AppDbContext appDbContext;
        public IConfiguration _configuration;

        public LoginService(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<User>> LoginUser(string password, string email)
        {
            var response = new ServiceResponse<User>();

            try
            {   
                if (password == null || email == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    var user = await this.appDbContext.Users.FirstOrDefaultAsync(u => u.Password == password && u.Email == email);
                    if (user == null)
                    {
                        response.Data = null;
                        response.Success = false;
                        response.Message = "Resource not found";
                    }
                    else
                    {
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Name", user.Name),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("Email", user.Email.ToString())
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn);

                        response.Message = new JwtSecurityTokenHandler().WriteToken(token);
                        user.Password = "";
                        response.Data = user;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
