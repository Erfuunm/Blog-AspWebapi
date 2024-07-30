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
using System.Text;
using System.Threading.Tasks;

namespace Auth_Test.Controller
{
    public class PublisherControllerTest
    {
        private readonly IPublisher _publisher;

        private readonly IMapper _mapper;

        public PublisherControllerTest()
        {
            _publisher = A.Fake<IPublisher>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void PublisherController_Publishers_ReturnOK()
        {
            //Arrange

            var Publishers = A.Fake<ICollection<PublisherDto>>();

            var PublisherList = A.Fake<List<PublisherDto>>();
            A.CallTo(() => _mapper.Map<List<PublisherDto>>(Publishers)).Returns(PublisherList);

            var controller = new PublisherController(_publisher , _mapper);


            //Act

            var result = controller.GetPublishers();

            //Assert 

            result.Should().NotBeNull();

            result.Should().BeOfType(typeof(OkObjectResult));



        }

        [Fact]

        public void PublisherController_GetPublisher_ReturnOK()
        {
            int publisherId = 2;
            var Publisher = A.Fake<PublisherDto>();
            var pub = A.Fake<PublisherDto>();

            A.CallTo(() => _mapper.Map<PublisherDto>(Publisher)).Returns(pub);

            var controller = new PublisherController(_publisher, _mapper);



            //Act

            var result = controller.GetPublisher(publisherId);

            //Assert 

            result.Should().NotBeNull();
          

        }


    }
}
