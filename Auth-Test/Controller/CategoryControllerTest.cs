using AutoMapper;
using Blog_dotNetApi.Controllers;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Blog_dotNetApi.Cors.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Test.Controller
{
    public class CategoryControllerTest
    {
        private readonly ICategory _category;

        private readonly IMapper _mapper;

 
        public CategoryControllerTest()
        {

            _category = A.Fake<ICategory>();
            _mapper = A.Fake<IMapper>();
      

        }


        [Fact]
        public void CategoryController_GetCategories_ReturnOK()
        {
            //Arrange

            var categories = A.Fake<ICollection<CategoryDto>>();

            var CategoryList = A.Fake<List<CategoryDto>>();
            A.CallTo(() => _mapper.Map<List<CategoryDto>>(categories)).Returns(CategoryList);

            var controller = new CategoryController(_category, _mapper);


            //Act

            var result = controller.GetCategories();

            //Assert 

            result.Should().NotBeNull();

            result.Should().BeOfType(typeof(OkObjectResult));



        }

        [Fact]

        public void CategoryController_CreateCategory_ReturnOK()
        {
            //Arrange

            
            var CategoryMap = A.Fake<Category>();
            var category = A.Fake<Category>();
            var categoryCreate = A.Fake<CategoryDto>();
            var Categories = A.Fake<ICollection<CategoryDto>>();
            var CategoryList = A.Fake<IList<CategoryDto>>();
            A.CallTo(() => _category.GetCategoryTrimToUpper(categoryCreate)).Returns(category);
            A.CallTo(() => _mapper.Map<Category>(categoryCreate)).Returns(category);
            A.CallTo(() => _category.CreateCategory(CategoryMap)).Returns(true);
            var controller = new CategoryController(_category, _mapper);

            //Act
            var result = controller.CreateCategory(categoryCreate);

            //Assert
            result.Should().NotBeNull();


        }

        [Fact]
        public void CategoryController_DeleteCategory_ReturnOK()
        {
            //Arrange

            int CategoryId = 2;
            var CategoryMap = A.Fake<Category>();
            var Category = A.Fake<Category>();
            var CategoryCreate = A.Fake<CategoryDto>();
            A.CallTo(() => _category.GetCategory(CategoryId)).Returns(Category);
            var controller = new CategoryController(_category,_mapper);
            //Act

            var result = controller.DeleteCategory(CategoryId);


            //result

            result.Should().NotBeNull();

        }


        [Fact]

        public void CategoryController_UpdateCategory_ReturnOK()
        {
            //Arrange
            
            int CategoryId = 4;

            var CategoryMap = A.Fake<Category>();
            var Category = A.Fake<Category>();
            var CategoryCreate = A.Fake<CategoryDto>();


            A.CallTo(() => _mapper.Map<Category>(CategoryCreate)).Returns(Category);
            A.CallTo(() => _category.UpdateCategory( CategoryMap)).Returns(true);
            var controller = new CategoryController(_category, _mapper);

            //Act 

            var result = controller.UpdateCategory(CategoryId , CategoryCreate);

            //result

            result.Should().NotBeNull();

        }









    }
}
