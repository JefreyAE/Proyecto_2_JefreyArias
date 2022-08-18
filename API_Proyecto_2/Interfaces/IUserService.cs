using API_Proyecto_2.Helpers;
using API_Proyecto_2.Models;

namespace API_Proyecto_2.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> AddUser(User user);
        Task<ServiceResponse<bool>> DeleteUser(int id);
        Task<ServiceResponse<User>> GetUser(int id);
        Task<ServiceResponse<List<User>>> GetAllUsers();
        Task<ServiceResponse<User>> UpdateUser(User user);
    }
}
