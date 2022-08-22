﻿using Front_Proyecto_2.Helpers;
using Front_Proyecto_2.Models;

namespace Front_Proyecto_2.Interfaces
{
    public interface IArticleService
    {
        Task<ServiceResponse<Article>> AddArticle(Article article);
        Task<ServiceResponse<bool>> DeleteArticle(int id);
        Task<ServiceResponse<List<Article>>> GetAllArticles();
        Task<ServiceResponse<Article>> GetArticle(int id);
        Task<ServiceResponse<Article>> UpdateArticle(Article article);
    }
}
