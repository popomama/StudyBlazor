using Study.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Services
{
    public class CategoryService 
    {

        readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int Id)
        {
            //Category cat = new Category();
            return _db.Categories.FirstOrDefault(u => u.Id == Id);
        }

        public List<Category> GetCategories()
        {
            //Category cat = new Category();
            return _db.Categories.ToList();
        }

        public bool CreateCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateCategory(Category category)
        {
            var ExistingCategory = _db.Categories.FirstOrDefault(u => u.Id == category.Id);
            if (ExistingCategory != null)
            {
                ExistingCategory.Name = category.Name;
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteCategory(Category category)
        {
            var ExistingCategory = _db.Categories.FirstOrDefault(u => u.Id == category.Id);
            if (ExistingCategory != null)
            {
                _db.Categories.Remove(ExistingCategory);
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }

    }
}
