using AutoMapper;
using Blog_dotNetApi.Cors.Contexts;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Blog_dotNetApi.Cors.OtherObjects;
using Blog_dotNetApi.Cors.Services;
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

        //Init Interfaces and CTOR

        private readonly IArticleService _ArticleService;
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly CategoryService _Category;


        public ArticleController(IArticleService ArticleService ,IPublisher publisher 
            , IMapper mapper)
        {
            _ArticleService = ArticleService;
            _mapper = mapper;   
            _publisher = publisher;
        }

        // Get / Post / Put / Delete Methodes

        [HttpGet]
        
        public IActionResult GetArticls()
        {

            var articles = _mapper.Map<List<ArticleDto>>(_ArticleService.GetArticles());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(articles);

        }


        //**********

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


        //**********


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateArticle( [FromBody] ArticleDto ArticleCreate)
        {
            if (ArticleCreate == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



           

            var articles = _ArticleService.GetArticleTrimToUpper(ArticleCreate);
            



            var articleMap = _mapper.Map<Article>(ArticleCreate);


            //var CatId = _Category.FindCategoryId("Sport");

            articleMap.Publisher = setPublisherID();



            if (!_ArticleService.CreateArticle( (2), articleMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            

            
           

            return Ok("Successfully created");
        }


        //**********


        [HttpPut("{articleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateArticle(int articleId, [FromBody] ArticleDto updatedArticle)
        {
            

            if (updatedArticle == null)
                return BadRequest(ModelState);

         

            if (!_ArticleService.ArticleExists(articleId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            

            var articleMap = _mapper.Map<Article>(updatedArticle);

            


            if (!_ArticleService.UpdateArticle( (1), articleMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated");
        }

        //**********

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



        private Publisher setPublisherID()
        {
            int PublisherId = 1;
            return _publisher.GetPublisher(PublisherId);

        }


    }

}
