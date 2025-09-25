using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosMVC.Models;
using PedidosMVC.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PedidosMVC.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly PedidosDbContext _context;

        public DetailsModel(PedidosDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }
        public decimal Total { get; set; }

        public void OnGet(int id)
        {
            Order = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.Id == id);

            if (Order != null && Order.OrderItems != null)
            {
                Total = Order.OrderItems.Sum(oi => oi.Product.Precio * oi.Cantidad);
            }
        }
    }
}