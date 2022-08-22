using API_Proyecto_2.DataContext;
using API_Proyecto_2.Helpers;
using API_Proyecto_2.Interfaces;
using API_Proyecto_2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Proyecto_2.Services
{
    public class ClientService:IClientService
    {
        public readonly AppDbContext appDbContext;

        public ClientService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse<Client>> AddClient(Client client)
        {
            var response = new ServiceResponse<Client>();
            int lastCode = 0;
            try
            {
                lastCode = this.appDbContext.Clients.Max(d => d.Code) + 1;
            }
            catch (Exception ex)
            {
                lastCode = 10000;
            }
            client.Code = lastCode;
            try
            {
                await this.appDbContext.Clients.AddAsync(client);
                await this.appDbContext.SaveChangesAsync();

                int lastId = this.appDbContext.Clients.Max(d => d.Id);
                var saved = await this.appDbContext.Clients.FirstOrDefaultAsync(d => d.Id == lastId);
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

        public async Task<ServiceResponse<bool>> DeleteClient(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var client = await this.appDbContext.Clients.FirstOrDefaultAsync(a => a.Id == id);

                if (client == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Clients.Remove(client);
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

        public async Task<ServiceResponse<List<Client>>> GetAllClients()
        {
            var response = new ServiceResponse<List<Client>>();

            try
            {
                var client = await this.appDbContext.Clients.Select(a => a).ToListAsync();
                response.Data = client;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Client>> GetClient(int id)
        {
            var response = new ServiceResponse<Client>();

            try
            {
                var client = await this.appDbContext.Clients.FirstOrDefaultAsync(a => a.Id == id);
                response.Data = client;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Client>> UpdateClient(Client client)
        {
            var response = new ServiceResponse<Client>();

            try
            {
                if (client == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Clients.Update(client);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = client;
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
