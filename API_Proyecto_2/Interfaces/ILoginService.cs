
using API_Proyecto_2.Helpers;
using API_Proyecto_2.Models;


namespace API_Proyecto_2.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResponse<User>> LoginUser(string password, string email);
    }
}
