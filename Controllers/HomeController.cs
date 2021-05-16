using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yellow.Models;

namespace Yellow.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationContext db;

		public HomeController(ApplicationContext context)
		{
			db = context;
		}

		public async Task<IActionResult> IndexAsync()
		{
			return View(new IndexViewModel() {
				AppleProducts = await db.Products.Where(p => p.Manufacturer.Name == "Apple").Take(6).ToListAsync(),
				NewProducts = await db.Products.OrderByDescending(p => p.Id).Take(6).ToListAsync()
			});
		}
		[HttpGet("{categoryName}")]
		public async Task<IActionResult> IndexAsync(string categoryName, int manufacturerId)
		{
			var productsQuery = db.Products
					.Include(p => p.Category)
					.Where(p => p.Category.Name == categoryName);
			if (manufacturerId != 0)
				productsQuery = productsQuery.Where(p => p.ManufacturerId == manufacturerId);

			var products = await productsQuery.ToListAsync();
			if (products.Count == 0)
				return NotFound();

			return View("Category", new CategoryViewModel() {
				CategoryName = categoryName,
				ManufacturerName = manufacturerId != 0 ? db.Manufacturers.Find(manufacturerId).Name : null,
				Products = products, 
				Manufacturers = await db.Manufacturers.ToListAsync(),
			});
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
