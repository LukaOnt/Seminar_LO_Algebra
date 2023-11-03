using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar_LO_Algebra.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200,MinimumLength =2)]

        public string Title { get; set; }
        public string Author { get; set; }

        public bool Active { get; set; }
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
