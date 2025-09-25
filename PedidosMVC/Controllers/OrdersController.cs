using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PedidosMVC.Models;
using PedidosMVC.Data;
using System.Linq;

namespace PedidosMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PedidosDbContext _context;

        public OrdersController(PedidosDbContext context)
        {
            _context = context;
        }

        // GET: /Orders
        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToList();
            return View(orders);
        }

        // GET: /Orders/Details/5
        public IActionResult Details(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();
            return View(order);
        }

        // GET: /Orders/Create
        public IActionResult Create()
        {
            ViewBag.Productos = new SelectList(_context.Products, "Id", "Nombre");
            ViewBag.ProductoSeleccionado = 0;
            return View();
        }

        // POST: /Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order, int ProductId)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();

                // Crear el OrderItem
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = ProductId,
                    Cantidad = 1 
                };
                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();

                // Reducir stock
                var product = _context.Products.Find(ProductId);
                if (product != null)
                {
                    product.Stock -= orderItem.Cantidad;
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Productos = new SelectList(_context.Products, "Id", "Nombre");
            ViewBag.ProductoSeleccionado = ProductId;
            return View(order);
        }

        // GET: /Orders/Edit/5
        public IActionResult Edit(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return NotFound();

            ViewBag.Productos = new SelectList(_context.Products, "Id", "Nombre");
            ViewBag.ProductoSeleccionado = order.OrderItems.FirstOrDefault()?.ProductId ?? 0;
            return View(order);
        }

        // POST: /Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order, int ProductId)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Productos = new SelectList(_context.Products, "Id", "Nombre");
                ViewBag.ProductoSeleccionado = ProductId;
                return View(order);
            }

            // Actualizar el pedido
            _context.Orders.Update(order);
            _context.SaveChanges();

            // Actualizar el OrderItem (asumiendo solo uno por pedido)
            var orderItem = _context.OrderItems.FirstOrDefault(oi => oi.OrderId == order.Id);
            if (orderItem != null)
            {
                // Si cambió el producto, actualiza y ajusta stock
                if (orderItem.ProductId != ProductId)
                {
                    // Regresa stock anterior
                    var oldProduct = _context.Products.Find(orderItem.ProductId);
                    if (oldProduct != null)
                    {
                        oldProduct.Stock += orderItem.Cantidad;
                    }
                    // Descuenta stock nuevo
                    var newProduct = _context.Products.Find(ProductId);
                    if (newProduct != null)
                    {
                        newProduct.Stock -= orderItem.Cantidad;
                    }
                    orderItem.ProductId = ProductId;
                }
                _context.OrderItems.Update(orderItem);
            }
            else
            {
                // Si no existe, lo crea
                var newOrderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = ProductId,
                    Cantidad = 1
                };
                _context.OrderItems.Add(newOrderItem);
                var newProduct = _context.Products.Find(ProductId);
                if (newProduct != null)
                {
                    newProduct.Stock -= newOrderItem.Cantidad;
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: /Orders/Delete/5
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();
            return View(order);
        }

        // POST: /Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
