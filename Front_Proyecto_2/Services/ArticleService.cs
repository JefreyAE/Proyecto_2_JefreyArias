using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Interfaces;
using Front_Proyecto_2.Models;
using Newtonsoft.Json;
using System.Text;

namespace Front_Proyecto_2.Services
{
    public class ArticleService: IArticleService
    {
        private static string _urlbase;
        HttpClient _httpClient = new HttpClient();

        public ArticleService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSettings:baseUrl").Value;

            this._httpClient.BaseAddress = new Uri(_urlbase);
        }

        public async Task<ServiceResponse<Article>> AddArticle(Article article)
        {
            var json = JsonConvert.SerializeObject(article);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this._httpClient.PostAsync("api/Article", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Article>>(json_response);
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteArticle(int id)
        {
            var response = await _httpClient.DeleteAsync("api/Article/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<List<Article>>> GetAllArticles()
        {
            var response = await _httpClient.GetAsync("api/Article/allArticles/");
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Article>>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<Article>> GetArticle(int id)
        {
            var response = await _httpClient.GetAsync("api/Article/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Article>>(json_response);

            return result;
        }
        
        public async Task<ServiceResponse<List<Article>>> GetArticlesByClientCode(long clientCode)
        {
        var response = await _httpClient.GetAsync("api/Article/clientCode/" + clientCode);
        var json_response = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<ServiceResponse<List<Article>>>(json_response);

        return result;
        }

        public async Task<ServiceResponse<bool>> WithdrawArticlesByClientCode(long clientCode)
        {
            var response = await _httpClient.GetAsync("api/Article/withdraw/" + clientCode);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<Article>> UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Article>>> GetArticlesByRecallDate(string date1, string date2)
        {
            var response = await _httpClient.GetAsync("api/Article/recallsDates/" + date1 + "/" + date2);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Article>>>(json_response);
            return result;
        }
    }
}
