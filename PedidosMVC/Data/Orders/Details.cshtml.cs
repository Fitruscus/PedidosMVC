using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;

namespace PedidosMVC.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        public Order Order { get; set; }

        public IActionResult OnGet(int id)
        {
            // Obtener el pedido de la base de datos
            // Order = _context.Orders.Find(id);
            if (Order == null)
                return NotFound();
            return Page();
        }
    }
}