using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seminar_LO_Algebra.Data;
using Seminar_LO_Algebra.Models;

namespace Seminar_LO_Algebra.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminProduct
        public async Task<IActionResult> Index()
        {
            if (_context.Product == null)
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            var products = await _context.Product.ToListAsync();
            foreach (var product in products)
            {
                product.ProductImages = _context.ProductImage.Where(pi => pi.ProductId == product.Id).ToList();
                product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == product.Id).ToList();
            }
            ViewBag.Categories = _context.Category.ToList();
            return View(products);
        }

        // GET: AdminProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Active,Description,Quantity,Price")] Product product)
        {
            ModelState.Remove("ProductCategories");
            ModelState.Remove("ProductImages");
            ModelState.Remove("OrderItems");
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.ProductImages = _context.ProductImage.Where(pi => pi.ProductId == product.Id).ToList();
            product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == product.Id).ToList();
            ViewBag.Categories = _context.Category.ToList();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Active,Description,Quantity,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            ModelState.Remove("ProductCategories");
            ModelState.Remove("OrderItems");
            ModelState.Remove("ProductImages");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(int id)
        {
            List<Category> categories = _context.Category.ToList();
            foreach (var cat in categories)
            {
                var checkbox = Request.Form[cat.Title];
                if (checkbox.Contains("true"))
                {
                    if (_context.ProductCategory.FirstOrDefault(x => x.CategoryId == cat.Id && x.ProductId == id) == null)
                        _context.ProductCategory.Add(new ProductCategory() { CategoryId = cat.Id, ProductId = id });
                }
                else
                {
                    var p = _context.ProductCategory.FirstOrDefault(x => x.CategoryId == cat.Id && x.ProductId == id);
                    if (p != null) _context.ProductCategory.Remove(p);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id });
        }

        // GET: AdminProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: AdminProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
