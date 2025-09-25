using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;

namespace PedidosMVC.Pages.Orders
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }

        public void OnGet()
        {
            Order = new Order { Fecha = DateTime.Today };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Guardar en la base de datos aquí
            // Ejemplo: _context.Orders.Add(Order); _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}