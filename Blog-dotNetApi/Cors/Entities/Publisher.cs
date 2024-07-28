namespace Blog_dotNetApi.Cors.Entities
{
    public class Publisher
    {
        public int ID { get; set; }

        public string Name   { get; set; }

        public DateTime PublishDate { get; set; }

        public int ArticleId { get; set; }

        public ICollection<Article> articles { get; set; }

    }
}
