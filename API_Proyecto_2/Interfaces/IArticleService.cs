using API_Proyecto_2.Helpers;
using API_Proyecto_2.Models;

namespace API_Proyecto_2.Interfaces
{
    public interface IArticleService
    {
        Task<ServiceResponse<Article>> AddArticle(Article article);
        Task<ServiceResponse<bool>> DeleteArticle(int id);
        Task<ServiceResponse<Article>> GetArticle(int id);
        Task<ServiceResponse<List<Article>>> GetAllArticles();
        Task<ServiceResponse<Article>> UpdateArticle(Article article);
        Task<ServiceResponse<List<Article>>> GetArticlesByClientCode(long clientCode);
        Task<ServiceResponse<bool>> WithdrawArticlesByClientCode(long clientCode);
        Task<ServiceResponse<List<Article>>> GetArticlesByRecallDate(RecallsDates recallDates);
        Task<ServiceResponse<List<Article>>> GetCustodyArticles();
        Task<ServiceResponse<List<Article>>> GetWithdrawArticles();
    }
}
