using Blog_dotNetApi.Cors.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog_dotNetApi.Cors.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Article> Totalarticles { get; set; }

        public DbSet<Publisher> publishers { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ArticleCategory>()
               .HasKey(pc => new { pc.ArticleId, pc.CategoryId });

            builder.Entity<ArticleCategory>()
               .HasOne(p => p.Article)
               .WithMany(pc => pc.articleCategories)
               .HasForeignKey(p => p.ArticleId);

            builder.Entity<ArticleCategory>()
               .HasOne(p => p.Category)
               .WithMany(pc => pc.articleCategories)
               .HasForeignKey(c => c.CategoryId);




        }


    }
}
