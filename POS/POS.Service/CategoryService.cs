using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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

        public List<Category> GetCategories() => _context.CategoryEntities.ToList();

        public Category GetCategoryById(int id) => _context.CategoryEntities.Find(id);

        public Boolean DeleteCategory(Category data)
        {
            _context.CategoryEntities.Remove(data);
            return true;
        }

        public Boolean SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        public Boolean Create(Category data)
        {
            _context.CategoryEntities.Add(data);
            return true;
        }

        public Boolean Update(Category data)
        {
            _context.CategoryEntities.Update(data);
            return true;
        }




    }
}
