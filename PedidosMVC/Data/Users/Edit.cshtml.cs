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
            if (User == null)
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