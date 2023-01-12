using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public String ProductName { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public String QuantityPerUnit { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public int UnitsOnOrder { get; set; }

        [Required]
        public int RecorderLevel { get; set; }

        [Required]
        public Boolean Discountinued { get; set; }
    }
}
