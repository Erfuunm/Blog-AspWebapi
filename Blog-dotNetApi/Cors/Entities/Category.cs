namespace Blog_dotNetApi.Cors.Entities
{
    public class Category
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public ICollection<ArticleCategory> articleCategories { get; set; } 
    }
}
