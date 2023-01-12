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

        [Required]
        [Column("costumer_id")]
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        [Required]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        [Required]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column("required_date")]
        public DateTime RequiredDate { get; set; }

        [Required]
        [Column("shipped_date")]
        public DateTime ShippedDate { get; set; }

        [Required]
        [Column("ship_via")]
        public int ShipVia { get; set; }

        [Required]
        [Column("freight")]
        public int Freight { get; set; }

        [Required]
        [Column("ship_name")]
        public String ShipName { get; set; }

        [Required]
        [Column("ship_address")]
        public String ShipAddress { get; set; }

        [Required]
        [Column("ship_city")]
        public String ShipCity { get; set; }

        [Required]
        [Column("ship_region")]
        public String ShipRegion { get; set; }

        [Required]
        [Column("ship_postal_code")]
        public String ShipPostalCode { get; set; }

        [Required]
        [Column("ship_country")]
        public String ShipCountry { get; set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
