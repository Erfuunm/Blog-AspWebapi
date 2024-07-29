using Blog_dotNetApi.Cors.Entities;

namespace Blog_dotNetApi.Cors.Interfaces
{
    public interface IPublisher
    {
        ICollection<Publisher> GetPublishers();

        Publisher GetPublisher(int publisherId);

       

        bool PublisherExists(int publisherId);


    }
}
