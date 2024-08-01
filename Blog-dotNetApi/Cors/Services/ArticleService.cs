using Blog_dotNetApi.Cors.Contexts;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_dotNetApi.Cors.Services
{
    public class ArticleService : IArticleService
    {

        //Init Data and CTOR

        private readonly DataContext _dataContext;

        public ArticleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        //Implemetion of the Functions -> 


        public ICollection<Article> GetArticles()
        {
            return _dataContext.Totalarticles.ToList();

            
        }


        //*******


        public Article GetArticle(int id)
        {
            return _dataContext.Totalarticles.Where(p => p.ID == id).FirstOrDefault();
        }

        //*******

        public Article GetArticle(string Title)
        {
            return _dataContext.Totalarticles.Where(p => p.Title == Title).FirstOrDefault();
        }

        //*******

        public bool ArticleExists(int id)
        {
            return _dataContext.Totalarticles.Any(p => p.ID == id);
        }

        //*******

        public bool CreateArticle(int categoryId, Article article)
        {
            var category = _dataContext.categories.Where(a => a.ID == categoryId).FirstOrDefault();

            var articleCategory = new ArticleCategory()
            {
                Category = category,
                Article = article,
            };

            _dataContext.Add(articleCategory);

            _dataContext.Add(article);

            return Save();
            
        }

        //*******

        public Article GetArticleTrimToUpper(ArticleDto ArticleCreate)
        {
            return GetArticles().Where(c => c.Title.Trim().ToUpper() == ArticleCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

         //*******

     
        public bool UpdateArticle(int categoryId, Article article)
        {
            _dataContext.Update(article);
            return Save();
        }

        //*******

        public bool DeleteArticle(Article article)
        {
            _dataContext.Remove(article);
            return Save();
        }

        //*******

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;

        }
    } 
}
