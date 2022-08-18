using Front_Proyecto_2.Interfaces;
using Front_Proyecto_2.Models;
using System.Text;
using Newtonsoft.Json;
using Front_Proyecto_2.Helpers;

namespace Front_Proyecto_2.Services
{
    public class LoginService : ILoginService
    {
        private static string _urlbase;
        HttpClient _httpClient = new HttpClient();

        public LoginService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSettings:baseUrl").Value;

            this._httpClient.BaseAddress = new Uri(_urlbase);
        }
        public async Task<ServiceResponse<User>> LoginUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Login", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<User>> (json_response);

            return result;
        }
    }
}
