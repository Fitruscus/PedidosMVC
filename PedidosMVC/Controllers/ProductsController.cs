using Microsoft.AspNetCore.Mvc;
using PedidosMVC.Models;

namespace PedidosMVC.Controllers
{
    public class ProductsController : Controller
    {
        public static List<Product> _products = new();

        // GET: /Products
        public IActionResult Index()
        {
            return View(_products);
        }

        // GET: /Products/Details/5
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                var existing = _products.FirstOrDefault(p => p.Id == id);
                if (existing == null) return NotFound();
                existing.Nombre = product.Nombre;
                existing.Precio = product.Precio;
                existing.Stock = product.Stock;
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            _products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
