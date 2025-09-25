using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;
using System.Collections.Generic;

namespace PedidosMVC.Pages.Orders
{
    public class IndexModel : PageModel
    {
        public List<Order> Orders { get; set; } = new();

        public void OnGet()
        {
        }
    }
}