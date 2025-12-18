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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddItem(int prodId, int prodQty)
        {
            var product = await _context.Products.FindAsync(prodId);
            if (product == null)
            {
                return NotFound();
            }

            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel") ?? new OrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>(),
                Products = await _menuItemRepository.GetAllAsync()
            };

            var existingItem = model.OrderItems.FirstOrDefault(oi => oi.ProductId == prodId);
            if (existingItem != null)
            {
                existingItem.Quantity += prodQty;
            }
            else
            {
                model.OrderItems.Add(new OrderItemViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = prodQty
                });
            }

            model.TotalPrice = model.OrderItems.Sum(oi => oi.Price * oi.Quantity);
            HttpContext.Session.Set("OrderViewModel", model);

            return RedirectToAction("Create", model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");
            if (model == null || model.OrderItems.Count == 0)
            {
                return RedirectToAction("Create");
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SubmitOrder()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");
            if (model == null || model.OrderItems.Count == 0)
            {
                return RedirectToAction("Create");
            }

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = model.TotalPrice,
                UserId = _userManager.GetUserId(User)
            };

            foreach (var item in model.OrderItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            await _orderRepository.AddAsync(order);
            HttpContext.Session.Remove("OrderViewModel");
            return RedirectToAction("ViewOrders");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ViewOrders()
        {
            var userId = _userManager.GetUserId(User);

            var orders = await _orderRepository.GetAllByIdAsync(userId, "UserId", new QueryOptions<Order> 
            { 
                Includes = "OrderItems.Product"
            });

            return View(orders);
        }
    }
}
