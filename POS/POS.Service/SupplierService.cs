using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository;
using AppContext = POS.Repository.AppContext;
using Microsoft.EntityFrameworkCore;

namespace POS.Service
{
    public class SupplierService
    {
        private readonly AppContext _context;
        public SupplierService(AppContext context)
        {
            _context = context;
        }

        public List<SupplierEntity> GetCategories() => _context.SupplierEntities.ToList();

        public SupplierEntity GetSupplierById(int id) => _context.SupplierEntities.Find(id);

        public List<SupplierEntity> GetSupplierWithProduct()
        {
            return _context.SupplierEntities.Include(s => s.Products).ToList();
        }
        
        //public List<SupplierEntity> GetSupplierWithProduct() => _context.SupplierEntities.Include(o => o.Products.Where(od => od.SupplierId == o.Id)).ToList();

        public Boolean DeleteSupplier(SupplierEntity data)
        {
            _context.SupplierEntities.Remove(data);
            _context.SaveChanges();
            return true;
        }

        public Boolean Create(SupplierEntity data)
        {
            _context.SupplierEntities.Add(data);
            _context.SaveChanges();
            return true;
        }

        public Boolean Update(SupplierEntity data)
        {
            _context.SupplierEntities.Update(data);
            _context.SaveChanges();
            return true;
        }
    }
}
