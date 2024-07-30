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
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService ArticleService ,IPublisher publisher 
            , IMapper mapper)
        {
            _ArticleService = ArticleService;
            _mapper = mapper;   
            _publisher = publisher;
        }

        [HttpGet]
        
        public IActionResult GetArticls()
        {

            var articles = _mapper.Map<List<ArticleDto>>(_ArticleService.GetArticles());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(articles);

        }


        [HttpGet("{articleId}")]
        [ProducesResponseType(200, Type = typeof(Article))]
        [ProducesResponseType(400)]
        public IActionResult GetArticle(int articleId)
        {
            if (!_ArticleService.ArticleExists(articleId))
                return NotFound();

            var article = _mapper.Map<ArticleDto>(_ArticleService.GetArticle(articleId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(article);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateArticle([FromQuery] int PublisherId, [FromQuery] int catId, [FromBody] ArticleDto ArticleCreate)
        {
            if (ArticleCreate == null)
                return BadRequest(ModelState);

            var articles = _ArticleService.GetArticleTrimToUpper(ArticleCreate);
                
               

            


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
             



            var articleMap = _mapper.Map<Article>(ArticleCreate);

            articleMap.Publisher = _publisher.GetPublisher(PublisherId);

            if (!_ArticleService.CreateArticle( catId, articleMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{articleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateArticle(int articleId,
          [FromQuery] int catId,
          [FromBody] ArticleDto updatedArticle)
        {
            

            if (updatedArticle == null)
                return BadRequest(ModelState);

            //if (articleId != updatedArticle.ID)
            //    return BadRequest(ModelState);

            if (!_ArticleService.ArticleExists(articleId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();


            

            var articleMap = _mapper.Map<Article>(updatedArticle);

            if (!_ArticleService.UpdateArticle( catId, articleMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated");
        }

        [HttpDelete("{articleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteArticle(int articleId)
        {
            if (!_ArticleService.ArticleExists(articleId))
            {
                return NotFound();
            }

            

            var ArticleToDelete = _ArticleService.GetArticle(articleId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

       

            if (!_ArticleService.DeleteArticle(ArticleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong in deleting");
            }

            return Ok("Delete was successfull");
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
