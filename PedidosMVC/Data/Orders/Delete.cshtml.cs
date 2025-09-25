using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;

namespace PedidosMVC.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGet(int id)
        {
            // Obtener el pedido de la base de datos
            // Order = _context.Orders.Find(id);
            if (Order == null)
                return NotFound();
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            // Eliminar de la base de datos
            // var order = _context.Orders.Find(id);
            // if (order != null) { _context.Orders.Remove(order); _context.SaveChanges(); }
            return RedirectToPage("Index");
        }
    }
}