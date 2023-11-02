using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar_LO_Algebra.Models
{
    public class Category
    {
        [Key]
         public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string Title { get; set; }

        [ForeignKey("CategoryId")]
        
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } 


    }
}
