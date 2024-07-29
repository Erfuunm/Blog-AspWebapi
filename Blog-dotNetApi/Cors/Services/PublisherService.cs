using Blog_dotNetApi.Cors.Contexts;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_dotNetApi.Cors.Services
{
    public class PublisherService : IPublisher
    {

        private readonly DataContext _dataContext;

        public PublisherService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Publisher GetPublisher(int publisherId)
        {
            return _dataContext.publishers.Where(r => r.ID == publisherId).FirstOrDefault();
        }

   

        public ICollection<Publisher> GetPublishers()
        {
            return _dataContext.publishers.ToList();
        }

        public bool PublisherExists(int publisherId)
        {
            return _dataContext.publishers.Any(r => r.ID == publisherId);
        }
    }
}
