using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuarzoCRUDTest.Models;
using QuarzoCRUDTest.Repositories;

namespace QuarzoCRUDTest.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository categoryRepository = new CategoryRepository();

        public CategoryService()
        {
        }

        public IEnumerable<Category> GetAllCategorie()
        {
            return categoryRepository.GetAllCategories();
        }
        public void AddCategory(Category category)
        {
            categoryRepository.AddCategory(category);
        }
        public void UpdateCategory(Category category)
        {
            categoryRepository.UpdateCategory(category);
        }
    }
}