using Blog_dotNetApi.Cors.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog_dotNetApi.Cors.Interfaces
{
    public interface IArticleService
    {
        ICollection<Article> GetArticles();

        Article GetArticle(int id);

        Article GetArticle(string Title);

       

        bool ArticleExists(int id);


    }
}
