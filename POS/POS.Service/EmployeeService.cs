using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using AppContext = POS.Repository.AppContext;
using POS.ViewModel;
using System.Diagnostics.Metrics;
using System.Net;

namespace POS.Service
{
    public class EmployeeService
    {
        private void ModelToEntity(EmployeeModel model, EmployeeEntity entity)
        {
            entity.LastName = model.LastName;
            entity.FirstName = model.FirstName;
            entity.Title = model.Title;
            entity.TitleOfCourtesy = model.TitleOfCourtesy;
            entity.BirthDate = model.BirthDate;

            entity.HireDate = model.HireDate;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;

            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            entity.Notes = model.Notes;
            entity.ReportTo = model.ReportTo;
        }

        private readonly AppContext _context;
        public EmployeeService(AppContext context)
        {
            _context = context;
        }

        public List<EmployeeEntity> GetAll() => _context.EmployeeEntities.ToList();

        public List<EmployeeEntity> GetIncludeOrders() => _context.EmployeeEntities.Include(s => s.Orders).ToList();

        public EmployeeEntity GetById(int? id) => _context.EmployeeEntities.Find(id);

        public EmployeeEntity GetByIdIncludeOrders(int? id) => _context.EmployeeEntities.Include(s => s.Orders).FirstOrDefault(s => s.Id == id);

        public void Create(EmployeeModel data)
        {
            var entity = new EmployeeEntity();
            ModelToEntity(data, entity);
            _context.EmployeeEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.EmployeeEntities.Find(id);
            _context.EmployeeEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(EmployeeModel data)
        {
            var entity = _context.EmployeeEntities.Find(data.Id);
            ModelToEntity(data, entity);
            _context.EmployeeEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
