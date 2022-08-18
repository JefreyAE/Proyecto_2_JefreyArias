using API_Proyecto_2.DataContext;
using API_Proyecto_2.Helpers;
using API_Proyecto_2.Interfaces;
using API_Proyecto_2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Proyecto_2.Services
{
    public class DispatcherService:IDispatcherService
    {

        public readonly AppDbContext appDbContext;

        public DispatcherService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse<Dispatcher>> AddDispatcher(Dispatcher dispatcher)
        {
            var response = new ServiceResponse<Dispatcher>();
            int lastCode = 0;
            try
            {
                lastCode = this.appDbContext.Dispatchers.Max(d => d.Code) + 1;
            }
            catch (Exception ex)
            {
                lastCode = 100;
            }
            dispatcher.Code = lastCode;

            try
            {  
                await this.appDbContext.Dispatchers.AddAsync(dispatcher);
                await this.appDbContext.SaveChangesAsync();

                int lastId = this.appDbContext.Dispatchers.Max(d => d.Id);
                var saved = await this.appDbContext.Dispatchers.FirstOrDefaultAsync(d => d.Id == lastId);
                response.Data = saved;

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteDispatcher(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var dispatcher = await this.appDbContext.Dispatchers.FirstOrDefaultAsync(a => a.Id == id);

                if (dispatcher == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Dispatchers.Remove(dispatcher);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = true;
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

        public async Task<ServiceResponse<Dispatcher>> GetDispatcher(int id)
        {
            var response = new ServiceResponse<Dispatcher>();

            try
            {
                var dispatcher = await this.appDbContext.Dispatchers.FirstOrDefaultAsync(a => a.Id == id);
                response.Data = dispatcher;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Dispatcher>>> GetAllDispatchers()
        {
            var response = new ServiceResponse<List<Dispatcher>>();

            try
            {
                var agenda = await this.appDbContext.Dispatchers.Select(a => a).ToListAsync();
                response.Data = agenda;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Dispatcher>> UpdateDispatcher(Dispatcher dispatcher)
        {
            var response = new ServiceResponse<Dispatcher>();

            try
            {
                if (dispatcher == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Dispatchers.Update(dispatcher);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = dispatcher;
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
