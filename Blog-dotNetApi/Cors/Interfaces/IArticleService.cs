using Blog_dotNetApi.Cors.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog_dotNetApi.Cors.Interfaces
{
    public interface IArticleService
    {
        ICollection<Article> GetArticles();

        Article GetArticle(int id);

        Article GetArticle(string Title);

        bool CreateArticle(int categoryId , Article article);

        bool Save();

        bool ArticleExists(int id);


    }
}
