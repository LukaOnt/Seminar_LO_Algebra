using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Seminar_LO_Algebra.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Total price is required")]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Total { get; set; }


        #region Billing

        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(100, MinimumLength = 2)]
        public string BillingFirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(100, MinimumLength = 2)]
        public string BillingLastName { get; set; }

        [Required(ErrorMessage = "Email Address is Required")]
        [StringLength(200, MinimumLength = 2)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string BillingEmail { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
        public string BillingPhone { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(200)]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(200)]
        public string BillingCity { get; set; }

        [Required(ErrorMessage = "Postal Code is Required")]
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string BillingPostalCode { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [StringLength(100)]
        public string BillingCountry { get; set; }

        #endregion

        #region Shipping


        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(100, MinimumLength = 2)]
        public string ShippingFirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(100, MinimumLength = 2)]
        public string ShippingLastName { get; set; }

        [Required(ErrorMessage = "Email Address is Required")]
        [StringLength(200, MinimumLength = 2)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string ShippingEmail { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
        public string ShippingPhone { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(200)]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(200)]
        public string ShippingCity { get; set; }

        [Required(ErrorMessage = "Postal Code is Required")]
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string ShippingPostalCode { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [StringLength(100)]
        public string ShippingCountry { get; set; }

        #endregion

        public string? Message { get; set; }

        public string UserId { get; set; }

        [ForeignKey("OrderId")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
