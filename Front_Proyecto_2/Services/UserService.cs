using Front_Proyecto_2.Interfaces;
using Front_Proyecto_2.Models;
using System.Text;
using Newtonsoft.Json;
using Front_Proyecto_2.Helpers;

namespace Front_Proyecto_2.Services
{
    public class UserService : IUserService
    {
        private static string _urlbase;
        HttpClient _httpClient = new HttpClient();

        public UserService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSettings:baseUrl").Value;

            this._httpClient.BaseAddress = new Uri(_urlbase);
        }

        public async Task<ServiceResponse<User>> AddUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this._httpClient.PostAsync("api/User", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<User>>(json_response);
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync("api/Client/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("api/User/allUsers/");
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<User>>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<User>> GetUser(int id)
        {
            var response = await _httpClient.GetAsync("api/Client/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<User>>(json_response);

            return result;
        }   

        public async Task<ServiceResponse<User>> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
