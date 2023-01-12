using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AppContext = POS.Repository.AppContext;

namespace POS.Service
{
    public class OrderService
    {
        private void ModelToEntity(OrderModel model, OrderEntity entity)
        {
            entity.CustomerId = model.CustomerId;
            entity.EmployeeId = model.EmployeeId;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipVia = model.ShipVia;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
        }

        private readonly AppContext _context;
        public OrderService(AppContext context)
        {
            _context = context;
        }

        public List<OrderEntity> GetAll() => _context.OrderEntities.ToList();

        public List<OrderEntity> GetIncludeOrderDetails() => _context.OrderEntities.Include(s => s.OrderDetails).ToList();

        public OrderEntity GetById(int? id) => _context.OrderEntities.Find(id);

        public OrderEntity GetByIdIncludeOrderDetails(int? id) => _context.OrderEntities.Include(s => s.OrderDetails).FirstOrDefault(s => s.Id == id);

        public void Create(OrderModel data)
        {
            var entity = new OrderEntity();
            ModelToEntity(data, entity);
            _context.OrderEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.OrderEntities.Find(id);
            _context.OrderEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(OrderModel data)
        {
            var entity = _context.OrderEntities.Find(data.Id);
            ModelToEntity(data, entity);
            _context.OrderEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
