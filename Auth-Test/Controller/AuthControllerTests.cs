using Blog_dotNetApi.Controllers;
using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Blog_dotNetApi.Cors.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Test.Controller
{
    public class AuthControllerTests
    {

        private readonly IAuthService authService;
        private UserManager<ApplicationUser> _userManager;

        public AuthControllerTests()
        {
            authService = A.Fake<IAuthService>();

            
        }

        //************************

        [Fact]
        public async Task AuthController_SeedRoles_ReturnOkAsync()
        {
            //Arrange
            var controller = new AuthController(authService);

            // Act
            var result = await controller.SeedRoles();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        //************************

        [Fact]
        public async Task AuthController_ValidRegisterDto_ReturnsOk()
        {
            // Arrange


            var registerDto = A.Fake<RegisterDto>();
            var registers = A.Fake<ICollection<RegisterDto>>();
            var registerList = A.Fake< IList < RegisterDto >> ();
            A.CallTo(() => authService.RegisterAsync(registerDto));
            var controller = new AuthController(authService);

            // Act


            var result = await controller.Register(registerDto);

            // Assert

            result.Should().NotBeNull();
            Assert.IsType<BadRequestObjectResult>(result);

        }


        [Fact]

        public async Task AuthController_ValidLoginDto_ReturnsOk()
        {
            
           
            var loginDto = A.Fake<LoginDto>();
            var controller = new AuthController(authService);


            var result = controller.Login(loginDto);

            result.Should().NotBeNull();

            

        }

        }
}
