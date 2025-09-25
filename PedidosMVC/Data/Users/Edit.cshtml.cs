using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;

namespace PedidosMVC.Pages.Users
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet(int id)
        {
            // Obtener el usuario de la base de datos
            // User = _context.Users.Find(id);
            if (User == null)
                return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Actualizar en la base de datos
            // _context.Users.Update(User); _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}