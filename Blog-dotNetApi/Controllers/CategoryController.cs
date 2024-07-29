using AutoMapper;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_dotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategory _category;

        private readonly IMapper _mapper;


        public CategoryController(ICategory category , IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_category.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_category.CategoryExists(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoryDto>(_category.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }


        [HttpGet("Article/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Article>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId(int categoryId)
        {
            var pokemons = _mapper.Map<List<ArticleDto>>(
                _category.GetArticleByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(pokemons);
        }






    }
}
