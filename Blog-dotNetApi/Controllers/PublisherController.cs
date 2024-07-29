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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisher _Publisher;
        private readonly IMapper _mapper;

        public PublisherController(IPublisher publisher,
            IMapper mapper)
        {
            _mapper = mapper;
            _Publisher = publisher; 
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Publisher>))]
        public IActionResult GetPublishers()
        {
            var publishers = _mapper.Map<List<PublisherDto>>(_Publisher.GetPublishers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(publishers);
        }


        [HttpGet("{PublisherId}")]
        [ProducesResponseType(200, Type = typeof(Publisher))]
        [ProducesResponseType(400)]
        public IActionResult GetPublisher(int publisherId)
        {
            if (!_Publisher.PublisherExists(publisherId))
                return NotFound();

            var publisher = _mapper.Map<PublisherDto>(_Publisher.GetPublisher(publisherId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(publisher);
        }

    




    }
}
