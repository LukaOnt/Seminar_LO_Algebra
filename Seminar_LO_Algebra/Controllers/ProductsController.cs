using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Seminar_LO_Algebra.Data;
using Seminar_LO_Algebra.Models;

namespace Seminar_LO_Algebra.Controllers
{
    public class ProductsController : Controller
    {
        public const string SessionKeyName = "_cart";

        private readonly ILogger<ProductsController> _logger;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductsController (ILogger<ProductsController> logger,
                                    ApplicationDbContext context,
                                    UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }
         public IActionResult Product(int? id, int? categoryId)
        {
            List<Product> products = _context.Product.Where(x => x.Active == true).ToList();

            if (id != null)
            {
                var product = products.Where(p => p.Id == id).FirstOrDefault();
                product.ProductImages = _context.ProductImage.Where(pi => pi.ProductId == product.Id).ToList();
                product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == product.Id).ToList();
                return View("ProductDetails", product);
            }

            foreach (var product in products)
            {
                product.ProductImages = _context.ProductImage.Where(pi => pi.ProductId == product.Id).ToList();
                product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == product.Id).ToList();
            }

            if (categoryId != null)
            {
                products = products.Where(p => p.ProductCategories.Any(p => p.CategoryId == categoryId)).ToList();
            }

            ViewBag.Categories = _context.Category.ToList();
            return View(products);
        }

    /*
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
