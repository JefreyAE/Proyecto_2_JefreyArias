using API_Proyecto_2.Helpers;
using API_Proyecto_2.Models;

namespace API_Proyecto_2.Interfaces
{
    public interface IClientService
    {
        Task<ServiceResponse<Client>> AddClient(Client client);
        Task<ServiceResponse<bool>> DeleteClient(int id);
        Task<ServiceResponse<Client>> GetClient(int id);
        Task<ServiceResponse<List<Client>>> GetAllClients();
        Task<ServiceResponse<Client>> UpdateClient(Client client);
    }
}
