using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace PedidosMVC.Views.Users
{
    public class DeleteModel : PageModel
    {
        public static List<User> Users = new List<User>
        {
            new User { Id = 1, Nombre = "Juan", Email = "juan@mail.com", Direccion = "Calle 1" },
            new User { Id = 2, Nombre = "Ana", Email = "ana@mail.com", Direccion = "Calle 2" }
        };

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet(int id)
        {
            User = Users.FirstOrDefault(u => u.Id == id);
            if (User == null)
                return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            var user = Users.FirstOrDefault(u => u.Id == User.Id);
            if (user != null)
                Users.Remove(user);
            return RedirectToPage("Index");
        }
    }
}
