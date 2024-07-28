namespace Blog_dotNetApi.Cors.Dtos
{
    public class ArticleDto
    {
        public int ID { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }
    }
}
