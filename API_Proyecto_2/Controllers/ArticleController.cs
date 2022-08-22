using API_Proyecto_2.Helpers;
using API_Proyecto_2.Interfaces;
using API_Proyecto_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Proyecto_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {

        public IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        // GET: api/<ArticleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Article>>> Get(int id)
        {
            var response = await this._articleService.GetArticle(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Article>>> Post([FromBody] Article article)
        {
            var response = await this._articleService.AddArticle(article);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // GET api/<ArticleController>/allArticles
        [HttpGet("allArticles")]
        public async Task<ActionResult<ServiceResponse<List<Article>>>> GetAllArticles()
        {
            var response = await this._articleService.GetAllArticles();
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await this._articleService.DeleteArticle(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }
    }
}
