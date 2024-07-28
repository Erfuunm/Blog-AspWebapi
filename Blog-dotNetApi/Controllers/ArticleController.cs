using Blog_dotNetApi.Cors.DbContext;
using Blog_dotNetApi.Cors.Entities;
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
        private readonly ApplicationDbContext _dbContext;

        public ArticleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles = StaticUserRoles.ADMIN)]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticls()
        {
            if(_dbContext.articles == null)
            {
                return NotFound();
            }
            return await _dbContext.articles.ToListAsync();


        }

        [HttpGet("{id}")]
       
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            if(_dbContext.articles == null) {
                return NotFound();
            }
            var article = await _dbContext.articles.FindAsync(id);

            if(article == null) {  return NotFound(); }

            return article;
        }

        [HttpPost]
        [Route("create-article")]
       
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            _dbContext.articles.Add(article);
            await _dbContext.SaveChangesAsync();    
            return CreatedAtAction(nameof(GetArticle) , new {id = article.ID} , article );
        }

        [HttpPut]
        public async Task<IActionResult> PutArticle(int id, Article article)
        {
            if(id != article.ID)
            {
                return BadRequest();
            }
            _dbContext.Entry(article).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException) {

                if (!ArticleAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            
            }
            return Ok();

        }
        private bool ArticleAvailable(int id)
        {
            return (_dbContext.articles?.Any(a => a.ID == id)).GetValueOrDefault();
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteArticle(int id)
        {
            if(_dbContext.articles == null)
            {
                return NotFound();
                
            }
            var article = await _dbContext.articles.FindAsync(id);
            if(article == null)
            {
                return NotFound();

            }


            _dbContext.articles.Remove(article);

            await _dbContext.SaveChangesAsync();

            return Ok();


        }

    }
    
}
