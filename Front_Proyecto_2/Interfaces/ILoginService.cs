using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Models;

namespace Front_Proyecto_2.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResponse<User>> LoginUser(User user);
    }
}
