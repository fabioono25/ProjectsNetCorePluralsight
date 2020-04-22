using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class AppDbContext: IdentityDbContext<IdentityUser> //DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seed categories
            builder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Fruit Pies", Description = "Tasty fruid pies" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Cheeese Pies", Description = "Cheese fruid pies" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Salty Pies", Description = "Salty fruid pies" });

            //seed pies
            builder.Entity<Pie>().HasData(new Pie
            {
                PieId = 1,
                Name = "Apple Pie",
                Price = 12.3M,
                ShortDescription = "Famous apple pie!",
                LongDescription = "Famous apple pie very famous!",
                CategoryId = 1,
                ImageUrl = "https://images-gmi-pmc.edge-generalmills.com/75593ed5-420b-4782-8eae-56bdfbc2586b.jpg",
                InStock = true,
                IsPieOfTheWeek = true,
                ImageThumbnailUrl = "https://images-gmi-pmc.edge-generalmills.com/75593ed5-420b-4782-8eae-56bdfbc2586b.jpg",
                AllergyInformation = ""
            });

            builder.Entity<Pie>().HasData(new Pie
            {
                PieId = 2,
                Name = "Blueberry Pie",
                Price = 22.0M,
                ShortDescription = "Famous blueberry pie!",
                LongDescription = "Famous blueberry pie very famous!",
                CategoryId = 2,
                ImageUrl = "https://s3.amazonaws.com/finecooking.s3.tauntonclud.com/app/uploads/2017/04/18134327/051093069-01-blueberry-blackberry-pie-main.jpg",
                InStock = true,
                IsPieOfTheWeek = false,
                ImageThumbnailUrl = "https://s3.amazonaws.com/finecooking.s3.tauntonclud.com/app/uploads/2017/04/18134327/051093069-01-blueberry-blackberry-pie-main.jpg",
                AllergyInformation = ""
            });


            builder.Entity<Pie>().HasData(new Pie
            {
                PieId = 3,
                Name = "The Salty Pie",
                Price = 14.0M,
                ShortDescription = "Famous salty pie!",
                LongDescription = "Famous salty pie very famous!",
                CategoryId = 3,
                ImageUrl = "https://www.valitalia.com/eu/pub/media/wysiwyg/torta_salata_with_broccoli_and_sausage.jpg",
                InStock = true,
                IsPieOfTheWeek = true,
                ImageThumbnailUrl = "https://www.valitalia.com/eu/pub/media/wysiwyg/torta_salata_with_broccoli_and_sausage.jpg",
                AllergyInformation = ""
            });


            //base.OnModelCreating(builder);
            //builder.Entity<Pie>()
            //    .HasOne(p => p.RecipeInformation)
            //    .WithOne(i => i.Pie)
            //    .HasForeignKey<RecipeInformation>(b => b.PieId);

            //builder.Entity<ApplicationUser>()
            //    .HasMany(e => e.Claims)
            //    .WithOne()
            //    .HasForeignKey(e => e.UserId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
