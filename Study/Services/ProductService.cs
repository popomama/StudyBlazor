using Microsoft.EntityFrameworkCore;
using Study.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Services
{
    public class ProductService
    {

        readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int Id)
        {
            //Product cat = new Product();
            return _db.Products.Include(u => u.Category).FirstOrDefault(u => u.Id == Id);
        }

        public List<Product> GetProducts()
        {
            //Product cat = new Product();
            return _db.Products.Include(u => u.Category).ToList();
        }


        public List<Category> GetcategoryList()
        {
            //Product cat = new Product();
            return _db.Categories.ToList();
        }

        public bool CreateProduct(Product Product)
        {
            _db.Products.Add(Product);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product Product)
        {
            var ExistingProduct = _db.Products.FirstOrDefault(u => u.Id == Product.Id);
            if (ExistingProduct != null)
            {
                if (Product.Image == null)
                    Product.Image = ExistingProduct.Image;
                _db.Products.Update(Product);
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteProduct(Product Product)
        {
            var ExistingProduct = _db.Products.FirstOrDefault(u => u.Id == Product.Id);
            if (ExistingProduct != null)
            {
                _db.Products.Remove(ExistingProduct);
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }

    }
}
