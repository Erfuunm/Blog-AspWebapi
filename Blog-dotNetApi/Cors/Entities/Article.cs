  namespace Blog_dotNetApi.Cors.Entities
{
    public class Article
    {

        public int ID { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }

        public int PublisherId { get; set; }

        //public Publisher Publisher { get; set; }

        //public ICollection<ArticleCategory> articleCategories { get; set;}

    }
}
