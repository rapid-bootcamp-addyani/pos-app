using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.ViewModel;
using AppContext = POS.Repository.AppContext;

namespace POS.Service
{
    public class CategoryService
    {
        private void ModelToEntity(CategoryModel model, CategoryEntity entity)
        {
            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description;
        }

        private readonly AppContext _context;
        public CategoryService(AppContext context)
        {
            _context = context;
        }

        public List<CategoryEntity> GetAll() => _context.CategoryEntities.ToList();

        public List<CategoryEntity> GetIncludeProducts() => _context.CategoryEntities.Include(s => s.Products).ToList();

        public CategoryEntity GetById(int? id) => _context.CategoryEntities.Find(id);

        public CategoryEntity GetByIdIncludeProducts(int? id) => _context.CategoryEntities.Include(s => s.Products).FirstOrDefault(s => s.Id == id);

        public void Create(CategoryModel data)
        {
            var entity = new CategoryEntity();
            ModelToEntity(data, entity);
            _context.CategoryEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.CategoryEntities.Find(id);
            _context.CategoryEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(CategoryModel data)
        {
            var entity = _context.CategoryEntities.Find(data.Id);
            ModelToEntity(data, entity);
            _context.CategoryEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
