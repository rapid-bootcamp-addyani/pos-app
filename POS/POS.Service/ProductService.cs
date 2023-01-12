using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository;
using AppContext = POS.Repository.AppContext;
using Microsoft.EntityFrameworkCore;
using POS.ViewModel;

namespace POS.Service
{
    public class ProductService
    {
        private void ModelToEntity(ProductModel model, ProductEntity entity)
        {
            entity.ProductName = model.ProductName;
            entity.SupplierId = model.SupplierId;
            entity.CategoryId = model.CategoryId;
            entity.QuantityPerUnit = model.QuantityPerUnit;
            entity.UnitPrice = model.UnitPrice;
            entity.UnitsInStock = model.UnitsInStock;
            entity.UnitsOnOrder = model.UnitsOnOrder;
            entity.RecorderLevel = model.RecorderLevel;
            entity.Discountinued = model.Discountinued;
        }

        private readonly AppContext _context;
        public ProductService(AppContext context)
        {
            _context = context;
        }

        public List<ProductEntity> GetAll() => _context.ProductEntities.ToList();

        public List<ProductEntity> GetIncludeOrderDetails() => _context.ProductEntities.Include(s => s.OrderDetails).ToList();

        public ProductEntity GetById(int? id) => _context.ProductEntities.Find(id);

        public ProductEntity GetByIdIncludeOrderDetails(int? id) => _context.ProductEntities.Include(s => s.OrderDetails).FirstOrDefault(s => s.Id == id);

        public void Create(ProductModel data)
        {
            var entity = new ProductEntity();
            ModelToEntity(data, entity);
            _context.ProductEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.ProductEntities.Find(id);
            _context.ProductEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ProductModel data)
        {
            var entity = _context.ProductEntities.Find(data.Id);
            ModelToEntity(data, entity);
            _context.ProductEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
