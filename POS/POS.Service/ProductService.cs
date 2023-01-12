using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository;
using AppContext = POS.Repository.AppContext;

namespace POS.Service
{
    public class ProductService
    {
        private readonly AppContext _context;
        public ProductService(AppContext context)
        {
            _context = context;
        }

        public List<ProductEntity> GetCategories() => _context.ProductEntities.ToList();

        public ProductEntity GetProductById(int id) => _context.ProductEntities.Find(id);

        public Boolean DeleteProduct(ProductEntity data)
        {
            _context.ProductEntities.Remove(data);
            _context.SaveChanges();
            return true;
        }

        public Boolean Create(ProductEntity data)
        {
            _context.ProductEntities.Add(data);
            _context.SaveChanges();
            return true;
        }

        public Boolean Update(ProductEntity data)
        {
            _context.ProductEntities.Update(data);
            _context.SaveChanges();
            return true;
        }
    }
}
