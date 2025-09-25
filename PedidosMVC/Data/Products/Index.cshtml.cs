using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;
using System.Collections.Generic;

namespace PedidosMVC.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            // Aquí deberías obtener los productos de la base de datos usando el DbContext
            // Ejemplo: Products = _context.Products.ToList();
        }
    }
}
