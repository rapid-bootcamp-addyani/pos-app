﻿using System;
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
        /*
        [Key]
        [Column("id")]
        public int Id { get; set; }   
        */

        [Column("order_id")]
        public int OrderId { get; set; }
        public OrderEntity order { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        public ProductEntity product { get; set; }

        [Column("unit_price")]
        public int UnitPrice { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("discount")]
        public int Discount { get; set; }

    }
}
