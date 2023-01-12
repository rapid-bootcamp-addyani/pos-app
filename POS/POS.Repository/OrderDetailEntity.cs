using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("order_details")]
    public class OrderDetailEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("order_id")]
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        [Required]
        [Column("product_id")]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        [Required]
        [Column("unit_price")]
        public int UnitPrice { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("discount")]
        public int Discount { get; set; }
    }
}
