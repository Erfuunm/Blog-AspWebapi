using AutoMapper;
using Blog_dotNetApi.Controllers;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auth_Test.Controller
{
    public class ArticleControllerTests
    {
        private readonly IArticleService _articleService;

        private readonly IMapper _mapper;

        private readonly IPublisher _publisher;

        public ArticleControllerTests()
        {
            _articleService = A.Fake<IArticleService>();
            _mapper = A.Fake<IMapper>();
            _publisher = A.Fake<IPublisher>();

        }

        [Fact]
        public void ArticleController_GetArticles_ReturnOK()
        {
            //Arrange

            var articles = A.Fake<ICollection<ArticleDto>>();

            var articleList = A.Fake<List<ArticleDto>>();
            A.CallTo(() => _mapper.Map<List<ArticleDto>>(articles)).Returns(articleList);

            var controller = new ArticleController(_articleService, _publisher ,_mapper);


            //Act

            var result = controller.GetArticls();

            //Assert 

            result.Should().NotBeNull();

            result.Should().BeOfType(typeof(OkObjectResult));



        }


        [Fact]

        public void ArticleController_CreateArticle_ReturnOK()
        {
            //Arrange
            
            int catId = 5;
            int PublisherId = 4;
            var ArticleMap = A.Fake<Article>();
            var Article = A.Fake<Article>();
            var ArticleCreate = A.Fake<ArticleDto>();
            var Articles = A.Fake<ICollection<ArticleDto>>();
            var ArticleList = A.Fake<IList<ArticleDto>>();
            A.CallTo(() => _articleService.GetArticleTrimToUpper(ArticleCreate)).Returns(Article);
            A.CallTo(() => _mapper.Map<Article>(ArticleCreate)).Returns(Article);
            A.CallTo(() => _articleService.CreateArticle( catId, ArticleMap)).Returns(true);
            var controller = new ArticleController(_articleService, _publisher, _mapper);

            //Act
            var result = controller.CreateArticle( PublisherId , catId, ArticleCreate);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void ArticleController_DeleteArticle_ReturnOK()
        {
            //Arrange

            int articleId = 3;
            var ArticleMap = A.Fake<Article>();
            var Article = A.Fake<Article>();
            var ArticleCreate = A.Fake<ArticleDto>();
            A.CallTo(() => _articleService.GetArticle(articleId)).Returns(Article);
            var controller = new ArticleController(_articleService, _publisher, _mapper);
            //Act

            var result = controller.DeleteArticle(articleId);


            //result

            result.Should().NotBeNull();

        }

        [Fact]

        public void ArticleController_UpdateArticle_ReturnOK()
        {
            //Arrange
            int catId = 5;
            int articleId = 4;

            var ArticleMap = A.Fake<Article>();
            var Article = A.Fake<Article>();
            var ArticleCreate = A.Fake<ArticleDto>();
           
            
            A.CallTo(() => _mapper.Map<Article>(ArticleCreate)).Returns(Article);
            A.CallTo(() => _articleService.UpdateArticle(articleId, ArticleMap)).Returns(true);
            var controller = new ArticleController(_articleService, _publisher, _mapper);

            //Act 

            var result = controller.UpdateArticle(articleId , catId , ArticleCreate);

            //result

            result.Should().NotBeNull();

        }

    }
}
