using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("products")]
    public class ProductEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("product_name")]
        public String ProductName { get; set; }

        [Required]
        [Column("supplier_id")]
        public int SupplierId { get; set; }
        public SupplierEntity Supplier { get; set; }

        [Required]
        [Column("category_id")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        [Required]
        [Column("quantity_per_unit")]
        public String QuantityPerUnit { get; set; }

        [Required]
        [Column("unit_price")]
        public int UnitPrice { get; set; }

        [Required]
        [Column("units_in_stock")]
        public int UnitsInStock { get; set; }

        [Required]
        [Column("units_in_order")]
        public int UnitsOnOrder { get; set; }

        [Required]
        [Column("recorder_level")]
        public int RecorderLevel { get; set; }

        [Required]
        [Column("discountinued")]
        public Boolean Discountinued { get; set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
