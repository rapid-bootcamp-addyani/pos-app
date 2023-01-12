using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_name")]
        public String ProductName { get; set; }
        [Column("supplier_id")]
        public int SupplierId { get; set; }
        public Supplier supplier { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
        public Category category { get; set; }

        [Column("quantity_per_unit")]
        public String QuantityPerUnit { get; set; }
        [Column("unit_price")]
        public int UnitPrice { get; set; }
        [Column("units_in_stock")]
        public int UnitsInStock { get; set; }
        [Column("units_in_order")]
        public int UnitsOnOrder { get; set; }
        [Column("recorder_level")]
        public int RecorderLevel { get; set; }
        [Column("discountinued")]
        public bool Discountinued { get; set; }

        public OrderDetail orderDetail { get; set; }

    }
}
