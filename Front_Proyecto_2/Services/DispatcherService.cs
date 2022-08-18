using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Interfaces;
using Front_Proyecto_2.Models;
using Newtonsoft.Json;
using System.Text;

namespace Front_Proyecto_2.Services
{
    public class DispatcherService: IDispatcherService
    {
        private static string _urlbase;
        HttpClient _httpClient = new HttpClient();

        public DispatcherService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSettings:baseUrl").Value;

            this._httpClient.BaseAddress = new Uri(_urlbase);
        }

        public async Task<ServiceResponse<Dispatcher>> AddDispatcher(Dispatcher dispatcher)
        {
            var json = JsonConvert.SerializeObject(dispatcher);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this._httpClient.PostAsync("api/Dispatcher", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Dispatcher>>(json_response);
            return result;
        }

        public Task<ServiceResponse<bool>> DeleteDispatcher(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Dispatcher>>> GetAllDispatchers()
        {
            var response = await _httpClient.GetAsync("api/Dispatcher/allDispatchers/");
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Dispatcher>>>(json_response);

            return result;
        }

        public Task<ServiceResponse<Dispatcher>> GetDispatcher(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Dispatcher>> UpdateDispatcher(Dispatcher dispatcher)
        {
            throw new NotImplementedException();
        }
    }
}
