using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;
using PedidosMVC.Data;
using System.Collections.Generic;
using System.Linq;

namespace PedidosMVC.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PedidosDbContext _context;

        public IndexModel(PedidosDbContext context)
        {
            _context = context;
        }

        public List<Product> Productos { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string FiltroNombre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FiltroCategoria { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal? FiltroPrecioMin { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal? FiltroPrecioMax { get; set; }

        public void OnGet()
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(FiltroNombre))
                query = query.Where(p => p.Nombre.Contains(FiltroNombre));

            if (!string.IsNullOrWhiteSpace(FiltroCategoria))
                query = query.Where(p => p.Categoria.Contains(FiltroCategoria));

            if (FiltroPrecioMin.HasValue)
                query = query.Where(p => p.Precio >= FiltroPrecioMin.Value);

            if (FiltroPrecioMax.HasValue)
                query = query.Where(p => p.Precio <= FiltroPrecioMax.Value);

            Productos = query.ToList();
        }
    }
}
