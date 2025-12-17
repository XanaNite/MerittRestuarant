using MerittRestuarant.Data;
using MerittRestuarant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MerittRestuarant.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Repository<Order> _orderRepository;
        private Repository<Product> _menuItemRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _orderRepository = new Repository<Order>(context);
            _menuItemRepository = new Repository<Product>(context);
            _userManager = userManager;
        }

        [Authorize] //login required to access this action
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel") ?? new OrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>(),
                Products = await _menuItemRepository.GetAllAsync()
            };

            return View(model);
        }
    }
}
