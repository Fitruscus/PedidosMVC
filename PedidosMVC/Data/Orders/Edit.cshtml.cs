using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;

namespace PedidosMVC.Pages.Orders
{
    public class EditModel : PageModel
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Actualizar en la base de datos
            // _context.Orders.Update(Order); _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}