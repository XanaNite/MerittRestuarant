using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerittRestuarant.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } = "https://picsum.photos/id/292/200/300";

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public ICollection<OrderItem> OrderItems { get; set; }

        [ValidateNever]
        public ICollection<ProductIngredient>  ProductIngredients { get; set; }
    }
}