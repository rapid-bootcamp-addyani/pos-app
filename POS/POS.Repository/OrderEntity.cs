using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("orders")]
    public class OrderEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("costumer_id")]
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("required_date")]
        public DateTime RequiredDate { get; set; }

        [Column("shipped_date")]
        public DateTime ShippedDate { get; set; }

        [Column("ship_via")]
        public int ship_viaShipVia { get; set; }

        [Column("freight")]
        public int Freight { get; set; }

        [Column("ship_name")]
        public String ShipName { get; set; }

        [Column("ship_address")]
        public String ShipAddress { get; set; }

        [Column("ship_city")]
        public String ShipCity { get; set; }

        [Column("ship_region")]
        public String ShipRegion { get; set; }

        [Column("ship_postal_code")]
        public String ShipPostalCode { get; set; }

        [Column("ship_country")]
        public String ShipCountry { get; set; }

        public OrderDetailEntity orderDetail { get; set; }
    }
}
