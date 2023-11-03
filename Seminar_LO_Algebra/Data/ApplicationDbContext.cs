using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seminar_LO_Algebra.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Seminar_LO_Algebra.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(200)]
        public string? City { get; set; }

        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }


        [ForeignKey("UserId")]
        public virtual ICollection<Order> Orders { get; set; }

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Seed_Categories
            builder.Entity<Category>().HasData(new Category
            {
                Id=1,
                Title="Memoir"
            });
            builder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Title = "Thriller"
            });
            builder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Title = "Romance"
            });
            builder.Entity<Category>().HasData(new Category
            {
                Id = 4,
                Title = "Crime"
            });
            #endregion

            builder.Entity<Product>().HasData(new Product
            {
                Id=1,
                Title="If you would have told me",
                Author="John Stamos",
                Description= "A memoir by the star of “Full House,” “ER” and “General Hospital.”",
                Active=true,
                Quantity=15,
                Price=19.99m,
            });
          

            builder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Title = "Red,White & Royal Blue",
                Author = "Casey Mcquiston",
                Description = "First Son Alex Claremont-Diaz is the closest thing to a prince this side of the Atlantic. With his intrepid sister and the Veep’s genius granddaughter, they’re the White House Trio, a beautiful millennial marketing strategy for his mother, President Ellen Claremont. International socialite duties do have downsides—namely, when photos of a confrontation with his longtime nemesis Prince Henry at a royal wedding leak to the tabloids and threaten American/British relations. The plan for damage control: staging a fake friendship between the First Son and the Prince.",
                Active = true,
                Quantity = 4,
                Price = 35.99m,
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 1,
                ProductId = 1,
                IsMainImage=true,
                Title="John Stamos",
                FileName="/images/john_stamos.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 1,
                ProductId = 2,
                IsMainImage = true,
                Title = "RedWhite&Blue",
                FileName = "/images/Redwhitelblue.jpg"
            });
            builder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                ProductId=1,
                CategoryId=1
            });
            builder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 2,
                ProductId = 2,
                CategoryId = 3
            });


            base.OnModelCreating(builder);
        }
    }
}