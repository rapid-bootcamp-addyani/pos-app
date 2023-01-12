using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppContext = POS.Repository.AppContext;
using POS.ViewModel;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace POS.Service
{
    public class CustomerService
    {
        private void ModelToEntity(CustomerModel model, CustomerEntity entity)
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
        }

        private readonly AppContext _context;
        public CustomerService(AppContext context)
        {
            _context = context;
        }

        public List<CustomerEntity> GetAll() => _context.CustomerEntities.ToList();

        public List<CustomerEntity> GetIncludeOrders() => _context.CustomerEntities.Include(s => s.Orders).ToList();

        public CustomerEntity GetById(int? id) => _context.CustomerEntities.Find(id);

        public CustomerEntity GetByIdIncludeOrders(int? id) => _context.CustomerEntities.Include(s => s.Orders).FirstOrDefault(s => s.Id == id);

        public void Create(CustomerModel data)
        {
            var entity = new CustomerEntity();
            ModelToEntity(data, entity);
            _context.CustomerEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.CustomerEntities.Find(id);
            _context.CustomerEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(CustomerModel data)
        {
            var entity = _context.CustomerEntities.Find(data.Id);
            ModelToEntity(data, entity);
            _context.CustomerEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
