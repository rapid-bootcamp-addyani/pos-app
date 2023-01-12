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
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace POS.Service
{
    public class SupplierService
    {
        private void ModelToEntity(SupplierModel model, SupplierEntity entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
            entity.Homepage = model.Homepage;
        }

        private readonly AppContext _context;
        public SupplierService(AppContext context)
        {
            _context = context;
        }

        public List<SupplierEntity> GetAll() => _context.SupplierEntities.ToList();

        public List<SupplierEntity> GetIncludeProducts() => _context.SupplierEntities.Include(s => s.Products).ToList();

        public SupplierEntity GetById(int? id) => _context.SupplierEntities.Find(id);

        public SupplierEntity GetByIdIncludeProducts(int? id) => _context.SupplierEntities.Include(s => s.Products).FirstOrDefault(s => s.Id == id);

        public void Create(SupplierModel data)
        {
            var entity = new SupplierEntity();
            ModelToEntity(data, entity);
            _context.SupplierEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.SupplierEntities.Find(id);
            _context.SupplierEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(SupplierModel data)
        {
            var entity = _context.SupplierEntities.Find(data.Id);
            ModelToEntity(data, entity);
            _context.SupplierEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
