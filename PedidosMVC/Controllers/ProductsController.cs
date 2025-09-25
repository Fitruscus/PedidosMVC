using Microsoft.AspNetCore.Mvc;
using PedidosMVC.Models;
using PedidosMVC.Data;

namespace PedidosMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PedidosDbContext _context;

        public ProductsController(PedidosDbContext context)
        {
            _context = context;
        }

        // GET: /Products
        public IActionResult Index(string filtroNombre, string filtroCategoria, decimal? filtroPrecioMin, decimal? filtroPrecioMax)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtroNombre))
                query = query.Where(p => p.Nombre.Contains(filtroNombre));

            if (!string.IsNullOrWhiteSpace(filtroCategoria))
                query = query.Where(p => p.Categoria.Contains(filtroCategoria));

            if (filtroPrecioMin.HasValue)
                query = query.Where(p => p.Precio >= filtroPrecioMin.Value);

            if (filtroPrecioMax.HasValue)
                query = query.Where(p => p.Precio <= filtroPrecioMax.Value);

            var products = query.ToList();
            ViewBag.FiltroNombre = filtroNombre;
            ViewBag.FiltroCategoria = filtroCategoria;
            ViewBag.FiltroPrecioMin = filtroPrecioMin;
            ViewBag.FiltroPrecioMax = filtroPrecioMax;
            return View(products);
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
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
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
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Details/5
        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
