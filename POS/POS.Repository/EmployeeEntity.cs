using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("employees")]
    public class EmployeeEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("last_name")]
        public String LastName { get; set; }

        [Required]
        [Column("first_name")]
        public String FirstName { get; set; }

        [Required]
        [Column("title")]
        public String Title { get; set; }

        [Required]
        [Column("title_of_courtesy")]
        public String TitleOfCourtesy { get; set; }

        [Required]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column("address")]
        public String Address { get; set; }

        [Required]
        [Column("city")]
        public String City { get; set; }

        [Required]
        [Column("region")]
        public String Region { get; set; }

        [Required]
        [Column("postal_code")]
        public String PostalCode { get; set; }

        [Required]
        [Column("country")]
        public String Country { get; set; }

        [Required]
        [Column("home_phone")]
        public String HomePhone { get; set; }

        [Required]
        [Column("extension")]
        public String Extension { get; set; }

        [Required]
        [Column("notes")]
        public String Notes { get; set; }

        [Required]
        [Column("report_to")]
        public int ReportTo { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}
