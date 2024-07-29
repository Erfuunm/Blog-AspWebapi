using Blog_dotNetApi.Cors.Contexts;
using Blog_dotNetApi.Cors.Entities;
using System.Diagnostics.Metrics;

namespace Blog_dotNetApi
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Totalarticles.Any())
            {
                var articleCategory = new List<ArticleCategory>()
                {
                    new ArticleCategory()
                    {
                        Article = new Article()
                        {
                            Title = "Harry Potter",

                            articleCategories = new List<ArticleCategory>()
                            {
                                new ArticleCategory { Category = new Category() { Title = "science fiction"}}
                            }

                        }
                   
                    },
                    new ArticleCategory()
                    {
                        Article = new Article()
                        {
                            Title = "Ai Generation",
                           
                            articleCategories = new List<ArticleCategory>()
                            {
                                 new ArticleCategory { Category = new Category() { Title = "knowledge"}}
                            }
                      
                        }
                        
                    },
                                    new ArticleCategory()
                    {
                        Article = new Article()
                        {
                            Title = "Big Data",
                      
                            articleCategories = new List<ArticleCategory>()
                            {
                                 new ArticleCategory { Category = new Category() { Title = "knowledge"}}
                            },
                       
                        }
                
                    }
                };
                dataContext.ArticleCategories.AddRange(articleCategory);
                dataContext.SaveChanges();
            }
        }
    }
}
