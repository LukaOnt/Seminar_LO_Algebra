using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Seminar_LO_Algebra.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public bool IsMainImage { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(500, MinimumLength = 2)]
        [DataType(DataType.ImageUrl)]
        public string FileName { get; set; }

        [NotMapped]
        public string ProductTitle { get; set; }
    }
}