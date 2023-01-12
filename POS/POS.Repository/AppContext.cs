using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public DbSet<CategoryEntity> CategoryEntities => Set<CategoryEntity>();
        public DbSet<CustomerEntity> CustomerEntities => Set<CustomerEntity>();
        public DbSet<EmployeeEntity> EmployeeEntities => Set<EmployeeEntity>();
        public DbSet<OrderEntity> OrderEntities => Set<OrderEntity>();
        public DbSet<OrderDetailEntity> OrderDetailEntities => Set<OrderDetailEntity>();
        public DbSet<ProductEntity> ProductEntities => Set<ProductEntity>();
        public DbSet<SupplierEntity> SupplierEntities => Set<SupplierEntity>();
    }
}
