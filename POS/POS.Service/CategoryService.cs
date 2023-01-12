using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using AppContext = POS.Repository.AppContext;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly AppContext _context;
        public CategoryService(AppContext context)
        {
            _context = context;
        }

        public List<CategoryEntity> GetCategories() => _context.CategoryEntities.ToList();

        public List<CategoryEntity> GetCategoryWithProduct() => _context.CategoryEntities.Include(s => s.Products).ToList();

        public CategoryEntity GetCategoryById(int id) => _context.CategoryEntities.Find(id);

        public CategoryEntity GetCategoryByIdWithProduct(int id) => _context.CategoryEntities.Include(s => s.Products).FirstOrDefault(s => s.Id == id);

        public Boolean DeleteCategory(CategoryEntity data)
        {
            _context.CategoryEntities.Remove(data);
            _context.SaveChanges();
            return true;
        }

        public Boolean Create(CategoryEntity data)
        {
            _context.CategoryEntities.Add(data);
            _context.SaveChanges();
            return true;
        }

        public Boolean Update(CategoryEntity data)
        {
            _context.CategoryEntities.Update(data);
            _context.SaveChanges();
            return true;
        }
    }
}
