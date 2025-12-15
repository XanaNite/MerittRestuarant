using MerittRestuarant.Data;
using MerittRestuarant.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerittRestuarant.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingredient;

        public IngredientController(ApplicationDbContext context)
        {
            ingredient = new Repository<Ingredient>(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await ingredient.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var ingredientDetails = await ingredient.GetByIdAsync(id, new QueryOptions<Ingredient>()
            {
                Includes = "ProductIngredients.Product"
            });

            if (ingredientDetails == null)
            {
                return NotFound();
            }

            return View(ingredientDetails);
        }
    }
}
