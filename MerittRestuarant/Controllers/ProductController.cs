using MerittRestuarant.Data;
using MerittRestuarant.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerittRestuarant.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> product;
        public ProductController(ApplicationDbContext context)
        {
            product = new Repository<Product>(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await product.GetAllAsync());
        }
    }
}
