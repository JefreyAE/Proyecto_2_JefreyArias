using Front_Proyecto_2.Interfaces;

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
    }
}
