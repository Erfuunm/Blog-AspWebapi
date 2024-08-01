using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;

namespace Blog_dotNetApi.Cors.Interfaces
{
    public interface ICategory
    {

        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Article> GetArticleByCategory(int categoryId);
        bool CategoryExists(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        Category GetCategoryTrimToUpper(CategoryDto articleCreate);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
