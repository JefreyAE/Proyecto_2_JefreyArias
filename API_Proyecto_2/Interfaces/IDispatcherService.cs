using API_Proyecto_2.Helpers;
using API_Proyecto_2.Models;

namespace API_Proyecto_2.Interfaces
{
    public interface IDispatcherService
    {
        Task<ServiceResponse<Dispatcher>> AddDispatcher(Dispatcher dispatcher);
        Task<ServiceResponse<bool>> DeleteDispatcher(int id);
        Task<ServiceResponse<Dispatcher>> GetDispatcher(int id);
        Task<ServiceResponse<List<Dispatcher>>> GetAllDispatchers();
        Task<ServiceResponse<Dispatcher>> UpdateDispatcher(Dispatcher dispatcher);

    }
}
