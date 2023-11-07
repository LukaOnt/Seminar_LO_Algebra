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
                Id = 2,
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

            //Dodano nakon migracije

            builder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Title = "The Raging storm",
                Author = "Ann Cleves",
                Description = "Detective Matthew Venn returns in The Raging Storm, the next captivating novel in the Two Rivers series from Ann Cleeves. When enigmatic sailor Jem Rosco arrives in Greystone, Devon, the town are delighted to have a celebrity in their midst. But when he disappears and is later found dead during a storm, DI Matthew Venn faces an uncomfortable case. Having left the Barum Brethren community in Greystone, Venn's judgment is clouded by superstitions and rumors as another body is discovered in Scully Cove. Isolated by the storm, Venn and his team embark on a perilous investigation, unaware that their own lives may be at risk. ",
                Active = true,
                Quantity = 4,
                Price = 35.99m,
            });
            builder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 3,
                ProductId = 4,
                CategoryId = 4
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 4,
                ProductId = 4,
                IsMainImage = true,
                Title = "ancleve",
                FileName = "/images/ancleve.png"
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Title = "Some people need killing",
                Author = "Patricia Evangelista",
                Description = "In 2016, Rodrigo Duterte was elected President of the Philippines after campaigning on the promise of slaughtering three million drug addicts. In this unflinching account of the ensuing violence, a Filipina trauma journalist narrates six years of the country’s drug war, during which she spent her evenings “in the mechanical absorption of organized killing.” The book, conceived as a record of extrajudicial deaths, interweaves snippets of memoir that chart Evangelista’s personal evolution alongside that of her country under Duterte. In this period, she became “a citizen of a nation I cannot recognize as my own.”",
                Active = true,
                Quantity = 10,
                Price = 37.99m,
            });
            builder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 4,
                ProductId = 5,
                CategoryId = 4
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 5,
                ProductId = 4,
                IsMainImage = true,
                Title = "patricia_evang",
                FileName = "/images/patricia_evang.png"
            });
            base.OnModelCreating(builder);
        }
    }
}