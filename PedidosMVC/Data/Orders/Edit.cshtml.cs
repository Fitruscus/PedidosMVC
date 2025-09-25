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
            if (Order == null)
                return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            return RedirectToPage("Index");
        }
    }
}