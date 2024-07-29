﻿using Blog_dotNetApi.Cors.Contexts;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_dotNetApi.Cors.Services
{
    public class CategoryService : ICategory
    {

        private readonly DataContext _dataContext;

        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CategoryExists(int id)
        {
            return _dataContext.categories.Any(c => c.ID == id);
        }

        public bool CreateCategory(Category category)
        {
            _dataContext.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public ICollection<Article> GetArticleByCategory(int categoryId)
        {
           return _dataContext.ArticleCategories.Where(e => e.CategoryId == categoryId).Select(e => e.Article).ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _dataContext.categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _dataContext.categories.Where(e => e.ID == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
