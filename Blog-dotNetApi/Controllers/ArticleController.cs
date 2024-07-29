using AutoMapper;
using Blog_dotNetApi.Cors.Contexts;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Blog_dotNetApi.Cors.OtherObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_dotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _ArticleService;

        private readonly IMapper _mapper;

        public ArticleController(IArticleService ArticleService , IMapper mapper)
        {
            _ArticleService = ArticleService;
            _mapper = mapper;   
        }

        [HttpGet]
        
        public IActionResult GetArticls()
        {

            var articles = _mapper.Map<List<ArticleDto>>(_ArticleService.GetArticles());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(articles);

        }


        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Article))]
        [ProducesResponseType(400)]
        public IActionResult GetArticle(int id)
        {
            if(_ArticleService.ArticleExists(id)) return NotFound();

            var article = _ArticleService.GetArticle(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(article);

        }


        //[HttpGet("{id}")]

        //public async Task<ActionResult<Article>> GetArticle(int id)
        //{
        //    if (_dbContext.articles == null)
        //    {
        //        return NotFound();
        //    }
        //    var article = await _dbContext.articles.FindAsync(id);

        //    if (article == null) { return NotFound(); }

        //    return article;
        //}

        //[HttpPost]
        //[Route("create-article")]

        //public async Task<ActionResult<Article>> PostArticle(Article article)
        //{
        //    _dbContext.articles.Add(article);
        //    await _dbContext.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetArticle), new { id = article.ID }, article);
        //}

        //[HttpPut]
        //public async Task<IActionResult> PutArticle(int id, Article article)
        //{
        //    if (id != article.ID)
        //    {
        //        return BadRequest();
        //    }
        //    _dbContext.Entry(article).State = EntityState.Modified;

        //    try


        //    {
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {

        //        if (!ArticleAvailable(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }

        //    }
        //    return Ok();

        //}
        //private bool ArticleAvailable(int id)
        //{
        //    return (_dbContext.articles?.Any(a => a.ID == id)).GetValueOrDefault();
        //}


        //[HttpDelete("{id}")]

        //public async Task<IActionResult> DeleteArticle(int id)
        //{
        //    if (_dbContext.articles == null)
        //    {
        //        return NotFound();

        //    }
        //    var article = await _dbContext.articles.FindAsync(id);
        //    if (article == null)
        //    {
        //        return NotFound();

        //    }


        //    _dbContext.articles.Remove(article);

        //    await _dbContext.SaveChangesAsync();

        //    return Ok();


        //}

    }

}
