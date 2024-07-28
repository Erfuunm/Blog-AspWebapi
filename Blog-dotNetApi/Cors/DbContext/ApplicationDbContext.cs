using Blog_dotNetApi.Cors.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog_dotNetApi.Cors.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Article> articles { get; set; }

        //public DbSet<Publisher> publishers { get; set; }

        //public DbSet<Category> categories { get; set; }

        //public DbSet<ArticleCategory> ArticleCategories { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<ArticleCategory>()
        //        .HasKey(pc => new { pc.ArticleId, pc.CategoryId });

        //    builder.Entity<ArticleCategory>()
        //        .HasOne(p => p.Article)
        //        .WithMany(pc => pc.articleCategories)
        //        .HasForeignKey(pc => pc.ArticleId);

        //    builder.Entity<ArticleCategory>()
        //       .HasOne(p => p.Category)
        //       .WithMany(pc => pc.articleCategories)
        //       .HasForeignKey(pc => pc.CategoryId);

        //    builder.Entity<Article>()
        //        .HasOne(p => p.Publisher)
        //        .WithMany(p => p.articles)
        //        .HasForeignKey(p => p.PublisherId);


        //    //builder.Entity<IdentityUserLogin<string>>().HasNoKey();
        //    //builder.Entity<IdentityUserRole<string>>().HasNoKey();
        //    //builder.Entity<IdentityUserToken<string>>().HasNoKey();
            


        //}

    }
}
