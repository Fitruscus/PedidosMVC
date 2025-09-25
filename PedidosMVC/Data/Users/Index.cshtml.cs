using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;
using System.Collections.Generic;

namespace PedidosMVC.Pages.Users
{
    public class IndexModel : PageModel
    {
        public List<User> Users { get; set; } = new();

        public void OnGet()
        {
        }
    }
}