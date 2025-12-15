using MerittRestuarant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MerittRestuarant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            //seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Appetizers" },
                new Category { CategoryId = 2, Name = "Main Courses" },
                new Category { CategoryId = 3, Name = "Side Dish" },
                new Category { CategoryId = 4, Name = "Beverages" },
                new Category { CategoryId = 5, Name = "Desserts" }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Cayenne powder" },
                new Ingredient { IngredientId = 2, Name = "Salt" },
                new Ingredient { IngredientId = 3, Name = "Pine nuts" },
                new Ingredient { IngredientId = 4, Name = "Chicken" },
                new Ingredient { IngredientId = 5, Name = "Spinach" },
                new Ingredient { IngredientId = 6, Name = "Garlic" },
                new Ingredient { IngredientId = 7, Name = "Coconut aminos" },
                new Ingredient { IngredientId = 8, Name = "Olive oil" },
                new Ingredient { IngredientId = 9, Name = "Mushrooms" },
                new Ingredient { IngredientId = 10, Name = "Onion" },
                new Ingredient { IngredientId = 11, Name = "Coconut oil" },
                new Ingredient { IngredientId = 12, Name = "Nutritional yeast" },
                new Ingredient { IngredientId = 13, Name = "Chicken broth" },
                new Ingredient { IngredientId = 14, Name = "Coconut milk" },
                new Ingredient { IngredientId = 15, Name = "Polenta" },
                new Ingredient { IngredientId = 16, Name = "Broccoli" },
                new Ingredient { IngredientId = 17, Name = "Black cod" },
                new Ingredient { IngredientId = 18, Name = "Avocado oil" },
                new Ingredient { IngredientId = 19, Name = "Garlic powder" },
                new Ingredient { IngredientId = 20, Name = "Chicken seasoning" },
                new Ingredient { IngredientId = 21, Name = "Long grain brown rice" },
                new Ingredient { IngredientId = 22, Name = "Quinoa" },
                new Ingredient { IngredientId = 23, Name = "Sriracha mayo" },
                new Ingredient { IngredientId = 24, Name = "Brussel sprouts" },
                new Ingredient { IngredientId = 25, Name = "Salmon" },
                new Ingredient { IngredientId = 26, Name = "Cajun seasoning" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Air Fried Chicken",
                    Description = "Air fried, tender chicken marinated in a spicy blend of cayenne powder and garlic.",
                    Price = 12.99m,
                    StockQuantity = 50,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Roasted Brussel Sprouts",
                    Description = "Brussel sprouts roasted to perfection, topped with sriracha mayo for an extra kick.",
                    Price = 9.99m,
                    StockQuantity = 50,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Mushroom Spinach Polenta",
                    Description = "A creammy polenta with mushrooms and spinach.",
                    Price = 14.99m,
                    StockQuantity = 50,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Pan Fried Black Cod",
                    Description = "A buttery black cod marinated in a spicy blend of cayenne powder and garlic.",
                    Price = 15.99m,
                    StockQuantity = 50,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Cajun Salmon",
                    Description = "A spicy, pan fried salmon",
                    Price = 13.99m,
                    StockQuantity = 50,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Garlic Rice",
                    Description = "A garlicky rice quinoa mix.",
                    Price = 7.99m,
                    StockQuantity = 50,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Roasted Broccoli",
                    Description = "A tender, roasted broccoli with sea salt.",
                    Price = 8.99m,
                    StockQuantity = 50,
                    CategoryId = 3
                }
            );

            modelBuilder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId = 1, IngredientId = 4 },
                new ProductIngredient { ProductId = 1, IngredientId = 8 },
                new ProductIngredient { ProductId = 1, IngredientId = 20 },
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 18 },
                new ProductIngredient { ProductId = 2, IngredientId = 23 },
                new ProductIngredient { ProductId = 2, IngredientId = 24 },
                new ProductIngredient { ProductId = 3, IngredientId = 1 },
                new ProductIngredient { ProductId = 3, IngredientId = 2 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 5 },
                new ProductIngredient { ProductId = 3, IngredientId = 6 },
                new ProductIngredient { ProductId = 3, IngredientId = 7 },
                new ProductIngredient { ProductId = 3, IngredientId = 9 },
                new ProductIngredient { ProductId = 3, IngredientId = 10 },
                new ProductIngredient { ProductId = 3, IngredientId = 11 },
                new ProductIngredient { ProductId = 3, IngredientId = 12 },
                new ProductIngredient { ProductId = 3, IngredientId = 13 },
                new ProductIngredient { ProductId = 3, IngredientId = 14 },
                new ProductIngredient { ProductId = 3, IngredientId = 15 },
                new ProductIngredient { ProductId = 4, IngredientId = 1 },
                new ProductIngredient { ProductId = 4, IngredientId = 2 },
                new ProductIngredient { ProductId = 4, IngredientId = 17 },
                new ProductIngredient { ProductId = 4, IngredientId = 18 },
                new ProductIngredient { ProductId = 4, IngredientId = 19 },
                new ProductIngredient { ProductId = 5, IngredientId = 18 },
                new ProductIngredient { ProductId = 5, IngredientId = 25 },
                new ProductIngredient { ProductId = 5, IngredientId = 26 },
                new ProductIngredient { ProductId = 6, IngredientId = 2 },
                new ProductIngredient { ProductId = 6, IngredientId = 6 },
                new ProductIngredient { ProductId = 6, IngredientId = 13 },
                new ProductIngredient { ProductId = 6, IngredientId = 21 },
                new ProductIngredient { ProductId = 6, IngredientId = 22 },
                new ProductIngredient { ProductId = 7, IngredientId = 2 },
                new ProductIngredient { ProductId = 7, IngredientId = 8 },
                new ProductIngredient { ProductId = 7, IngredientId = 16 }
            );
        }
    }
}
