using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Interfaces;
using Front_Proyecto_2.Models;
using Newtonsoft.Json;
using System.Text;

namespace Front_Proyecto_2.Services
{
    public class ClientService: IClientService
    {
        private static string _urlbase;
        HttpClient _httpClient = new HttpClient();

        public ClientService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSettings:baseUrl").Value;

            this._httpClient.BaseAddress = new Uri(_urlbase);
        }

        public async Task<ServiceResponse<Client>> AddClient(Client client)
        {
            var json = JsonConvert.SerializeObject(client);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this._httpClient.PostAsync("api/Client", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Client>>(json_response);
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteClient(int id)
        {
            var response = await _httpClient.DeleteAsync("api/Client/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<List<Client>>> GetAllClients()
        {
            var response = await _httpClient.GetAsync("api/Client/allClients");
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Client>>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<Client>> GetClient(int id)
        {
            var response = await _httpClient.GetAsync("api/Client/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Client>>(json_response);

            return result;
        }

        public Task<ServiceResponse<Client>> UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
