using Blog_dotNetApi.Cors.Dtos;
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
        Article GetArticleTrimToUpper(ArticleDto articleCreate);

        bool UpdateArticle( int categoryId, Article article);
        bool DeleteArticle(Article article);

        bool ArticleExists(int id);

        bool Save();


    }
}
