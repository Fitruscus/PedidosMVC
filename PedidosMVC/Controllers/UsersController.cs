using Microsoft.AspNetCore.Mvc;
using PedidosMVC.Models;

namespace PedidosMVC.Controllers
{
    public class UsersController : Controller
    {
        private static List<User> _users = new();

        // GET: /Users
        public IActionResult Index()
        {
            return View(_users);
        }

        // GET: /Users/Details/5
        public IActionResult Details(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        // GET: /Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
                _users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: /Users/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                var existing = _users.FirstOrDefault(u => u.Id == id);
                if (existing == null) return NotFound();
                existing.Nombre = user.Nombre;
                existing.Email = user.Email;
                existing.Direccion = user.Direccion;
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: /Users/Delete/5
        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            _users.Remove(user);
            return RedirectToAction(nameof(Index));
        }
    }
}