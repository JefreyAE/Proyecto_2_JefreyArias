using API_Proyecto_2.DataContext;
using API_Proyecto_2.Helpers;
using API_Proyecto_2.Interfaces;
using API_Proyecto_2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Proyecto_2.Services
{
    public class ArticleService : IArticleService
    {

        public readonly AppDbContext appDbContext;

        public ArticleService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse<Article>> AddArticle(Article article)
        {
            var response = new ServiceResponse<Article>();
            long lastCode = 0;
            try
            {
                lastCode = Convert.ToInt64(this.appDbContext.Articles.Max(d => d.TrackingId)) + 1;
            }
            catch (Exception ex)
            {
                lastCode = 100000000000000000;
            }
            article.TrackingId = Convert.ToString(lastCode);
            try
            {
                await this.appDbContext.Articles.AddAsync(article);
                await this.appDbContext.SaveChangesAsync();

                int lastId = this.appDbContext.Articles.Max(d => d.Id);
                var saved = await this.appDbContext.Articles.FirstOrDefaultAsync(d => d.Id == lastId);
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

        public async Task<ServiceResponse<bool>> DeleteArticle(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var article = await this.appDbContext.Articles.FirstOrDefaultAsync(a => a.Id == id);

                if (article == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Articles.Remove(article);
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

        public async Task<ServiceResponse<List<Article>>> GetAllArticles()
        {
            var response = new ServiceResponse<List<Article>>();

            try
            {
                var article = await this.appDbContext.Articles.
                    Include(a => a.Client).
                    OrderBy(a => a.ClientId)
                    .ToListAsync();
                response.Data = article;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Article>>> GetCustodyArticles()
        {
            var response = new ServiceResponse<List<Article>>();

            try
            {
                var article = await this.appDbContext.Articles.
                    Where(a => a.State == "Custodia").
                    Include(a => a.Client).
                    OrderBy(a => a.ClientId)
                    .ToListAsync();
                response.Data = article;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Article>>> GetWithdrawArticles()
        {
            var response = new ServiceResponse<List<Article>>();

            try
            {
                var article = await this.appDbContext.Articles.
                    Where(a => a.State == "Retirado").
                    Include(a => a.Client).
                    OrderBy(a => a.ClientId)
                    .ToListAsync();
                response.Data = article;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }



        public async Task<ServiceResponse<List<Article>>> GetArticlesByClientCode(long clientCode)
        {
            var response = new ServiceResponse<List<Article>>();
            try
            {
                var client = await this.appDbContext.Clients.FirstOrDefaultAsync(c => c.Code == clientCode);
                var articles = await this.appDbContext.Articles.
                    Where(a => a.ClientId == client.Id && a.State == "Custodia")
                    .ToListAsync();
                response.Data = articles;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<bool>> WithdrawArticlesByClientCode(long clientCode)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var client = await this.appDbContext.Clients.FirstOrDefaultAsync(c => c.Code == clientCode);
                var articles = await this.appDbContext.Articles.
                    Where(a => a.ClientId == client.Id && a.State == "Custodia")
                    .ToListAsync();

                foreach(var article in articles)
                {
                    article.State = "Retirado";
                    article.RecallDate = DateTime.Now;
                    this.appDbContext.Articles.Update(article);
                    await this.appDbContext.SaveChangesAsync();
                }

                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Article>> GetArticle(int id)
        {
            var response = new ServiceResponse<Article>();

            try
            {
                var articles = await this.appDbContext.Articles.FirstOrDefaultAsync(a => a.Id == id);
                response.Data = articles;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Article>> UpdateArticle(Article article)
        {
            var response = new ServiceResponse<Article>();

            try
            {
                if (article == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Articles.Update(article);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = article;
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

        public async Task<ServiceResponse<List<Article>>> GetArticlesByRecallDate(RecallsDates recallDates)
        {
            var response = new ServiceResponse<List<Article>>();
            try
            {
                var articles = await this.appDbContext.Articles.
                    Where(a => a.RecallDate >= recallDates.RecallDate1 && a.RecallDate <= recallDates.RecallDate2)
                    .ToListAsync();
                response.Data = articles;
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
