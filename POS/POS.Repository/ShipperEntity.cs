using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("shippers")]
    public class ShipperEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("company_name")]
        public String CompanyName { get; set; }

        [Column("phone")]
        public String Phone { get; set; }
    }
}
