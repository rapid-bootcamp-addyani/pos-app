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
    public class OrderDetailService
    {
        private void ModelToEntity(OrderDetailModel model, OrderDetailEntity entity)
        {
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
        }

        private readonly AppContext _context;
        public OrderDetailService(AppContext context)
        {
            _context = context;
        }

        public List<OrderDetailEntity> GetAll() => _context.OrderDetailEntities.ToList();

        public OrderDetailEntity GetById(int? id) => _context.OrderDetailEntities.Find(id);

        public void Create(OrderDetailModel data)
        {
            var entity = new OrderDetailEntity();
            ModelToEntity(data, entity);
            _context.OrderDetailEntities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.OrderDetailEntities.Find(id);
            _context.OrderDetailEntities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(OrderDetailModel data)
        {
            var entity = _context.OrderDetailEntities.Find(data.Id);
            ModelToEntity(data, entity);
            _context.OrderDetailEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
