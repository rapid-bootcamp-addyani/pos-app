using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("categories")]
    public class CategoryEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("category_name")]
        public String CategoryName { get; set; }

        [Required]
        [Column("description")]
        public String Description { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

        public CategoryEntity(POS.ViewModel.CategoryModel model)
        {
            CategoryName = model.CategoryName;
            Description = model.Description;
        }

        public CategoryEntity()
        {
        }
    }
}
