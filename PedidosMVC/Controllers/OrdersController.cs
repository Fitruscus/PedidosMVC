using Microsoft.AspNetCore.Mvc;
using PedidosMVC.Models;

namespace PedidosMVC.Controllers
{
    public class OrdersController : Controller
    {
        private static List<Order> _orders = new();

        // GET: /Orders
        public IActionResult Index()
        {
            return View(_orders);
        }

        // GET: /Orders/Details/5
        public IActionResult Details(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // GET: /Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = _orders.Count > 0 ? _orders.Max(o => o.Id) + 1 : 1;
                _orders.Add(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: /Orders/Edit/5
        public IActionResult Edit(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // POST: /Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                var existing = _orders.FirstOrDefault(o => o.Id == id);
                if (existing == null) return NotFound();
                existing.Cliente = order.Cliente;
                existing.Estado = order.Estado;
                existing.Fecha = order.Fecha;
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: /Orders/Delete/5
        public IActionResult Delete(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // POST: /Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            _orders.Remove(order);
            return RedirectToAction(nameof(Index));
        }
    }
}
