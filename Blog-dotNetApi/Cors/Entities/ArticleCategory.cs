namespace Blog_dotNetApi.Cors.Entities
{
    public class ArticleCategory
    {
        public int ID { get; set; }
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        public Article Article { get; set; }

        public Category Category { get; set; }  

    }
}
