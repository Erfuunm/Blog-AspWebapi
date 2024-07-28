using Blog_dotNetApi.Cors.Contexts;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;

namespace Blog_dotNetApi.Cors.Services
{
    public class ArticleService : IArticleService
    {
        private readonly DataContext _dataContext;

        public ArticleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public Article GetArticle(int id)
        {
            return _dataContext.Totalarticles.Where(p => p.ID == id).FirstOrDefault();
        }

        public Article GetArticle(string Title)
        {
            return _dataContext.Totalarticles.Where(p => p.Title == Title).FirstOrDefault();
        }

        public ICollection<Article> GetArticles()
        {
            return _dataContext.Totalarticles.OrderBy(p => p.ID).ToList();  
        }


        public bool ArticleExists(int id)
        {
            return _dataContext.Totalarticles.Any(p => p.ID == id);
        }

    } 
}
